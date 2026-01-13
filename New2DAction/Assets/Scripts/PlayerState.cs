using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState : EntityState
{

    protected Player player;
    protected PlayerInputSet input;

    public PlayerState(Player player, StateMachine stateMachine, string stateName) : base(stateMachine, stateName)
    {
        this.player = player;

        rb = player.rb;
        anim = player.anim;
        input = player.inputSet;
    }

    public override void Update()
    {
        base.Update();

        HandleDash();
        HandleAttack();

    }


    private void HandleDash()
    {
        if (input.Player.Dash.WasPerformedThisFrame() && CanDash())
        {
            stateMachine.ChangeState(player.dashState);
        }
    }

    private bool CanDash()
    {
        if (!player.isGrounded && player.isTouchingWall)
            return false;

        if (stateMachine.currentState == player.dashState)
            return false;

        return true;
    }

    private void HandleAttack()
    {
        if (input.Player.Attack.WasPerformedThisFrame() && !anim.GetBool("basicattack"))
        {
            stateMachine.ChangeState(player.basicAttackState);
        }
    }


}
