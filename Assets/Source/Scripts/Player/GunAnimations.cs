using UnityEngine;

public class GunAnimations : MonoBehaviour
{
    [SerializeField] private Animator _gunAnimator;

    public void PlayWalkingAnimation()
    {
        _gunAnimator.SetBool("isWalking", true);
    }

    public void StopWalkingAnimation()
    {
        _gunAnimator.SetBool("isWalking", false);
    }
}
