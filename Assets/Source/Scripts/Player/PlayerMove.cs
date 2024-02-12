using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Transform _root;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _sprintSpeed;
    [Space]
    [SerializeField] private float _jumpHeight;

    private float _horizontal;
    private float _vertical;
    private float _moveSpeed;

    private bool _isGrounded;

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
    }

    private void FixedUpdate()
    {
        PlayerMoving();
    }

    private void PlayerMoving()
    {
        var moveDirection = _root.TransformDirection(new Vector3(_horizontal, 0, _vertical));

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

    //TODO: изменить проверку прыжка, например сделать через тег
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            _rigidBody.velocity = new Vector3(0f, _jumpHeight, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }
}