#nullable enable

namespace Game;

using UnityEngine;

public sealed class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationName => "Idle";

    public override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerStateUpdate()
    {
        var moveInput = this.PlayerInputHandler.MoveInput;
        if (moveInput != Vector2.zero)
        {
            this.PlayerStateMachine.SetStateToChangeTo(this.PlayerStateMachine.RunState);
        }
    }
}
