#nullable enable

namespace Game;

public sealed class GameplayLoseState : GameplayState
{
    public GameplayLoseState(GameplayStateMachine stateMachine)
    {
        this.StateMachine = stateMachine;
    }

    public override GameplayStateMachine StateMachine { get; }

    protected override void OnGameplayStateEnter()
    {
        UiManager.ShowLosePanel();
    }

    protected override void OnGameplayStateExit()
    {
        UiManager.HideLosePanel();
    }
}
