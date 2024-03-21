using UnityEngine;

public class PartLevelOpen : MonoBehaviour
{
    [SerializeField] private GameObject _entrance;
    [SerializeField] private GameObject _entranceSecond;

    public int Count;

    private void Update()
    {
        if (Count == 3)
        {
            _entrance.SetActive(false);
            _entranceSecond.SetActive(false);
        }
    }
}
