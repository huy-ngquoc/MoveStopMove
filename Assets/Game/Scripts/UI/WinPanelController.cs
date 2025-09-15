#nullable enable

namespace Game
{
    using UnityEngine;
    using UnityEngine.UI;

    public sealed class WinPanelController : MonoBehaviour
    {
        [Header("Buttons")]

        [SerializeReference]
        [ResolveComponentFromChildren("Continue Button")]
        private Button continueButton = null!;

        [SerializeReference]
        [ResolveComponentFromChildren("Back Button")]
        private Button backButton = null!;

        private void Awake()
        {
            this.continueButton.onClick.AddListener(this.OnContinueButtonPressed);
            this.backButton.onClick.AddListener(this.OnBackButtonPressed);
        }

        private void OnDestroy()
        {
            this.continueButton.onClick.RemoveListener(this.OnContinueButtonPressed);
            this.backButton.onClick.RemoveListener(this.OnBackButtonPressed);
        }

        private void OnContinueButtonPressed()
        {
            GameplayManager.Play();
        }

        private void OnBackButtonPressed()
        {
            GameplayManager.BackToMainMenu();
        }
    }
}
