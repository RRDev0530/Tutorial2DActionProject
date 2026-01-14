using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    
    public Enemy_DeadState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Update()
    {
        base.Update();

    }
    public override void Exit() 
    {
        base.Exit();

        anim.enabled = false;

        GameObject.Destroy(enemy.gameObject);
    }


}
