using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public float playerHealth = 4f;


    private Player playerControls;
    private Vector2 playerVelocity;
    private bool groundedPlayer;
    private Vector2 movementInput;

    //public PlayerActionInputs playerControls;

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
   // [SerializeField] private float jumpHeight = 1.0f;
   // [SerializeField] private float gravityValue = -9.81f;

    private void Awake()
    {
        playerControls = new Player();
        //playerControls = new PlayerActionInputs();
        isJump = false;
        
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
        //playerInput.Disable();
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
        playerHealth -=1;

    }
    /*groundedPlayer = player.isGrounded;
        if (groundedPlayer && playerVelocity.y< 0)
        {
            playerVelocity.y = 0f;
        }
Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
Vector3 move = new Vector3(movementInput.x, 0, 0);
controller.Move(move * Time.deltaTime * playerSpeed);

if (move != Vector3.zero)
{
    gameObject.transform.forward = move;

}

// Changes the height position of the player..
if (playerInput.PlayerMain.Jump.triggered && groundedPlayer)
{
    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
}

playerVelocity.y += gravityValue * Time.deltaTime;
controller.Move(playerVelocity * Time.deltaTime);*/
}
