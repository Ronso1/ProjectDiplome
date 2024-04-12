using System.Collections.Generic;
using UnityEngine;

public class CheckLevelComplete : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lockers;
    [SerializeField] private List<GameObject> _lvls;
    [SerializeField] private LevelCompleteLogic _levelCompleteLogic;
    [SerializeField] private GameObject _triggerForGate;
    [SerializeField] private GameObject _startMessage;
    private static int[] _levelsCompleted = new int[4];

    private void Start()
    {
        if (_levelCompleteLogic.LevelCompleted != 0)
        {
            _startMessage.SetActive(false);
            _levelsCompleted[_levelCompleteLogic.LevelID - 1] = 1;

            for (int i = 0; i < _lvls.Count; i++)
            {
                if (_levelsCompleted[i] == 1)
                {
                    _lockers[i].SetActive(false);
                    _lvls[i].SetActive(false);
                }
            }
        }

        if (_levelCompleteLogic.LevelCompleted == 4)
        {
            _triggerForGate.SetActive(true);
        }
    }
}
