using UnityEngine;

public class Enemy_IdleState : Enemy_GroundedState
{
    public Enemy_IdleState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTime = 2;
    }

    public override void Update()
    {
        base.Update();
        if (stateTime < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }

    }

}
