using System.Collections;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    [SerializeField] private float _timeLife = 2f;

    private void Start()
    {
        StartCoroutine(StartDieBullet());
    }

    private IEnumerator StartDieBullet()
    {
        yield return new WaitForSeconds(_timeLife);
        Destroy(gameObject);
    }
}
