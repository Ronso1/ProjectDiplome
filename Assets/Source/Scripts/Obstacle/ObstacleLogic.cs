using System.Collections;
using UnityEngine;

public class ObstacleLogic : MonoBehaviour
{
     public float health = 100f;
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private float _minSpeedRange;
    [SerializeField] private float _maxSpeedRange;

    private float _speed;

    private void Start()
    {
        _speed = Random.Range(_minSpeedRange, _maxSpeedRange);
        StartCoroutine(StartDisableObstacle());
    }

    private void Update()
    {
        if (health <= 0f)
        {
            StopCoroutine(StartDisableObstacle());
            Destroy(gameObject);
        }

        transform.Translate(
            new Vector3(0f, _speed * Time.deltaTime, 0f));
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

}
