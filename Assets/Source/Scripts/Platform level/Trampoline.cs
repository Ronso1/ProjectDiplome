using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 5f;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 jumpVector = Vector3.up * Mathf.Sqrt(2 * _jumpHeight * Mathf.Abs(Physics.gravity.y));
            rb.velocity = jumpVector;
        }
    }
}
