#nullable enable

namespace Game
{
    using System;
    using UnityEngine;

    public sealed class GameplayManager : SingletonMonoBehaviour<GameplayManager>
    {
        [SerializeReference]
        [ResolveComponentFromSelf]
        private GameplayStateMachine stateMachine = null!;

        public static event Action? GameStarted
        {
            add => GameplayManager.OnGameStarted += value;
            remove => GameplayManager.OnGameStarted -= value;
        }

        public static event Action? PlayerWin
        {
            add => GameplayManager.OnPlayerWin += value;
            remove => GameplayManager.OnPlayerWin -= value;
        }

        public static event Action? PlayerLose
        {
            add => GameplayManager.OnPlayerLose += value;
            remove => GameplayManager.OnPlayerLose -= value;
        }

        private static event Action? OnGameStarted = null;

        private static event Action? OnPlayerWin = null;

        private static event Action? OnPlayerLose = null;

        protected override GameplayManager LocalInstance => this;

        public static void GameEndWin()
        {
            var staticStateMachine = GameplayManager.Instance.stateMachine;
            staticStateMachine.SetStateToChangeTo(staticStateMachine.WinState);
            GameplayManager.OnPlayerWin?.Invoke();
        }

        public static void GameEndLose()
        {
            var staticStateMachine = GameplayManager.Instance.stateMachine;
            staticStateMachine.SetStateToChangeTo(staticStateMachine.LoseState);
            GameplayManager.OnPlayerLose?.Invoke();
        }

        public static void Play()
        {
            var staticStateMachine = GameplayManager.Instance.stateMachine;
            staticStateMachine.SetStateToChangeTo(staticStateMachine.PlayingState);
            GameplayManager.OnGameStarted?.Invoke();
        }

        public static void BackToMainMenu()
        {
            var staticStateMachine = GameplayManager.Instance.stateMachine;
            staticStateMachine.SetStateToChangeTo(staticStateMachine.MainMenuState);
        }
    }
}
