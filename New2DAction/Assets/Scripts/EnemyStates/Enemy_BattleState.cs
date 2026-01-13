using UnityEngine;

public class Enemy_BattleState : EnemyState
{

    private Transform player;
    protected float lastTimeWasInBattle;
    public Enemy_BattleState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        if (player == null)
            player = enemy.player;

        if (ShouldRetreat())
        {
            RetreatFromPlayer();
            enemy.CheckFlip(DirectionToPlayer());
        }
    }

    public override void Update()
    {
        base.Update();

        anim.SetFloat("xVelocity", rb.linearVelocity.x);

        if (enemy.PlayerDectection())
            UpdateBattleTimer();

        if(BattleTimeExceeded())
            stateMachine.ChangeState(enemy.idleState);

        if (withinAttackRange() && enemy.PlayerDectection())
            stateMachine.ChangeState(enemy.attackState);
        else
            enemy.SetVelocity(enemy.battleMoveSpeed * DirectionToPlayer(), enemy.rb.linearVelocity.y);

    }

    private void UpdateBattleTimer()
    {
        lastTimeWasInBattle = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    private bool withinAttackRange() => DistanceToPlayer() <= enemy.attackRange;
    private bool ShouldRetreat() => DistanceToPlayer() <= enemy.retreatRange;
    private bool BattleTimeExceeded() => Time.time >= lastTimeWasInBattle + enemy.battleDuration;

    private void RetreatFromPlayer()
    {
        rb.linearVelocity = new Vector2(enemy.retreatJumpVelocity.x * -DirectionToPlayer(), enemy.retreatJumpVelocity.y);
    }

    private float DistanceToPlayer()
    {
        if (player == null)
            return float.MaxValue;

        return Mathf.Abs(player.position.x - enemy.transform.position.x);
    }

    private int DirectionToPlayer()
    {
        if(player == null)
            return 0;

        return player.position.x > enemy.transform.position.x ? 1 : -1;
    }


}
