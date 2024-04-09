using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private CameraMove _playerCamera;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _messageParent;
    [SerializeField] private GameObject _crosshair;

    private bool _menuActive;

    private GameObject _carCamera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _menuActive == false)
        {
            _carCamera = GameObject.FindGameObjectWithTag("CarCamera");

            if (_carCamera is not null)
            {
                _carCamera.GetComponent<CameraController>().enabled = false;
            }

            Time.timeScale = 0f;
            _crosshair.SetActive(false);
            _messageParent.SetActive(false);
            _menu.SetActive(true);
            _menuActive = true;
            _playerCamera.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _menuActive)
        {
            if (_carCamera is not null)
            {
                _carCamera.GetComponent<CameraController>().enabled = true;
            }

            Time.timeScale = 1f;
            _crosshair.SetActive(true);
            _messageParent.SetActive(true);
            _menu.SetActive(false);
            _menuActive = false;
            _playerCamera.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
