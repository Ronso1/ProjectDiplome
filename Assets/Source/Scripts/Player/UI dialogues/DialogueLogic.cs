using System.Collections.Generic;
using UnityEngine;

public class DialogueLogic : MonoBehaviour
{
    [SerializeField] private PlayerCharacterController _playerMove;
    [SerializeField] private GameObject _playerGun;
    [SerializeField] private GunAnimations _gunAnimations;
    [SerializeField] private GunShoot _gunShoot;
    [SerializeField] private List<GameObject> _messages;

    private int _indexOfList = 0;
    private bool _onTrigger;

    private void Update()
    {
        if (_onTrigger)
        {
            ShowMessageForPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _onTrigger = true;

        if (other.GetComponent<PlayerCharacterController>())
        {
            if (_playerGun.activeSelf)
            {
                _gunAnimations.StopWalkingAnimation();
                _gunShoot.enabled = false;
            }

            _playerMove.enabled = false;
            _messages[_indexOfList].SetActive(true);
            _indexOfList++;
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
                _gunShoot.enabled = true;
                _onTrigger = false;
                return;
            }

            if (_indexOfList != 0) _messages[_indexOfList - 1].SetActive(false);
            _messages[_indexOfList].SetActive(true);
            _indexOfList++;
        }
    }
}
