#nullable enable

namespace Game
{
    using System.Collections.Generic;
    using UnityEngine;

    public sealed class LevelManager : SingletonMonoBehaviour<LevelManager>
    {
        private readonly List<EnemyController> enemyControllers = new();

        [SerializeReference]
        private PlayerController playerController = null!;

        [SerializeReference]
        [RequireReference]
        [PrefabOnly]
        private EnemyController enemyControllerPrefab = null!;

        [SerializeReference]
        private List<LevelController> levelControllersPrefab = new();

        private LevelController? currentLevelController = null;

        public static int AmountLevels => LevelManager.Instance.levelControllersPrefab.Count;

        protected override LevelManager LocalInstance => this;

        public static bool LoadLevel(int levelIdx)
        {
            if (levelIdx >= LevelManager.Instance.levelControllersPrefab.Count)
            {
                return false;
            }

            LevelManager.UnloadCurrentLevel();
            LevelManager.Instance.currentLevelController = Object.Instantiate(
                LevelManager.Instance.levelControllersPrefab[levelIdx],
                LevelManager.Instance.transform);

            LevelManager.Instance.playerController.transform.position = LevelManager.Instance.currentLevelController.PlayerSpawnPosition;
            LevelManager.Instance.playerController.gameObject.SetActive(true);

            var enemySpawnPositions = LevelManager.Instance.currentLevelController.EnemySpawnPositions;
            LevelManager.Instance.enemyControllers.Clear();
            LevelManager.Instance.enemyControllers.Capacity = enemySpawnPositions.Count;
            for (int i = 0; i < enemySpawnPositions.Count; ++i)
            {
                var enemyController = Object.Instantiate(
                    LevelManager.Instance.enemyControllerPrefab,
                    enemySpawnPositions[i],
                    Quaternion.identity,
                    LevelManager.Instance.transform);
                LevelManager.Instance.enemyControllers.Add(enemyController);
            }

            return true;
        }

        public static void UnloadCurrentLevel()
        {
            if (LevelManager.Instance.currentLevelController != null)
            {
                Object.Destroy(LevelManager.Instance.currentLevelController.gameObject);
                LevelManager.Instance.currentLevelController = null;
            }

            LevelManager.Instance.playerController.gameObject.SetActive(false);

            foreach (var enemyController in LevelManager.Instance.enemyControllers)
            {
                Object.Destroy(enemyController.gameObject);
            }
            LevelManager.Instance.enemyControllers.Clear();
        }

        protected override void OnAwake()
        {
            this.playerController.gameObject.SetActive(false);
        }
    }
}
