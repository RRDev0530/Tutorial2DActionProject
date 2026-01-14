using UnityEngine;

public class Enemy : Entity
{
    public Enemy_IdleState idleState;
    public Enemy_MoveState moveState;
    public Enemy_AttackState attackState;
    public Enemy_BattleState battleState;
    public Enemy_DeadState deadState;

    [Header("Enemy Stats")]
    [SerializeField] public float movespeed;

    [Header("Player Detection")]
    [SerializeField] public LayerMask whatIsPlayer;
    [SerializeField] public Transform playerDetector;
    [SerializeField] public float sightRange;
    public Transform player;

    [Header("Battle Details")]
    public float attackRange;
    public float retreatRange;
    public float battleMoveSpeed;
    public Vector2 retreatJumpVelocity;
    public float battleDuration;

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    public void TryToEnterBattleState(Transform damageDealer)
    {
        if (stateMachine.currentState == battleState || stateMachine.currentState == attackState)
            return;

        player = damageDealer;
        stateMachine.ChangeState(battleState);
    }

    public RaycastHit2D PlayerDectection()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerDetector.position, Vector2.right * facingDir, sightRange, whatIsPlayer | whatIsGround);

        if (hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
            return default;

        player = hit.transform;
        return hit; 

    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerDetector.position, playerDetector.position + Vector3.right * facingDir * sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerDetector.position, playerDetector.position + Vector3.right * facingDir * attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(playerDetector.position, playerDetector.position + Vector3.right * facingDir * retreatRange);

    }


}
