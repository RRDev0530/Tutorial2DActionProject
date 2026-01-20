using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    private CapsuleCollider2D capsuleCollider;
    public StateMachine stateMachine;
    public Animator anim { get; private set; }

    private bool facingRight = true;
    [Range(-1, 1)]
    [SerializeField] public int facingDir;
    [Range(0, 10f)]
    [SerializeField] private float facingChecker;
    public bool isGrounded = true;
    public bool isTouchingWall = false;


    [Header("Checker")]
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private float WallChecker;
    [SerializeField] private Transform GroundCheckComponent;

    private Coroutine KnockbackCo;
    public bool isKnockback; 

    protected virtual void Awake()
    {
        this.stateMachine = new StateMachine();

        capsuleCollider = GetComponent<CapsuleCollider2D>();

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    protected virtual void Start()
    {

    }

    public virtual void EntityDeath()
    {

    }

    public void RecieveKnockback(Vector2 knockback, float duration)
    {
        if (KnockbackCo != null)
            StopCoroutine(KnockbackCo);

        KnockbackCo = StartCoroutine(KnockbackCoroutine(knockback,duration));
    }

    private IEnumerator KnockbackCoroutine(Vector2 knockback, float duration)
    {
        isKnockback = true;
        rb.linearVelocity = knockback;
        Debug.Log("Knockback applied: " + knockback);

        yield return new WaitForSeconds(duration);

        rb.linearVelocity = Vector2.zero;
        isKnockback = false;
    }

    protected virtual void Update()
    {
        stateMachine.UpdateActiveState();
        GroundDetect();
        WallDetect();

    }

    public void SetVelocity(float velocityX, float velocityY)
    {
        if (isKnockback)
            return;

        rb.linearVelocity = new Vector2(velocityX, velocityY);
        CheckFlip(velocityX); 
    }

    public void CheckFlip(float velocityX)
    {
        if (velocityX > 0 && !facingRight)
        {
            Flip();
        }
        else if (velocityX < 0 && facingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
        facingDir *= -1;
    }

    public void Jump(Vector2 Force)
    {
        rb.linearVelocity = Force;
    }



    public void GroundDetect()
    {
        isGrounded = Physics2D.Raycast(GroundCheckComponent.position, Vector2.down, GroundCheckDistance, whatIsGround);
    }

    public void WallDetect()
    {
        isTouchingWall = Physics2D.Raycast(transform.position + new Vector3(0, capsuleCollider.size.y / 2), new Vector2(facingDir, 0), capsuleCollider.size.x / 2, whatIsGround);
    }
    public void SetAttackAnimationFinished()
    {
        stateMachine.currentState.SetAnimationFinished();
    }

    public void SetDeadAnimationFinished()
    {
        stateMachine.currentState.SetAnimationFinished();
    }



    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheckComponent.position, new Vector2(0, -GroundCheckDistance));
        Gizmos.DrawLine(transform.position, new Vector2(facingDir * facingChecker, 0));
    }


}
