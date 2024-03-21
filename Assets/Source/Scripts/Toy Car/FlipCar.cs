using System.Collections;
using UnityEngine;

public class FlipCar : MonoBehaviour
{
    [SerializeField] private float _delay;

    private bool _isEnabled = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isEnabled)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
            StartCoroutine(DelayRotateButton());
        }
    }

    private IEnumerator DelayRotateButton()
    {
        _isEnabled = false;
        yield return new WaitForSeconds(_delay);
        _isEnabled = true;
    }
}
