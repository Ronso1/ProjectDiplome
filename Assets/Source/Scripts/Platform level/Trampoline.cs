using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            var player = other.GetComponent<PlayerCharacterController>();

            player.SetTrampolineJump(_jumpHeight);
        }
    }
}
