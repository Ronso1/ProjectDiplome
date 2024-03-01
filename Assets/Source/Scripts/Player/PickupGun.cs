using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField] private GameObject _gun;
    [SerializeField] private Camera _playerCamera;
    [Space]
    [SerializeField] private float _distanceToInteract = 2f;

    public void TakeGun()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distanceToInteract))
        {
            if (hitInfo.transform.tag == "Gun")
            {
                hitInfo.transform.gameObject.SetActive(false);
                _gun.gameObject.SetActive(true);
            }
        }
    }
}
