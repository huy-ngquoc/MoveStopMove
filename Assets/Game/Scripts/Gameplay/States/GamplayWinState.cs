#nullable enable

namespace Game;

public sealed class GameplayWinState : GameplayState
{
    public GameplayWinState(GameplayStateMachine stateMachine)
    {
        this.StateMachine = stateMachine;
    }

    public override GameplayStateMachine StateMachine { get; }

    protected override void OnGameplayStateEnter()
    {
        var newLevelIdx = GameManager.CurrentLevelIdx;
        ++newLevelIdx;
        if (newLevelIdx < LevelManager.AmountLevels)
        {
            GameManager.CurrentLevelIdx = newLevelIdx;
        }

        UiManager.ShowWinPanel();
    }

    protected override void OnGameplayStateExit()
    {
        UiManager.HideWinPanel();
    }
}
