using UnityEngine;

public class ReturnPlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerCar;
    [SerializeField] private Transform _checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        _playerCar.position = _checkpoint.position;
        _playerCar.rotation = _checkpoint.rotation;
    }
}
