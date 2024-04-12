using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private InteractiveCommands _pickupGun;
    [SerializeField] private HeadBobEffect _headBobEffect;
    [SerializeField] private GunAnimations _gunAnimations;
    [SerializeField] private ChangeVolume _changeVolume;

    [Header("Player movement")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private float _speed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale = -9.81f;

    private CharacterController _characterController;
    private Vector3 _velocity;

    private bool _isGrounded;
    private float _defaultSpeed;

    private void Start()
    {
        _changeVolume.TransferVolumeValue();
        _defaultSpeed = _speed;
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerInteractiveAction();

        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight);

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 move = transform.right * xMove + transform.forward * zMove;

        if (xMove == 0f && zMove == 0f)
        {
            _headBobEffect.SetDefaultPosition();

            if (_gunAnimations.CheckGameObjectActive(_gunAnimations.gameObject.activeSelf))
            {
                _gunAnimations.StopWalkingAnimation();
            }
        }

        if (_isGrounded && (xMove != 0f || zMove != 0f))
        {
            _headBobEffect.SetNextPosition();

            if (_gunAnimations.CheckGameObjectActive(_gunAnimations.gameObject.activeSelf))
            {
                _gunAnimations.PlayWalkingAnimation();
            }
        }
        else if (_isGrounded is false)
        {
            _headBobEffect.SetDefaultPosition();

            if (_gunAnimations.CheckGameObjectActive(_gunAnimations.gameObject.activeSelf))
            {
                _gunAnimations.StopWalkingAnimation();
            }
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _sprintSpeed;
        }
        else
        {
            _speed = _defaultSpeed;  
        }

        _characterController.Move(move * _speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = _jumpForce;
        }

        if (_isGrounded is false)
        {
            _velocity.y += _gravityScale * Time.deltaTime;
        }

        _characterController.Move(_velocity * Time.deltaTime);

    }

    private void PlayerInteractiveAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _pickupGun.InteractiveAction();
        }
    }

    public void SetTrampolineJump(float jumpHeight)
    {
        _velocity.y = jumpHeight;
    }
}
