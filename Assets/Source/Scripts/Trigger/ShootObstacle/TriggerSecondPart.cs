using UnityEngine;

public class TriggerSecondPart : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleLogic>())
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.GetComponent<PlayerMove>())
        {
            _spawner.SetActive(true);
        }
    }
}