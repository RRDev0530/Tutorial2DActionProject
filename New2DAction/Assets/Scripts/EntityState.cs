using UnityEngine;

public abstract class EntityState
{
    protected StateMachine stateMachine;
    protected string stateName;

    protected Animator anim;
    protected Rigidbody2D rb;

    protected float stateTime;
    public bool triggerCalled;

    public EntityState(StateMachine stateMachine, string stateName)
    {
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }
    public virtual void Enter()
    {
        anim.SetBool(stateName, true);
        triggerCalled = false;

    }

    public virtual void Update()
    {
        stateTime -= Time.deltaTime;

    }
    public virtual void Exit()
    {
        anim.SetBool(stateName, false);
    }
    public void SetAnimationFinished()
    {
        triggerCalled = true;
    }
}
