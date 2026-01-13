using UnityEngine;

public class Player_FallState : Player_AirState
{
    public Player_FallState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {

    }

    public override void Update()
    {
        base.Update();
        if (player.isGrounded)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
