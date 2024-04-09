using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private InteractiveCommands _pickupGun;

    [Header("Player movement")]
    [SerializeField] private float _playerHeight;
    public float _speed;
    public float _jumpForce;
    private CharacterController _characterController;
    private Vector3 _velocity;

    [Header("Camera")]
    public float _sensitivity;
    public GameObject _playerCamera;
    private float _rotationX = 0f;

    private bool _isGrounded;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerInteractiveAction();

        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight);

        if (_isGrounded)
        {           
            _velocity.y = 0f;
        }

        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 move = transform.right * xMove + transform.forward * zMove;

        _characterController.Move(move * _speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = _jumpForce;
        }

        _velocity.y += Physics.gravity.y * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
    private void PlayerInteractiveAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _pickupGun.InteractiveAction();
        }
    }
}
