using UnityEngine;

public class TriggerElevator : MonoBehaviour
{
    [SerializeField] private HidePartsOfElevator _elevator;
    [SerializeField] private Animator _elevatorAnimation;

    private void OnTriggerEnter(Collider other)
    {
        _elevator.enabled = true;
        _elevatorAnimation.enabled = true;
        gameObject.SetActive(false);
    }
}