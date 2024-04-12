using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _slider;

    private static float _currentVol = 0.5f;

    public void TransferVolumeValue()
    {
        _slider.value = _currentVol;
        _audioSource.volume = _slider.value;
    }

    public void SetVolume(float vol)
    {
        _audioSource.volume = vol;
        _currentVol = vol;
    }
}