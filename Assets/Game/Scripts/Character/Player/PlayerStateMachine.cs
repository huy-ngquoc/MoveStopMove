#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerStateMachine : CharacterStateMachine
    {
        [SerializeField]
        [ResolveComponentFromSelf]
        private PlayerController playerController = null!;

        public PlayerStateMachine()
        {
            this.IdleState = new PlayerIdleState(this);
            this.RunState = new PlayerRunState(this);
            this.AttackState = new PlayerAttackState(this);
            this.WinState = new PlayerWinState(this);
            this.DeadState = new PlayerDeadState(this);
        }

        public PlayerIdleState IdleState { get; }

        public PlayerRunState RunState { get; }

        public PlayerAttackState AttackState { get; }

        public PlayerWinState WinState { get; }

        public PlayerDeadState DeadState { get; }

        public PlayerController PlayerController => this.playerController;

        public override CharacterController CharacterController => this.playerController;

        protected override State InitialState => this.IdleState;

        public void SetStateToChangeTo(PlayerState newState)
        {
            base.SetStateToChangeTo(newState);
        }
    }
}
