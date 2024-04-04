using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private AudioClip _newAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerAudioSource.Stop();
            _playerAudioSource.clip = _newAudioClip;
            _playerAudioSource.Play();
        }
    }
}
