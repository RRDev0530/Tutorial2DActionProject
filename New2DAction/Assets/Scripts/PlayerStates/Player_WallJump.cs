using UnityEngine;

public class Player_WallJump : PlayerState
{
    public Player_WallJump(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    float redirectoionTime = 0.15f;
    public override void Enter()
    {
        base.Enter();
        player.Flip();
        player.Jump(player.wallJumpForce * new Vector2(player.facingDir , 1f));

        stateTime = redirectoionTime;

    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocity.y < 0 || stateTime <= 0)
        {
            stateMachine.ChangeState(player.fallState);
        }

        if (player.isTouchingWall) 
        {
                stateMachine.ChangeState(player.wallSlideState);
        }
        

    }

}
