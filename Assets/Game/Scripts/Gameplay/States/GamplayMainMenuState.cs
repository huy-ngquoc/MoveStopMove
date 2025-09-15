#nullable enable

namespace Game;

public sealed class GameplayMainMenuState : GameplayState
{
    public GameplayMainMenuState(GameplayStateMachine stateMachine)
    {
        this.StateMachine = stateMachine;
    }

    public override GameplayStateMachine StateMachine { get; }

    protected override void OnGameplayStateEnter()
    {
        LevelManager.UnloadCurrentLevel();
        UiManager.ShowMainMenuPanel();
    }

    protected override void OnGameplayStateExit()
    {
        UiManager.HideMainMenuPanel();
    }
}
