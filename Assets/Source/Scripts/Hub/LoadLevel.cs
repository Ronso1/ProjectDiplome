using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private int _levelID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCharacterController>())
        {
            SceneManager.LoadScene(_levelID);
        }
    }
}
