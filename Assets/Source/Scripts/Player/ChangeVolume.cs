using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void SetVolume(float vol)
    {
        _audioSource.volume = vol;
    }
}
