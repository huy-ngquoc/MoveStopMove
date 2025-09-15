#nullable enable

namespace Game;

public abstract class GameplayState : State
{
    public abstract GameplayStateMachine StateMachine { get; }

    protected sealed override void OnStateEnter()
    {
        this.OnGameplayStateEnter();
    }

    protected sealed override void OnStateUpdate()
    {
        this.OnGameplayStateUpdate();
    }

    protected sealed override void OnStateExit()
    {
        this.OnGameplayStateExit();
    }

    protected virtual void OnGameplayStateEnter()
    {
    }

    protected virtual void OnGameplayStateUpdate()
    {
    }

    protected virtual void OnGameplayStateExit()
    {
    }
}
