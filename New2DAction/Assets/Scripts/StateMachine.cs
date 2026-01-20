using UnityEngine;

public class StateMachine
{
    public EntityState currentState{  get; private set; }
    private bool canChangeState;

    public void Initialize(EntityState startingState)
    {
        canChangeState = true;
        currentState = startingState;
        this.currentState.Enter();
    }
    public void ChangeState(EntityState nextState)
    {
        if (!canChangeState)
            return;

        this.currentState.Exit();
        currentState = nextState;
        this.currentState.Enter();
    }
    public void UpdateActiveState()
    {
        currentState.Update();
    }

    public void SwitchOffStateMachine()
    {
        canChangeState = false;
    }

}
