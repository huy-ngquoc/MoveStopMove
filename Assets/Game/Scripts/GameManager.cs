#nullable enable

namespace Game
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public sealed class GameManager : SingletonMonoBehaviour<GameManager>
    {
        public static int CurrentLevelIdx
        {
            get
            {
                return PlayerPrefs.GetInt(nameof(GameManager.CurrentLevelIdx), 0);
            }

            set
            {
                PlayerPrefs.SetInt(nameof(GameManager.CurrentLevelIdx), value);
            }
        }

        protected override GameManager LocalInstance => this;
    }
}
