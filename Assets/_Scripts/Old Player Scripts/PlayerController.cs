using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IKnockbackable
{
    [Header("Player Stats")]
    public float playerHealth = 80f;

    public GameStateManager gameState;

    private PlayerActions playerControls;
    private Vector2 playerVelocity;
    private bool groundedPlayer;
    private Vector2 movementInput;
    private int facingDirection;
    private float intensity;

    //public PlayerActionInputs playerControls;

    [Header("Audio")]
    [SerializeField] AudioSource heal;


    //input actions here
    private InputAction move;
    private InputAction attack;
    private InputAction jump;
    private InputAction winGame;
    private InputAction loseGame;
    private InputAction areaSlash;
    private InputAction tripleSlash;
    private InputAction dash;


    //Componant references here
    public Rigidbody2D rb;
    public Animator animator;
    public CharacterController2D controller;

    private bool isJump;

    //Place the skill bools here
    public bool areaSlashBool;
    public bool tripleSlashBool;
    public bool dashBool;
    public bool isDashing;

    //player values here
    [SerializeField] private float playerSpeed = 2.0f;

    public GameObject healthBarUI;


    //Serialize Field references here
    [Header("Attack Range")]
    [SerializeField] float AttackRadius;
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] Transform attackArea;
    [SerializeField] float areaSlashAttackRadius;
    [SerializeField] float tripleSlashRadius;
    [SerializeField] Transform areaSlashRange;
    [SerializeField] Transform tripleSlashRange;
    [SerializeField] CooldownScript cooldownHandler;
    [SerializeField] CharacterController2D controller2d;
    public D_Entity entityData;

    private void Awake()
    {
        playerControls = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
        //playerControls = new PlayerActionInputs();
        isJump = false;
        areaSlashBool = true;
        tripleSlashBool = true;
        dashBool = true;
        intensity = 1;
    }
    private void OnEnable()
    {
        move = playerControls.PlayerAction.Move;
        move.Enable();

        attack = playerControls.PlayerAction.Attack;
        attack.Enable();
        attack.performed += Attack;

        areaSlash = playerControls.PlayerAction.AreaSlash;
        areaSlash.Enable();
        areaSlash.performed += AreaSlash;

        tripleSlash = playerControls.PlayerAction.TripleSlash;
        tripleSlash.Enable();
        tripleSlash.performed += TripleSlash;

        jump = playerControls.PlayerAction.Jump;
        jump.Enable();
        jump.performed += Jump;
        //playerInput.Enable();

        dash = playerControls.PlayerAction.Dash;
        dash.Enable();
        dash.performed += Dash;

        winGame = playerControls.PlayerAction.WinGame;
        winGame.Enable();
        winGame.performed += Win;
        animator.SetBool("canTakeDamage", true);
    }
    private void OnDisable()
    {
        move.Disable();
        attack.Disable();
        jump.Disable();
        tripleSlash.Disable();
        areaSlash.Disable();
        animator.SetBool("canTakeDamage", false);
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        //movementInput = move.PlayerMain.Move.ReadValue<Vector2>();
        movementInput = move.ReadValue<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(movementInput.x));
        if(gameObject.transform.rotation.y == 0)
        {
            facingDirection = 1;
        }
        else
        {
            facingDirection = -1;
        }
    }
    private void FixedUpdate()
    {
        if(isDashing && movementInput == Vector2.zero)
        {
            controller.Move(facingDirection * playerSpeed * Time.fixedDeltaTime * 2, false, isJump);
            return;
        }
        else if(isDashing)
        {
            controller.Move(movementInput.x * playerSpeed * Time.fixedDeltaTime * 2, false, isJump);
        }
        //rb.velocity = new Vector2(movementInput.x * playerSpeed, movementInput.y * playerSpeed);
        controller.Move(movementInput.x * playerSpeed * Time.fixedDeltaTime, false, isJump);
        isJump = false;
    }
    private void Attack(InputAction.CallbackContext context)
    {
        animator.SetBool("Attacking", true);
    }
    private void Dash(InputAction.CallbackContext context)
    {
        if (dashBool)
        {

            handleDash();
        }       
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (animator.GetBool("Attacking") == false)
        {
            isJump = true;
            animator.SetBool("isJumping", true);
        }
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
        if (!animator.GetBool("takeDamage") && !animator.GetBool("death") && animator.GetBool("canTakeDamage"))
        {
            OnDisable();
            playerHealth -= 10;
            GameObject.Find("HealthBarUI").GetComponent<Bar>().SetHealth((int)playerHealth);
            animator.SetBool("takeDamage", true);
            GameObject.Find("PlayerTakeDamageAudio").GetComponent<AudioSource>().Play();
            OnEnable();
            EndAttack();
        }
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            Death();
        }
    }
    public void healPlayer(int amount)
    {
        if (playerHealth < 50f)
        {
            playerHealth += amount;
            if(playerHealth > 50f)
            {
                playerHealth = 50f;
            }
            GameObject.Find("HealthBarUI").GetComponent<Bar>().SetHealth((int)playerHealth);
            //heal.play()
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
            this.GetComponent<Rigidbody2D>().AddForce(-angle, ForceMode2D.Force);
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
        AttackRadius = 1.2f;
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackArea.position, AttackRadius, whatIsEnemy);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.GetComponent<enemy1>() != null)
            {
                collider.GetComponent<enemy1>().Damage(PlayerData.CalculatePlayerDamage("basicAttack"), PlayerData.didCrit);
            }
        }
    }
    public void slashTrigger()
    {
        AttackRadius = 1.9f;
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackArea.position, AttackRadius, whatIsEnemy);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.GetComponent<enemy1>() != null)
            {
                collider.GetComponent<enemy1>().Damage(PlayerData.CalculatePlayerDamage("slashAttack"), PlayerData.didCrit);
            }
        }
    }
    public void areaSlashTrigger()
    {
        AttackRadius = 5f;
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(areaSlashRange.position, AttackRadius, whatIsEnemy);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.GetComponent<enemy1>() != null)
            {
                collider.GetComponent<enemy1>().Damage(PlayerData.CalculatePlayerDamage("AreaSlash"), PlayerData.didCrit);
                healPlayer((int)PlayerData.CalculatePlayerDamage("AreaSlash") / 20);
            }
        }
    }
    private void AreaSlash(InputAction.CallbackContext context)
    {
        if (areaSlashBool)
        {
            animator.SetBool("areaSlash", true);
        }
        else
        {
            Debug.Log("areaSlash On Cooldown");
        }
    }
    public void EndAreaSlash()
    {
        animator.SetBool("areaSlash", false);
        areaSlashBool = false;
        StartCoroutine(cooldownHandler.areaSlashCooldown(5));
    }

    public void enableAreaSlash()
    {
        areaSlashBool = true;
    }

    public void tripleSlashTrigger1()
    {
        AttackRadius = 1.5f;
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(tripleSlashRange.position, AttackRadius, whatIsEnemy);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.GetComponent<enemy1>() != null)
            {
                collider.GetComponent<enemy1>().Damage(PlayerData.CalculatePlayerDamage("TripleSlash"), PlayerData.didCrit);
            }
        }
    }
    public void tripleSlashTrigger2()
    {
        AttackRadius = 3f;
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(tripleSlashRange.position, AttackRadius, whatIsEnemy);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.GetComponent<enemy1>() != null)
            {
                collider.GetComponent<enemy1>().Damage(PlayerData.CalculatePlayerDamage("TripleSlash"), PlayerData.didCrit);
            }
        }
    }
    private void TripleSlash(InputAction.CallbackContext context)
    {

        if (tripleSlashBool)
        {
            animator.SetBool("tripleSlash", true);
        }
        else
        {
            Debug.Log("tripleSlash On Cooldown");
        }
    }
    public void EndTripleSlash()
    {
        animator.SetBool("tripleSlash", false);
        tripleSlashBool = false;
        StartCoroutine(cooldownHandler.tripleSlashCooldown(7));
    }

    public void enableTripleSlash()
    {
        tripleSlashBool = true;
    }

    public void handleDash()
    {
        OnDisable();
        isDashing = true;
        animator.SetBool("isJumping", false);
        animator.SetBool("dash", true);
    }
    public void endDash()
    {
        animator.SetBool("dash", false);
        dashBool = false;
        isDashing = false;
        OnEnable();
        StartCoroutine(cooldownHandler.dashCooldown(2));
    }
    public void turnOffAnim()
    {
        animator.SetBool("takeDamage", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("Attacking", false);
        animator.SetBool("tripleSlash", false);
        animator.SetBool("areaSlash", false);
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(attackArea.position, AttackRadius);
        //Gizmos.DrawWireSphere(areaSlashRange.position, areaSlashAttackRadius);
        //Gizmos.DrawWireSphere(tripleSlashRange.position, tripleSlashRadius);
        Gizmos.DrawLine(gameObject.transform.position,
                                     gameObject.transform.position + (Vector3)(Vector2.right * (1) * PlayerData.dashDistance));
    }
    public void enableSkills(string name)
    {
        animator.SetBool(name, true);
    }
    public void disableSkills(string name)
    {
        animator.SetBool(name, false);
    }
    public void shakeCam(float duration)
    {
        CameraShake.Instance.shake(intensity, duration);
    }
    public void changeIntensity(float amount)
    {
        intensity = amount;
    }
}
