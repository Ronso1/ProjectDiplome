using UnityEngine;

public class ChangePlayerToCar : MonoBehaviour
{
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private PlayerCharacterController _player;
    [SerializeField] private GameObject _carCamera;
    [SerializeField] private EasySuspension _easySuspension;
    [SerializeField] private RearWheelDrive _rearWheelDrive;

    public void SetCarActive()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerCamera.SetActive(false);
            _player.enabled = false;
            _carCamera.SetActive(true);
            _easySuspension.enabled = true;
            _rearWheelDrive.enabled = true;
        }
    }
}
