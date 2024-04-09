using UnityEngine;

public class TriggerFall : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            var charControl = other.GetComponent<CharacterController>();

            charControl.enabled = false;
            other.transform.position = _respawnPoint.position;
            other.transform.rotation = _respawnPoint.rotation;
            charControl.enabled = true;
        }
    }
}