using UnityEngine;

public class RegisterNewRespawn : MonoBehaviour
{
    [SerializeField] private PlayerCurrentRespawnPoint _playerRespawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            _playerRespawnPoint.SetRespawnPoint(transform);
        }
    }
}
