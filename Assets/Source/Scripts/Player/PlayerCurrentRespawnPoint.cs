using UnityEngine;

public class PlayerCurrentRespawnPoint : MonoBehaviour
{
    private Transform _currentRespawnPoint;

    public void SetRespawnPoint(Transform point)
    {
        _currentRespawnPoint = point;
    }

    public void RespawnPlayer()
    {
        transform.position = _currentRespawnPoint.position;
        transform.rotation = _currentRespawnPoint.rotation;
    }
}