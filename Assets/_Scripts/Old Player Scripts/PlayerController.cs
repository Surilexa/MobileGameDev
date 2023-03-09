using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IKnockbackable
{
    [Header("Player Stats")]
    public float playerHealth = 50f;

    public GameStateManager gameState;

    private Player playerControls;
    private Vector2 playerVelocity;
    private bool groundedPlayer;
    private Vector2 movementInput;

    //public PlayerActionInputs playerControls;

    [Header("Audio")]
    [SerializeField] AudioSource heal;

    private InputAction move;
    private InputAction attack;
    private InputAction jump;
    private InputAction winGame;
    private InputAction loseGame;

    public Rigidbody2D rb;

    public Animator animator;

    public CharacterController2D controller;

    private bool isJump;

    [SerializeField] private float playerSpeed = 2.0f;

    public GameObject healthBarUI;

    [Header("Attack Range")]
    [SerializeField] float AttackRadius;
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] Transform attackArea;
    //public AttackDetails attackDetails;

    private void Awake()
    {
        playerControls = new Player();
        //playerControls = new PlayerActionInputs();
        isJump = false;
        //OnDrawGizmos();
        //Gizmos.DrawWireSphere(attackArea.position, AttackRadius);


    }
    private void OnEnable()
    {
        move = playerControls.PlayerMain.Move;
        move.Enable();

        attack = playerControls.PlayerMain.Attack;
        attack.Enable();
        attack.performed += Attack;
           
        jump = playerControls.PlayerMain.Jump;
        jump.Enable();
        jump.performed += Jump;
        //playerInput.Enable();

        winGame = playerControls.PlayerMain.WinGame;
        winGame.Enable();
        winGame.performed += Win;
    }
    private void OnDisable()
    {
        move.Disable();
        attack.Disable();
        jump.Disable();
    }
    void Update()
    {
        //movementInput = move.PlayerMain.Move.ReadValue<Vector2>();
        movementInput = move.ReadValue<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(movementInput.x));
    }
    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(movementInput.x * playerSpeed, movementInput.y * playerSpeed);
        controller.Move(movementInput.x * playerSpeed * Time.fixedDeltaTime, false, isJump);
        isJump = false;
    }
    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("we attacked");
        animator.SetBool("Attacking", true);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("we jumped");
        
        isJump= true;
        animator.SetBool("isJumping", true);
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void EndAttack()
    {
        animator.SetBool("Attacking", false);
    }
    private void Win(InputAction.CallbackContext context)
    {
        Debug.Log("Win");
    }
    public void takeDamage()
    {
        if (!animator.GetBool("takeDamage") && !animator.GetBool("death"))
        {
            playerHealth -= 10;
            GameObject.Find("HealthBarUI").GetComponent<Bar>().SetHealth((int)playerHealth);
            animator.SetBool("takeDamage", true);
            GameObject.Find("PlayerTakeDamageAudio").GetComponent<AudioSource>().Play();
        }
        if(playerHealth <= 0)
        {
            playerHealth = 0;
            Death();
        }
    }
    public void healPlayer()
    {
        if(playerHealth < 50f)
        {
            playerHealth += 10;
            GameObject.Find("HealthBarUI").GetComponent<Bar>().SetHealth((int)playerHealth);
            heal.Play();
        }
    }
    public void endDamage()
    {
        animator.SetBool("takeDamage", false);
    }
    public void Death()
    {
        animator.SetBool("takeDamage", false);
        animator.SetBool("death", true);
        OnDisable();
        this.gameObject.layer = LayerMask.NameToLayer("Level");
    }

    public void Knockback(Vector2 angle)
    {
        angle = new Vector2(60, 60);
        if (controller.m_FacingRight)
        {
            this.GetComponent<Rigidbody2D>().AddForce(angle, ForceMode2D.Force);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(-angle,ForceMode2D.Force);
        }
        
    }
    public void endDeath()
    {
        animator.SetBool("death", false);
    }
    public void endGame()
    {
        gameState.SwitchState(gameState.loseState);
    }
    public void attackTrigger()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackArea.position, AttackRadius, whatIsEnemy);

        foreach (Collider2D collider in detectedObjects)
        {
            if(collider.GetComponent<enemy1>() != null)
            {
                Debug.Log("hit");
                collider.GetComponent<enemy1>().Damage(10f);
            }
        }
    }
    public void turnOffAnim()
    {
        animator.SetBool("takeDamage", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("Attacking", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackArea.position, AttackRadius);
    }
}
