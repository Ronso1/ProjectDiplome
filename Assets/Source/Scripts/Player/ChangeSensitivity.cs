using UnityEngine;
using UnityEngine.UI;

public class ChangeSensitivity : MonoBehaviour
{
    [SerializeField] private CameraMove _playerCamera;
    [SerializeField] private Slider _slider;

    public void SetSensitivity()
    {
        _playerCamera.SetNewSensetivity(_slider.value);
    }

    public void SetSliderPosition(float value)
    {
        _slider.value = value;
    }
}
