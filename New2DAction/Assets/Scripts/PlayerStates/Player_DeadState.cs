using UnityEngine;

public class Player_DeadState : PlayerState
{
    public Player_DeadState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        input.Disable();
        rb.simulated = false;
        
    }
}
