#nullable enable

namespace Game;

public sealed class GameplayPlayingState : GameplayState
{
    public GameplayPlayingState(GameplayStateMachine stateMachine)
    {
        this.StateMachine = stateMachine;
    }

    public override GameplayStateMachine StateMachine { get; }

    protected override void OnGameplayStateEnter()
    {
        if (!LevelManager.LoadLevel(GameManager.CurrentLevelIdx))
        {
            this.StateMachine.SetStateToChangeTo(this.StateMachine.MainMenuState);
        }

        UiManager.ShowInGamePanel();
    }

    protected override void OnGameplayStateExit()
    {
        UiManager.HideInGamePanel();
    }
}
