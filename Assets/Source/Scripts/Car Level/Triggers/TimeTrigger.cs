using TMPro;
using UnityEngine;

public class TimeTrigger : MonoBehaviour
{
    [SerializeField] private Transform _car;
    [SerializeField] private Transform _checkpoint;
    [SerializeField] private TMP_Text _timerText;
    [Space]
    [SerializeField] private float _timeRemaining;

    private bool _timerEnabled = false;

    private float _startValue;

    private void Start()
    {
        _startValue = _timeRemaining;
    }

    private void Update()
    {
        if (_timerEnabled)
        {
            _timeRemaining -= Time.deltaTime;
            _timerText.text = $"Время: {(int)_timeRemaining}";
        }

        if (_timeRemaining <= 0f && _timerEnabled)
        {
            _car.position = _checkpoint.position;
            _car.rotation = _checkpoint.rotation;

            _timerText.gameObject.SetActive(false);
            _timerEnabled = false;
            _timeRemaining = _startValue;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _timerText.gameObject.SetActive(true);
        _timerEnabled = true;
    }
}