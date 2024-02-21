using System.Collections;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clipShoot;
    [Space]
    [SerializeField] private float _shootDistance;
    [SerializeField] private float _shootDelay;

    private bool _shootEnabled = true;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PlayerShoot();
        }
    }

    private void PlayerShoot()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _shootDistance) && _shootEnabled)
        {
            _audioSource.Play();
            StartCoroutine(ShootDelay());
            Debug.Log(hitInfo.transform.name);
        }
    }

    private IEnumerator ShootDelay()
    {
        _shootEnabled = false;
        yield return new WaitForSeconds(_shootDelay);
        _shootEnabled = true;
    }
}