using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelCompleteLogic : MonoBehaviour
{
    private static int _levelCompleted;
    private static int _levelID;

    [SerializeField] private int _hubID;

    public int LevelCompleted => _levelCompleted;
    public int LevelID => _levelID;

    private void OnTriggerEnter(Collider other)
    {
        _levelCompleted++;
        _levelID = SceneManager.GetActiveScene().buildIndex;
        transform.GetComponent<MeshRenderer>().enabled = false;
        SceneManager.LoadScene(_hubID);
    }
}