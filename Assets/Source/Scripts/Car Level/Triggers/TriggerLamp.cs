using UnityEngine;

public class TriggerLamp : MonoBehaviour
{
    [SerializeField] private Light _lamp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SphereCollider>())
        {
            SetActivatedColor();
            gameObject.SetActive(false);
        }
    }

    private void SetActivatedColor()
    {
        _lamp.color = Color.blue;
    }
}
