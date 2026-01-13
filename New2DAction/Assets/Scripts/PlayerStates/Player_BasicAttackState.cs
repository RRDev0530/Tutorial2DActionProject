using UnityEngine;

public class Player_BasicAttackState : PlayerState
{
    public Player_BasicAttackState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    float attackVelocityTimer;
    float lastTimeAttacked;

    private int currentComboIndex = 1;
    private int maxCombo = 3;
    const int startComboIndex = 1;

    private int attackDir;

    private bool canQueueNextCombo;

    public override void Enter()
    {
        base.Enter();
        canQueueNextCombo = false;

        ResetComboIndexIfNeeded();
        HandleAttackDirection();
        ApplyAttackVelocity();

        anim.SetInteger("comboIndex", currentComboIndex);

    }

    private void HandleAttackDirection()
    {
        attackDir = player.moveInput.x != 0 ? ((int)player.moveInput.x) : player.facingDir;
        player.CheckFlip(attackDir);
    }

    public override void Update()
    {
        base.Update();

        attackVelocityTimer -= Time.deltaTime;

        if (attackVelocityTimer < 0)
        {
            player.SetVelocity(0, player.rb.linearVelocity.y);
        }

        HandleQueueAttack();
        HandleStateChange();

    }

    private void HandleStateChange()
    {
        if (triggerCalled)
        {
            if (canQueueNextCombo)
            {
                anim.SetBool("basicattack", false);
                player.EnterAttackStateWithDelay();
            }
            else
                stateMachine.ChangeState(player.idleState);

        }
    }

    private void HandleQueueAttack()
    {
        if (input.Player.Attack.WasPressedThisFrame())
        {
            QueueNextAtttack();
        }
    }

    public override void Exit()
    {
        base.Exit();
        currentComboIndex++;

        lastTimeAttacked = Time.time;
    }

    private void ApplyAttackVelocity()
    {
        attackVelocityTimer = player.attackVelocityTime;
        player.SetVelocity(attackDir * player.attackVelocity.x, player.attackVelocity.y);
    }   

    public void ResetComboIndexIfNeeded()
    {

        if (currentComboIndex > maxCombo)
        { 
            currentComboIndex = startComboIndex;
        }

        if (Time.time > lastTimeAttacked + player.attackResetDuration) 
        {
            currentComboIndex = startComboIndex;
        }
    }
    
    private void QueueNextAtttack()
    {
        if (currentComboIndex < maxCombo)
            canQueueNextCombo = true;

    }

}
