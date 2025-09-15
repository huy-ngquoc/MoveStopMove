#nullable enable

namespace Game
{
    using UnityEngine;
    using UnityEngine.UI;

    public sealed class LosePanelController : MonoBehaviour
    {
        [Header("Buttons")]

        [SerializeReference]
        [ResolveComponentFromChildren("Retry Button")]
        private Button retryButton = null!;

        [SerializeReference]
        [ResolveComponentFromChildren("Back Button")]
        private Button backButton = null!;

        private void Awake()
        {
            this.retryButton.onClick.AddListener(this.OnRetryButtonPressed);
            this.backButton.onClick.AddListener(this.OnBackButtonPressed);
        }

        private void OnDestroy()
        {
            this.retryButton.onClick.RemoveListener(this.OnRetryButtonPressed);
            this.backButton.onClick.RemoveListener(this.OnBackButtonPressed);
        }

        private void OnRetryButtonPressed()
        {
            GameplayManager.Play();
        }

        private void OnBackButtonPressed()
        {
            GameplayManager.BackToMainMenu();
        }
    }
}
