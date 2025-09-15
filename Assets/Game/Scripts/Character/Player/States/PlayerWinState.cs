#nullable enable

namespace Game;

public sealed class PlayerWinState : PlayerState
{
    public PlayerWinState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override PlayerStateMachine PlayerStateMachine { get; }

    public override string AnimationName => "Idle";
}
