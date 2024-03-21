using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangeLogic : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
    }
}
