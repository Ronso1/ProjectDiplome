using System.Collections.Generic;
using UnityEngine;

public class CheckLevelComplete : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lockers;
    [SerializeField] private LevelCompleteLogic _levelCompleteLogic;
    [SerializeField] private GameObject _triggerForGate;

    private void Start()
    {
        if (_levelCompleteLogic.LevelCompleted != 0)
        {
            _lockers[_levelCompleteLogic.LevelCompleted - 1].SetActive(false);
        }

        if (_levelCompleteLogic.LevelCompleted == 4)
        {
            _triggerForGate.SetActive(true);
        }
    }
}
