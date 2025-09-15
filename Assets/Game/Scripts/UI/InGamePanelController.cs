#nullable enable

namespace Game
{
    using UnityEngine;
    using UnityEngine.UI;

    public sealed class InGamePanelController : MonoBehaviour
    {
        [Header("Buttons")]

        [SerializeReference]
        [ResolveComponentFromChildren("Back Button")]
        private Button backButton = null!;

        private void Awake()
        {
            this.backButton.onClick.AddListener(this.OnBackButtonPressed);
        }

        private void OnDestroy()
        {
            this.backButton.onClick.RemoveListener(this.OnBackButtonPressed);
        }

        private void OnBackButtonPressed()
        {
            GameplayManager.BackToMainMenu();
        }
    }
}
