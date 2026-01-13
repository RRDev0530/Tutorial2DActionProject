using UnityEngine;

public class Enemy_MoveState : Enemy_GroundedState
{
    public Enemy_MoveState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        if(!enemy.isGrounded || enemy.isTouchingWall)
        enemy.Flip();
    }
    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.movespeed * enemy.facingDir , enemy.rb.linearVelocity.y);

        if (!enemy.isGrounded || enemy.isTouchingWall)
        {
            stateMachine.ChangeState(enemy.idleState);

        }
            

    }


}
