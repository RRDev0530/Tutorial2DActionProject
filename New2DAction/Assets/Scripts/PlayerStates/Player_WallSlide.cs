using UnityEngine;

public class Player_WallSlide : PlayerState
{
    public Player_WallSlide(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();

        if(player.moveInput.y < 0)
        {
            player.SetVelocity(player.moveInput.x, rb.linearVelocity.y);
        }
        else
        {
            player.SetVelocity(player.moveInput.x, rb.linearVelocity.y * player.wallSlideSpeed);
        }

        if(!player.isTouchingWall || player.isGrounded)
        {
            stateMachine.ChangeState(player.fallState);
        }

        if (rb.linearVelocity.y >=0 && player.isGrounded)
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (player.inputSet.Player.Jump.WasPerformedThisFrame())
        {
            stateMachine.ChangeState(player.wallJumpState);
        }

    }
}
