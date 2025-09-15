#nullable enable

namespace Game;

public sealed class PlayerAttackState : PlayerState
{
    public PlayerAttackState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override PlayerStateMachine PlayerStateMachine { get; }

    public override string AnimationName => "Attack";
}
