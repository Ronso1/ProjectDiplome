using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _distance = 10f;
    private float initialPosition;
    private bool movingRight = true;

    void Start()
    {
        initialPosition = transform.position.x;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (Mathf.Abs(transform.position.x - initialPosition) >= _distance)
        {
            movingRight = !movingRight;
        }
    }
}
