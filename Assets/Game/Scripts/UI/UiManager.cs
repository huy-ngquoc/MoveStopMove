#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class UiManager : SingletonMonoBehaviour<UiManager>
    {
        [SerializeReference]
        [ResolveComponentFromChildren(true)]
        private InGamePanelController inGamePanelController = null!;

        [SerializeReference]
        [ResolveComponentFromChildren(true)]
        private WinPanelController winPanelController = null!;

        [SerializeReference]
        [ResolveComponentFromChildren(true)]
        private LosePanelController losePanelController = null!;

        [SerializeReference]
        [ResolveComponentFromChildren(true)]
        private MainMenuPanelController mainMenuPanelController = null!;

        protected override UiManager LocalInstance => this;

        public static void ShowInGamePanel()
        {
            UiManager.Instance.inGamePanelController.gameObject.SetActive(true);
        }

        public static void ShowWinPanel()
        {
            UiManager.Instance.winPanelController.gameObject.SetActive(true);
        }

        public static void ShowLosePanel()
        {
            UiManager.Instance.losePanelController.gameObject.SetActive(true);
        }

        public static void ShowMainMenuPanel()
        {
            UiManager.Instance.mainMenuPanelController.gameObject.SetActive(true);
        }

        public static void HideInGamePanel()
        {
            UiManager.Instance.inGamePanelController.gameObject.SetActive(false);
        }

        public static void HideWinPanel()
        {
            UiManager.Instance.winPanelController.gameObject.SetActive(false);
        }

        public static void HideLosePanel()
        {
            UiManager.Instance.losePanelController.gameObject.SetActive(false);
        }

        public static void HideMainMenuPanel()
        {
            UiManager.Instance.mainMenuPanelController.gameObject.SetActive(false);
        }
    }
}
