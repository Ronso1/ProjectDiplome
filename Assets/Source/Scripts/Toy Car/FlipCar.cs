using UnityEngine;

public class FlipCar : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        }
    }
}
