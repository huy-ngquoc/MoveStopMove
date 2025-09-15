#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class GameplayStateMachine : StateMachine
    {
        [SerializeReference]
        [ResolveComponentFromSelf]
        private GameplayManager gameplayManager = null!;

        public GameplayStateMachine()
        {
            this.PlayingState = new GameplayPlayingState(this);
            this.WinState = new GameplayWinState(this);
            this.LoseState = new GameplayLoseState(this);
            this.MainMenuState = new GameplayMainMenuState(this);
        }

        public GameplayManager GameplayManager => this.gameplayManager;

        public GameplayPlayingState PlayingState { get; }

        public GameplayWinState WinState { get; }

        public GameplayLoseState LoseState { get; }

        public GameplayMainMenuState MainMenuState { get; }

        protected override State InitialState => this.MainMenuState;

        public void SetStateToChangeTo(GameplayState newState)
        {
            base.SetStateToChangeTo(newState);
        }
    }
}
