using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class Player : Entity
{
    public PlayerInputSet inputSet { get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Player_JumpState jumpState { get; private set; }
    public Player_FallState fallState { get; private set; }
    public Player_WallSlide wallSlideState { get; private set; }
    public Player_WallJump wallJumpState { get; private set; }
    public Player_DashState dashState { get; private set; }
    public Player_BasicAttackState basicAttackState { get; private set; }

    private Coroutine queuedAttackCo;

    [Header("Player Stats")]
    [SerializeField] public float movespeed;
    [SerializeField] public Vector2 jumpForce;
    [SerializeField] public Vector2 wallJumpForce;
    [SerializeField] public Vector2 attackVelocity;
    [SerializeField] public float attackResetDuration;
    [SerializeField] public float attackVelocityTime;
    [Range(0, 1)]
    [SerializeField] public float wallSlideSpeed;
    [SerializeField] public float dashSpeed;
    [SerializeField] public float dashTime;

    public Vector2 moveInput { get; private set; }
    public Vector2 jumpInput { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        inputSet = new PlayerInputSet();

        idleState = new Player_IdleState(this, stateMachine, "idle");
        moveState = new Player_MoveState(this, stateMachine, "move");
        jumpState = new Player_JumpState(this, stateMachine, "jumpfall");
        fallState = new Player_FallState(this, stateMachine, "jumpfall");
        wallSlideState = new Player_WallSlide(this, stateMachine, "wallslide");
        wallJumpState = new Player_WallJump(this, stateMachine, "jumpfall");
        dashState = new Player_DashState(this, stateMachine, "dash");
        basicAttackState = new Player_BasicAttackState(this, stateMachine, "basicattack");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    private void OnEnable()
    {
        inputSet.Enable();

        inputSet.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputSet.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

    }
    private void OnDisable()
    {
        inputSet.Disable();

    }

    public void EnterAttackStateWithDelay()
    {
        if (queuedAttackCo != null)
        {
            StopCoroutine(queuedAttackCo);
        }

        queuedAttackCo = StartCoroutine(EnterAttackStateWithDelayCo());
    }
    private IEnumerator EnterAttackStateWithDelayCo()
    {
        yield return new WaitForEndOfFrame();
        stateMachine.ChangeState(basicAttackState);

    }
}

