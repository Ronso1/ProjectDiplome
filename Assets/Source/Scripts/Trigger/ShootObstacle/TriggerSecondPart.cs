using UnityEngine;

public class TriggerSecondPart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleLogic>())
        {
            Destroy(other.gameObject);
        }
    }
}