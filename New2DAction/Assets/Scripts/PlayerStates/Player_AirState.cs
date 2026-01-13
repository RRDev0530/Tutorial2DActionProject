using UnityEngine;

public class Player_AirState : PlayerState
{
    public Player_AirState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();

        anim.SetFloat("VelocityY", player.rb.linearVelocity.y);

        player.SetVelocity(player.moveInput.x * player.movespeed, player.rb.linearVelocity.y);
        player.CheckFlip(player.moveInput.x);

        if(player.isTouchingWall)
        {
            stateMachine.ChangeState(player.wallSlideState);
        }


    }

}
