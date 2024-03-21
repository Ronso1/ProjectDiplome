using UnityEngine;

public class ChangeCarToPlayer : MonoBehaviour
{
    [SerializeField] private EasySuspension _easySuspension;
    [SerializeField] private RearWheelDrive _rearWheelDrive;
    [SerializeField] private GameObject _carCamera;
    [SerializeField] private GameObject _player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _carCamera.SetActive(false);
            _easySuspension.enabled = false;
            _rearWheelDrive.enabled = false;
            _player.SetActive(true);
        }
    }
}
