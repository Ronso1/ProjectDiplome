using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 10f;
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
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Mathf.Abs(transform.position.x - initialPosition) >= distance)
        {
            movingRight = !movingRight;
        }
    }
}
