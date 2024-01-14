using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class E_Entity : MonoBehaviour
{
    public E_FiniteStateMachine stateMachine;

    public int facingDirection { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public Animator anim { get; private set; }

    public E_AnimationToStateMachine animationToStateMachine { get; private set; }

    public Bar barTool { get; private set; }

    private float currentHealth;
    

    private int lastDamageDirection;

    protected bool isDead;


    private Vector2 velocityWorkspace;

    public D_Entity entityData;

    [SerializeField] private LevelBehavior displayText;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private GameObject damagePopupTransform;
    [SerializeField] private GameObject canvas;

    public bool inDeathState = false;
    public virtual void Start()
    {
        //default
        rb = GetComponent<Rigidbody2D>();
        Physics.IgnoreLayerCollision(6,6, true);

        anim = GetComponent<Animator>();
        animationToStateMachine = GetComponent<E_AnimationToStateMachine>();
        barTool = GetComponent<Bar>();
        stateMachine = new E_FiniteStateMachine();
        //--------------------------------------------------------------------------------------------------------------------------------------------

        //scale the health of enemies based on player level
        E_StaticData.enemyLevel = LevelUIController.getLevel() +1;
        Debug.Log(E_StaticData.enemyLevel);

        //set health
        currentHealth = 30f * E_StaticData.enemyLevel;
        barTool.setMaxHealth((int)currentHealth);
        barTool.SetHealth((int)currentHealth);

        //display level
        displayText.setDisplayLevel((int)E_StaticData.enemyLevel);


        facingDirection = 1;
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
        if (inDeathState)
        {
            Destroy(rb);
            Destroy(this.GetComponent<BoxCollider2D>());
            Debug.Log("kill the rb");
            inDeathState= false;
            
        }
        
        //canvas.transform.rotation = Quaternion.Euler(0.0f, 0.0f, this.transform.parent.rotation.y * -1.0f);
        

    }
    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;

    }
    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }
    public virtual bool CheckLedge()
    {
        
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);

    }
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeAttackDistance, entityData.whatIsPlayer);
    }
    public virtual void Flip()
    {
        facingDirection *= -1;
        this.gameObject.transform.Rotate(0, 180, 0);
    }

    public virtual void DamageHop()
    {
        velocityWorkspace.y = 2f;
        if(GameObject.Find("Player").GetComponent<Transform>().position.x - gameObject.transform.position.x < 0)
        {
            velocityWorkspace.x = 1f;
        }
        else
        {
            velocityWorkspace.x = -1f;
        }
        rb.velocity = velocityWorkspace;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }

    public virtual void Damage(float amount, bool crit)
    {

        //Instantiate(entityData.hitParticle, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        this.GetComponent<E_DamagePopUp>().showDamageDelt(damagePopupTransform.transform.position, (int)amount, crit);


        currentHealth -= amount;

        barTool.SetHealth((int)currentHealth);

        if(GameObject.Find("Player").GetComponent<Transform>().position.x - gameObject.transform.position.x < 0 && facingDirection >0)
        {
            Flip();
        }
        if(GameObject.Find("Player").GetComponent<Transform>().position.x - gameObject.transform.position.x > 0 && facingDirection < 0)
        {
            Flip();
        }

        if(currentHealth <= 0) {
            isDead = true;
        }
        if(!isDead)
        {
            DamageHop();
        }

    }
    public void remove()
    {
        dropItem();
    }
    public void dropItem()
    {
        if (Random.Range(0, 10) == 5)
        {
            Instantiate(entityData.heal, new Vector3(this.transform.position.x, this.transform.position.y+1, 0f), this.transform.rotation);
        }
        Destroy(gameObject);
    
    }

    
}
