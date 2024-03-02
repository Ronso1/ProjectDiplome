using UnityEngine;

public class TriggerHideBarrel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObstacleLogic>())
        {
            Destroy(other.gameObject);
        }
    }
}
