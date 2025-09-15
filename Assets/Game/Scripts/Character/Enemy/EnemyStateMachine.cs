#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class EnemyStateMachine : CharacterStateMachine
    {
        [SerializeReference]
        [ResolveComponentFromSelf]
        private EnemyController enemyController = null!;

        public EnemyStateMachine()
        {
            this.IdleState = new EnemyIdleState(this);
            this.AttackState = new EnemyAttackState(this);
            this.WinState = new EnemyWinState(this);
            this.DeadState = new EnemyDeadState(this);
        }

        public EnemyIdleState IdleState { get; }

        public EnemyAttackState AttackState { get; }

        public EnemyWinState WinState { get; }

        public EnemyDeadState DeadState { get; }

        public EnemyController EnemyController => this.enemyController;

        public override CharacterController CharacterController => this.enemyController;

        protected override State InitialState => this.IdleState;

        public void SetStateToChangeTo(EnemyState newState)
        {
            base.SetStateToChangeTo(newState);
        }
    }
}
