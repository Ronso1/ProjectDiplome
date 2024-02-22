using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clipShoot;
    [SerializeField] private GameObject _gunMuzzle;
    [SerializeField] private GameObject _bullet;
    [Space]
    [SerializeField] private TrainObstacle _obstacleHandler;
    [SerializeField] private GunAnimations _gunAnimations;
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

        _gunAnimations.StopWalkingAnimation();

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _shootDistance) && _shootEnabled)
        {
            _audioSource.Play();
            var bullet = Instantiate(_bullet, _gunMuzzle.transform.position, _gunMuzzle.transform.rotation);

            StartCoroutine(ShootDelay());

            bullet.transform.DOLocalMove(hitInfo.point, 0.1f)
                 .SetEase(Ease.InOutSine);

            if (hitInfo.transform.tag == "Obstacle")
            {
                hitInfo.transform.gameObject.SetActive(false);
                _obstacleHandler.RespawnObstacle();
            }
        }
    }

    private IEnumerator ShootDelay()
    {
        _shootEnabled = false;
        yield return new WaitForSeconds(_shootDelay);
        _shootEnabled = true;
    }
}