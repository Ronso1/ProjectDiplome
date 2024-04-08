using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelCompleteLogic : MonoBehaviour
{
    private static int _levelCompleted;

    [SerializeField] private int _hubID;

    public int LevelCompleted => _levelCompleted;

    private void OnTriggerEnter(Collider other)
    {
        _levelCompleted++;
        transform.GetComponent<MeshRenderer>().enabled = false;
        SceneManager.LoadScene(_hubID);
    }
}