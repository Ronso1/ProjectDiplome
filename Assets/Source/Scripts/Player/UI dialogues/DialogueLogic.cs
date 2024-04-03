using System.Collections.Generic;
using UnityEngine;

public class DialogueLogic : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private GameObject _playerGun;
    [SerializeField] private GunAnimations _gunAnimations;
    [SerializeField] private List<GameObject> _messages;

    private int _indexOfList = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            if (_playerGun.activeSelf) _gunAnimations.StopWalkingAnimation();
            _playerMove.enabled = false;
            _messages[_indexOfList].SetActive(true);
            _indexOfList++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            ShowMessageForPlayer();
        }
    }

    private void ShowMessageForPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        {
            if (_indexOfList >= _messages.Count)
            {
                _messages[_indexOfList - 1].SetActive(false);
                gameObject.SetActive(false);
                _playerMove.enabled = true;
                return;
            }

            if (_indexOfList != 0) _messages[_indexOfList - 1].SetActive(false);
            _messages[_indexOfList].SetActive(true);
            _indexOfList++;
        }
    }
}
