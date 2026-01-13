using UnityEditorInternal;
using UnityEngine;

public class Enemy_AttackState : EnemyState
{
    public Enemy_AttackState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled == true)
        {
                stateMachine.ChangeState(enemy.battleState);
        }
    }

}
