using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private int _levelID;

    private void Start()
    {
        var lvlChecker = GameObject.FindObjectOfType<LevelCompleteLogic>();

        if (lvlChecker.LevelCompleted == _levelID)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            SceneManager.LoadScene(_levelID);
        }
    }
}
