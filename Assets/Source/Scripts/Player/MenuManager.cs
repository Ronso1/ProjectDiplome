using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private CameraMove _playerCamera;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _messageParent;
    [Space]
    [SerializeField] private AudioSource _audioSource;

    private bool _menuActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _menuActive == false)
        {
            Time.timeScale = 0f;
            _messageParent.SetActive(false);
            _menu.SetActive(true);
            _menuActive = true;
            _playerCamera.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _menuActive)
        {
            Time.timeScale = 1f;
            _messageParent.SetActive(true);
            _menu.SetActive(false);
            _menuActive = false;
            _playerCamera.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }      
    }
}
