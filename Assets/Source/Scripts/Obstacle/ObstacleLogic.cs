using System.Collections;
using UnityEngine;

public class ObstacleLogic : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private float _minSpeedRange;
    [SerializeField] private float _maxSpeedRange;
    [Space]
    [SerializeField] private Vector3 _direction;

    private float _speed;

    public float Health => _health;

    private void Start()
    {
        _speed = Random.Range(_minSpeedRange, _maxSpeedRange);
        StartCoroutine(StartDisableObstacle());
    }

    private void Update()
    {
        if (_health <= 0f)
        {
            StopCoroutine(StartDisableObstacle());
            Destroy(gameObject);
        }

        transform.Translate(
            new Vector3(_direction.x * _speed * Time.deltaTime,
            _direction.y * _speed * Time.deltaTime,
            _direction.z * _speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            print("Hit player!");
        }
    }

    private IEnumerator StartDisableObstacle()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
}
