using UnityEngine;

public class TeleportPlayerToFinalRoom : MonoBehaviour
{
    [SerializeField] private Transform _endPointPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            other.transform.position = _endPointPosition.position;
        }
    }
}
