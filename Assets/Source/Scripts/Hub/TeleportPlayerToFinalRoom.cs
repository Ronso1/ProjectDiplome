using UnityEngine;

public class TeleportPlayerToFinalRoom : MonoBehaviour
{
    [SerializeField] private Transform _endPointPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCharacterController>())
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = _endPointPosition.position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
