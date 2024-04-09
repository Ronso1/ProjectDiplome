using UnityEngine;

public class GateAnimationLogic : MonoBehaviour
{
    [SerializeField] private Animator _gateAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            _gateAnimator.SetTrigger("Open");
        }
    }
}
