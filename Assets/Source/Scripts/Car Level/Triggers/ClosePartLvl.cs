using UnityEngine;

public class ClosePartLvl : MonoBehaviour
{
    [SerializeField] private GameObject _entrance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _entrance.SetActive(true);
            gameObject.SetActive(false);
        }      
    }
}