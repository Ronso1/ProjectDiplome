using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePartsOfElevator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _elevatorParts;
    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material _secondMaterial;
    [Space]
    [SerializeField] private float _timeToHide = 1f;
    private GameObject _currentPart;

    private bool _isHide = false;

    private int _countHide = 0;

    private void Update()
    {
        ChangeState();
    }

    private void ChangeState()
    {
        if (_isHide is false && _countHide != 40)
        {
            _currentPart = _elevatorParts[Random.Range(0, _elevatorParts.Count)];

            if (_currentPart.activeSelf is false)
            {
                return;
            }

            _isHide = true;
            _countHide++;
            StartCoroutine(ChangeColor());
        }
        else if (_countHide == 40)
        {
            foreach (var part in _elevatorParts)
            {
                part.SetActive(true);
            }

            _countHide = 0;
        }
    }

    private IEnumerator ChangeColor()
    {
        _currentPart.GetComponent<Renderer>().material = _secondMaterial;
        yield return new WaitForSeconds(_timeToHide);
        _currentPart.GetComponent<Renderer>().material = _startMaterial;
        yield return new WaitForSeconds(_timeToHide - _timeToHide / 2f);
        _currentPart.GetComponent<Renderer>().material = _secondMaterial;
        yield return new WaitForSeconds(_timeToHide / 4f);
        _currentPart.GetComponent<Renderer>().material = _startMaterial;
        yield return new WaitForSeconds(_timeToHide / 6f);
        _currentPart.GetComponent<Renderer>().material = _secondMaterial;
        yield return new WaitForSeconds(_timeToHide / 8f);
        _currentPart.GetComponent<Renderer>().material = _startMaterial;
        yield return new WaitForSeconds(_timeToHide / 10f);
        _currentPart.GetComponent<Renderer>().material = _secondMaterial;
        yield return new WaitForSeconds(_timeToHide / 12f);
        _currentPart.GetComponent<Renderer>().material = _startMaterial;
        _currentPart.SetActive(false);
        _isHide = false;
    }
}