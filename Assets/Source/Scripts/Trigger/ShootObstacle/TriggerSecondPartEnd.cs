using UnityEngine;

public class TriggerSecondPartEnd : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>())
        {
            _spawner.SetActive(false);
        }
    }
}