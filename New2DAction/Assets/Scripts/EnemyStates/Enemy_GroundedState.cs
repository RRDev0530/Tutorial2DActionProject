using UnityEngine;

public class Enemy_GroundedState : EnemyState
{
    public Enemy_GroundedState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }

    //move to battle state when player in sight range
    public override void Update()
    {
        base.Update();
        if (enemy.PlayerDectection() == true)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }

}
