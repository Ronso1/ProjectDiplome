using System.Collections.Generic;
using UnityEngine;

public class CheckLevelComplete : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lockers;
    [SerializeField] private LevelCompleteLogic _levelCompleteLogic;
    [SerializeField] private GameObject _triggerForGate;
    [SerializeField] private GameObject _startMessage;

    private void Start()
    {
        if (_levelCompleteLogic.LevelCompleted != 0)
        {
            _startMessage.SetActive(false);
            for (int i = 0; i < _levelCompleteLogic.LevelCompleted; i++)
            {
                _lockers[i].SetActive(false);
            }      
        }

        if (_levelCompleteLogic.LevelCompleted == 4)
        {
            _triggerForGate.SetActive(true);
        }
    }
}
