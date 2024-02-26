using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            other.transform.position = _respawnPoint.position;
            other.transform.rotation = _respawnPoint.rotation;
        }
    }
}