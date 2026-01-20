using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    
    public Enemy_DeadState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        stateMachine.SwitchOffStateMachine();

    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            anim.enabled = false;

            GameObject.Destroy(enemy.gameObject);
        }
        
    }


}
