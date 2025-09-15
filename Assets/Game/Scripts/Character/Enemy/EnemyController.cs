#nullable enable

namespace Game
{
    using UnityEngine;
    using UnityEngine.AI;

    public sealed class EnemyController : CharacterController
    {
        [SerializeReference]
        [ResolveComponentFromSelf]
        private EnemyStateMachine enemyStateMachine = null!;

        [SerializeReference]
        [ResolveComponentFromSelf]
        private NavMeshAgent navMeshAgent = null!;

        public EnemyStateMachine EnemyStateMachine => this.enemyStateMachine;

        public NavMeshAgent NavMeshAgent => this.navMeshAgent;

        public override CharacterStateMachine CharacterStateMachine => this.enemyStateMachine;

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
            this.EnemyStateMachine.SetStateToChangeTo(this.EnemyStateMachine.IdleState);
        }

        private void GameplayManager_PlayerWin()
        {
            this.EnemyStateMachine.SetStateToChangeTo(this.EnemyStateMachine.DeadState);
        }

        private void GameplayManager_PlayerLose()
        {
            this.EnemyStateMachine.SetStateToChangeTo(this.EnemyStateMachine.WinState);
        }
    }
}
