using UnityEngine;

public class HeadBobEffect : MonoBehaviour
{
    [SerializeField] private float _walkingBobbingSpeed = 10f;
    [SerializeField] private float _bobbingAmount = 0.05f;

    private float _timer = 0f;
    private float _defaultPositionY = 0f;

    private void Start()
    {
        _defaultPositionY = transform.localPosition.y;
    }

    public void SetNextPosition()
    {
        _timer += Time.deltaTime * _walkingBobbingSpeed;
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            _defaultPositionY + Mathf.Sin(_timer) * _bobbingAmount,
            transform.localPosition.z
            );
    }

    public void SetDefaultPosition()
    {
        _timer = 0f;
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            Mathf.Lerp(
                transform.localPosition.y,
                _defaultPositionY,
                Time.deltaTime + _walkingBobbingSpeed
            ),
            transform.localPosition.z
        );
    }
}
