using UnityEngine;

public class Player_DashState : PlayerState
{
    public Player_DashState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTime = player.dashTime;

    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.facingDir * player.dashSpeed, 0f);

        if (stateTime <= 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, rb.linearVelocityY);
    }
}
