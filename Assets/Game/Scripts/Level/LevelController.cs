#nullable enable

namespace Game
{
    using System.Collections.Generic;
    using UnityEngine;

    [DisallowMultipleComponent]
    public sealed class LevelController : MonoBehaviour
    {
        private readonly List<Vector3> enemySpawnPositions = new();

        [SerializeReference]
        [RequireReference]
        private Transform playerSpawnTransform = null!;

        [SerializeReference]
        private List<Transform> enemySpawnTransforms = new();

        public Vector3 PlayerSpawnPosition => this.playerSpawnTransform.position;

        public List<Vector3> EnemySpawnPositions => this.enemySpawnPositions;

        public int EnemiesAmount => this.enemySpawnTransforms.Count;

        private void Awake()
        {
            this.enemySpawnPositions.Clear();
            this.enemySpawnPositions.Capacity = this.enemySpawnTransforms.Count;

            foreach (var transform in this.enemySpawnTransforms)
            {
                this.enemySpawnPositions.Add(transform.position);
            }
        }
    }
}
