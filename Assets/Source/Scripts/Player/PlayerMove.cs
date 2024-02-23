using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Transform _root;
    [SerializeField] private HeadBobEffect _headBobEffect;
    [SerializeField] private PickupGun _pickupGun;
    [SerializeField] private GunAnimations _gunAnimations;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _sprintSpeed;
    [Space]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _playerHeight = 2.3f;

    private float _horizontal;
    private float _vertical;
    private float _moveSpeed;

    private bool _isGrounded;
    private bool _isWalking;

    public bool IsWalking() => _isWalking;
    public bool IsGrounded() => _isGrounded;

    private void Start()
    {
        _isGrounded = true;
        _moveSpeed = _speed;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis(HorizontalAxis);
        _vertical = Input.GetAxis(VerticalAxis);
        PlayerJump();
        PlayerTakeGun();
    }

    private void FixedUpdate()
    {
        PlayerMoving();
    }

    private void PlayerMoving()
    {
        if (_horizontal == 0f && _vertical == 0f)
        {
            _headBobEffect.SetDefaultPosition();

            if (_gunAnimations.CheckGameObjectActive(_gunAnimations.gameObject.activeSelf))
            {
                _gunAnimations.StopWalkingAnimation();
            }

            return;
        }

        if (_isGrounded)
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

        var moveDirection = _root.TransformDirection(new Vector3(_horizontal, 0f, _vertical));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _sprintSpeed;
        }
        else
        {
            _speed = _moveSpeed;
        }

        _rigidBody.MovePosition(_rigidBody.transform.position + moveDirection * _speed * Time.fixedDeltaTime);
    }

    private void PlayerJump()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            _rigidBody.velocity = new Vector3(0f, _jumpHeight, 0f);
        }
    }

    private void PlayerTakeGun()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _pickupGun.TakeGun();
        }
    }
}