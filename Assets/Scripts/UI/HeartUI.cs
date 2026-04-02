using UnityEngine;

public class HeartUI : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void Heal()
    {
        animator.SetBool("Broken", false);
    }

    public void GetDamaged()
    {
        animator.SetBool("Broken", true);
    }
}