#nullable enable

namespace Game;

using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState = null!;
    private State? stateToChangeTo = null;

    protected abstract State InitialState { get; }

    protected void SetStateToChangeTo(State newState)
    {
        this.stateToChangeTo = newState;
    }

    protected void Awake()
    {
        this.currentState = this.InitialState;
    }

    protected void Start()
    {
        this.currentState.Enter();
    }

    protected void Update()
    {
        if (this.stateToChangeTo == null)
        {
            this.currentState.Update();
            return;
        }

        do
        {
            this.currentState.Exit();
            this.currentState = this.stateToChangeTo;
            this.stateToChangeTo = null;
            this.currentState.Enter();
        }
        while (this.stateToChangeTo != null);
    }

    protected void OnDestroy()
    {
        this.currentState.Exit();
    }
}
