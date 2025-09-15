#nullable enable

namespace Game;
public abstract class PlayerState : CharacterState
{
    public PlayerController PlayerController => this.PlayerStateMachine.PlayerController;

    public PlayerInputHandler PlayerInputHandler => this.PlayerController.InputHandler;

    public abstract PlayerStateMachine PlayerStateMachine { get; }

    public sealed override CharacterStateMachine CharacterStateMachine => this.PlayerStateMachine;

    protected sealed override void OnCharacterStateEnter()
    {
        this.OnPlayerStateEnter();
    }

    protected sealed override void OnCharacterStateUpdate()
    {
        this.OnPlayerStateUpdate();
    }

    protected sealed override void OnCharacterStateExit()
    {
        this.OnPlayerStateExit();
    }

    protected virtual void OnPlayerStateEnter()
    {
    }

    protected virtual void OnPlayerStateUpdate()
    {
    }

    protected virtual void OnPlayerStateExit()
    {
    }
}
