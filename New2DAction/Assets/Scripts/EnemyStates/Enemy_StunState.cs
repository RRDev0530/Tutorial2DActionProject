using UnityEngine;

public class Enemy_StunState : EnemyState
{
    public Enemy_StunState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(0f,0f);
        stateTime = 1f; // Set stun duration to 1 second

    }

    public override void Update()
    {
        base.Update();
        if (stateTime <= 0)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

}
