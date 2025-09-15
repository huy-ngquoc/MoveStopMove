#nullable enable

namespace Game;

public sealed class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override PlayerStateMachine PlayerStateMachine { get; }

    public override string AnimationName => "Idle";
}
