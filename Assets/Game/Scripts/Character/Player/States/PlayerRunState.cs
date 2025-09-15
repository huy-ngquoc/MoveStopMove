#nullable enable

namespace Game;

using UnityEngine;

public sealed class PlayerRunState : PlayerState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationName => "Run";

    public override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerStateEnter()
    {
        this.PerformMove(this.PlayerInputHandler.MoveInput);
    }

    protected override void OnPlayerStateUpdate()
    {
        var moveInput = this.PlayerInputHandler.MoveInput;
        if (moveInput == Vector2.zero)
        {
            this.PlayerStateMachine.SetStateToChangeTo(this.PlayerStateMachine.IdleState);
            return;
        }

        this.PerformMove(moveInput);
    }

    private void PerformMove(Vector2 moveInput)
    {
        var moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        var oldPosition = this.PlayerStateMachine.transform.position;
        var moveDistance = this.PlayerController.MoveSpeed * Time.deltaTime * moveDirection;
        var newPosition = oldPosition + moveDistance;

        var targetRotation = Quaternion.LookRotation(moveDirection);
        var newRotation = Quaternion.Slerp(this.PlayerStateMachine.transform.rotation, targetRotation, Time.deltaTime * this.PlayerController.RotationSpeed);

        var rigidbody = this.PlayerController.Rigidbody;
        rigidbody.position = newPosition;
        rigidbody.rotation = newRotation;
    }
}
