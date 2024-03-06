using UnityEngine;

public class ChangePlayerToCar : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _carCamera;
    [SerializeField] private EasySuspension _easySuspension;
    [SerializeField] private RearWheelDrive _rearWheelDrive;

    public void SetCarActive()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _player.SetActive(false);
            _carCamera.SetActive(true);
            _easySuspension.enabled = true;
            _rearWheelDrive.enabled = true;
        }
    }
}
