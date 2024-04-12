using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Range(0, 15)] private static float _sensivity = 2f;
    [SerializeField] private Transform _player;
    [SerializeField] private float _verticalLover;
    [SerializeField] private float _verticalUpper;
    [SerializeField] private ChangeSensitivity _changeSensitivity;
    private float _currentVerticalAngle;

    private void Start()
    {
        _changeSensitivity.SetSliderPosition(_sensivity);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        PlayerCameraMoving();
    }

    private void PlayerCameraMoving()
    {
        var vertical = -Input.GetAxis("Mouse Y") * _sensivity;
        var horizontal = Input.GetAxis("Mouse X") * _sensivity;
        _currentVerticalAngle = Mathf.Clamp(_currentVerticalAngle + vertical, _verticalUpper, _verticalLover);
        transform.localRotation = Quaternion.Euler(_currentVerticalAngle, 0, 0);
        _player.Rotate(0, horizontal, 0);
    }

    public void SetNewSensetivity(float value)
    {
        _sensivity = value;
    }
}
