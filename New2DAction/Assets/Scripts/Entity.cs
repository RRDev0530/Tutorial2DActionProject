using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }

    private CapsuleCollider2D capsuleCollider;

    protected StateMachine stateMachine;
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

    protected virtual void Update()
    {
        stateMachine.UpdateActiveState();
        GroundDetect();
        WallDetect();

    }

    public void SetVelocity(float velocityX, float velocityY)
    {
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
    public void SetAnimationFinished()
    {
        stateMachine.currentState.SetAnimationFinished();
    }



    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheckComponent.position, new Vector2(0, -GroundCheckDistance));
        Gizmos.DrawLine(transform.position, new Vector2(facingDir * facingChecker, 0));
    }


}
