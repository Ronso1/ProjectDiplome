using System.Collections.Generic;
using UnityEngine;

public class TrainObstacle : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private float _vectorZ;

    public void RespawnObstacle()
    {
        foreach (var obstacle in _obstacles)
        {
            if (obstacle.activeSelf is false)
            {
                obstacle.transform.position = new Vector3(Random.Range(13.7f, 16.5f), Random.Range(2f, 5f), _vectorZ);
                obstacle.SetActive(true);
            }
        }
    }
}
