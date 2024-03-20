using System.Collections;
using UnityEngine;

public class TriggerLamp : MonoBehaviour
{
    [SerializeField] private Light _lamp;
    [SerializeField] private GameObject _gate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SphereCollider>())
        {
            SetActivatedColor();
            StartCoroutine(GateActions());
        }
    }

    private void SetActivatedColor()
    {
        _lamp.color = Color.blue;
    }

    private IEnumerator GateActions()
    {
        _gate.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _gate.SetActive(true);
        gameObject.SetActive(false);
    }
}
