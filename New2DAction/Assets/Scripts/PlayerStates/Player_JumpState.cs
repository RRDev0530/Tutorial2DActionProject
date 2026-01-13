using UnityEngine;

public class Player_JumpState : Player_AirState
{
    public Player_JumpState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Jump(player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.fallState);
        }
    }


}
