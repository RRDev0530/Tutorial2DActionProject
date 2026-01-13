using UnityEngine;

public class StateMachine
{
    public EntityState currentState{  get; private set; }

    public void Initialize(EntityState startingState)
    {
        currentState = startingState;
        this.currentState.Enter();
    }
    public void ChangeState(EntityState nextState)
    {
        this.currentState.Exit();
        currentState = nextState;
        this.currentState.Enter();
    }
    public void UpdateActiveState()
    {
        currentState.Update();
    }

}
