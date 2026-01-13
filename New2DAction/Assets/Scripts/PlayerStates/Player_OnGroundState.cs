using UnityEngine;
using UnityEngine.Windows;

public class Player_OnGroundState : PlayerState
{
    public Player_OnGroundState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }

        if (input.Player.Jump.WasPerformedThisFrame())
        {
            stateMachine.ChangeState(player.jumpState);
        }


    }


}
