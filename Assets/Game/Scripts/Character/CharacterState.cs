#nullable enable

namespace Game;

using UnityEngine;

public abstract class CharacterState : State
{
    public abstract CharacterStateMachine CharacterStateMachine { get; }

    public CharacterController CharacterController => this.CharacterStateMachine.CharacterController;

    public Rigidbody Rigidbody => this.CharacterController.Rigidbody;

    public abstract string AnimationName { get; }

    protected sealed override void OnStateEnter()
    {
        this.CharacterController.Animator.SetTrigger(this.AnimationName);

        this.OnCharacterStateEnter();
    }

    protected sealed override void OnStateUpdate()
    {
        this.OnCharacterStateUpdate();
    }

    protected sealed override void OnStateExit()
    {
        this.CharacterController.Animator.ResetTrigger(this.AnimationName);

        this.OnCharacterStateExit();
    }

    protected virtual void OnCharacterStateEnter()
    {
    }

    protected virtual void OnCharacterStateUpdate()
    {
    }

    protected virtual void OnCharacterStateExit()
    {
    }
}
