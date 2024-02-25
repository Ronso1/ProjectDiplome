using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float topBound = 5.0f;
    public float bottomBound = -5.0f;
    private float direction = 1f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * direction * Time.deltaTime);
        Debug.Log(Vector3.up * speed * direction * Time.deltaTime);

        if (transform.position.y >= topBound - 1f)
        {
            direction = bottomBound;
        }
        else if (transform.position.y <= bottomBound - 1f)
        {
            direction = topBound;
        }
    }
}
