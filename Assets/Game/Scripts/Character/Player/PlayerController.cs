#nullable enable

namespace Game
{
    using UnityEngine;

    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerInputHandler), typeof(PlayerStateMachine))]
    public sealed class PlayerController : CharacterController
    {
        [Header("Player info")]

        [SerializeField]
        [Range(0.1F, 20)]
        private float moveSpeed = 5;

        [SerializeField]
        [Range(0.1F, 90)]
        private float rotationSpeed = 20;

        [SerializeReference]
        [ResolveComponentFromSelf]
        private PlayerInputHandler inputHandler = null!;

        [SerializeReference]
        [ResolveComponentFromSelf]
        private PlayerStateMachine playerStateMachine = null!;

        public float MoveSpeed => this.moveSpeed;

        public float RotationSpeed => this.rotationSpeed;

        public PlayerInputHandler InputHandler => this.inputHandler;

        public PlayerStateMachine PlayerStateMachine => this.playerStateMachine;

        public override CharacterStateMachine CharacterStateMachine => this.playerStateMachine;

        protected override void OnCharacterControllerAwake()
        {
            GameplayManager.GameStarted += this.GameplayManager_GameStarted;
            GameplayManager.PlayerWin += this.GameplayManager_PlayerWin;
            GameplayManager.PlayerLose += this.GameplayManager_PlayerLose;
        }

        protected override void OnCharacterControllerDestroy()
        {
            GameplayManager.GameStarted -= this.GameplayManager_GameStarted;
            GameplayManager.PlayerWin -= this.GameplayManager_PlayerWin;
            GameplayManager.PlayerLose -= this.GameplayManager_PlayerLose;
        }

        private void GameplayManager_GameStarted()
        {
            this.PlayerStateMachine.SetStateToChangeTo(this.PlayerStateMachine.IdleState);
        }

        private void GameplayManager_PlayerWin()
        {
            this.PlayerStateMachine.SetStateToChangeTo(this.PlayerStateMachine.WinState);
        }

        private void GameplayManager_PlayerLose()
        {
            this.PlayerStateMachine.SetStateToChangeTo(this.PlayerStateMachine.DeadState);
        }
    }
}
