using UnityEngine;

public class RegisterNewRespawn : MonoBehaviour
{
    [SerializeField] private PlayerCurrentRespawnPoint _playerRespawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            _playerRespawnPoint.SetRespawnPoint(transform);
        }
    }
}
