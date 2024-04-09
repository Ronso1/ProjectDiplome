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
    [SerializeField] private PlayerMove _player;
    [SerializeField] private TrainObstacle _obstacleHandler;
    [SerializeField] private GunAnimations _gunAnimations;
    [Space]
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _damage;

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
        if (_shootEnabled is false)
        {
            return;
        }

       /* if (_player.IsGrounded() == false)
        {
            _gunAnimations.StopWalkingAnimation();
        }*/

        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        _audioSource.Play();

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity) && _shootEnabled)
        {
            var bullet = Instantiate(_bullet, _gunMuzzle.transform.position, _gunMuzzle.transform.rotation);

            bullet.transform.DOLocalMove(hitInfo.point, 0.1f)
                 .SetEase(Ease.InOutSine);

            if (hitInfo.transform.tag == "Obstacle")
            {
                hitInfo.transform.gameObject.SetActive(false);
                _obstacleHandler.RespawnObstacle();
            }

            if (hitInfo.transform.GetComponent<ObstacleLogic>())
            {
                var obstacle = hitInfo.transform.GetComponent<ObstacleLogic>();

                obstacle.TakeDamage(_damage);
            }
        }

        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        _shootEnabled = false;
        yield return new WaitForSeconds(_shootDelay);
        _shootEnabled = true;
    }
}