using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    private CharacterController _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            _player = other.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            _player.Move(_rb.velocity * Time.deltaTime);
        }     
    }
}
