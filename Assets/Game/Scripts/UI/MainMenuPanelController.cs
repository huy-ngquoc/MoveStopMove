#nullable enable

namespace Game
{
    using UnityEngine;
    using UnityEngine.UI;

    public sealed class MainMenuPanelController : MonoBehaviour
    {
        [field: Header("Buttons")]

        [SerializeReference]
        [ResolveComponentFromChildren("Play Button")]
        private Button playButton = null!;

        [SerializeReference]
        [ResolveComponentFromChildren("Exit Button")]
        private Button exitButton = null!;

        private void Awake()
        {
            this.playButton.onClick.AddListener(this.OnPlayButtonClicked);
            this.exitButton.onClick.AddListener(this.OnExitButtonClicked);
        }

        private void OnDestroy()
        {
            this.playButton.onClick.RemoveListener(this.OnPlayButtonClicked);
            this.exitButton.onClick.RemoveListener(this.OnExitButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            GameplayManager.Play();
        }

        private void OnExitButtonClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
