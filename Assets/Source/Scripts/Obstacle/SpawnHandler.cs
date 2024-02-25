using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private List<Transform> _obstaclesSpawnPoints;
    [SerializeField] private GameObject _barrel;
    [Space]
    [SerializeField] private float _spawnInterval;

    private bool _isSpawned = false;

    private void Update()
    {
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        if (_isSpawned)
        {
            return;
        }

        Instantiate(_barrel, _obstaclesSpawnPoints[Random.Range(0, _obstaclesSpawnPoints.Count - 1)]);
        StartCoroutine(DelaySpawnObstacle());
    }

    private IEnumerator DelaySpawnObstacle()
    {
        _isSpawned = true;
        yield return new WaitForSeconds(_spawnInterval);
        _isSpawned = false;
    }
}
