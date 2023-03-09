using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Entity : MonoBehaviour, IDamagable
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

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;

    public virtual void Start()
    {
        facingDirection = 1;

        rb = GetComponent<Rigidbody2D>();
        Physics.IgnoreLayerCollision(6,6, true);

        anim = GetComponent<Animator>();
        animationToStateMachine = GetComponent<E_AnimationToStateMachine>();
        barTool = GetComponent<Bar>();
        stateMachine = new E_FiniteStateMachine();

        currentHealth = entityData.maxHealth;
        barTool.setMaxHealth((int)entityData.maxHealth);
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();

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
        transform.Rotate(0f, 180f, 0f);
    }

    public virtual void DamageHop()
    {
        velocityWorkspace.y = 2f;
        rb.velocity = velocityWorkspace;
    }
    /*public virtual void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;

        DamageHop(entityData.damageHopSpeedx, entityData.damageHopSpeedy);

        if(attackDetails.position.x > transform.position.x)
        {
            lastDamageDirection = -1;
        }
        else
        {
            lastDamageDirection = 1;
        }
    }*/

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }

    public virtual void Damage(float amount)
    {

        //Instantiate(entityData.hitParticle, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        currentHealth -= amount;
        barTool.SetHealth((int)currentHealth);

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
        this.gameObject.SetActive(false);
    }
    public void dropItem()
    {
        if (Random.Range(0, 7) == 6)
        {
            Instantiate(entityData.heal, new Vector3(this.transform.position.x, this.transform.position.y+1, 0f), this.transform.rotation);
        }
    
    }

}
