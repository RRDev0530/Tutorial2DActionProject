using UnityEngine;

public class Player_MoveState : Player_OnGroundState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }
    
    public override void Update()
    {
        base.Update();

        if (player.moveInput.x == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

       player.SetVelocity(player.moveInput.x * player.movespeed, player.rb.linearVelocity.y);
       player.CheckFlip(player.moveInput.x);
    }
}
