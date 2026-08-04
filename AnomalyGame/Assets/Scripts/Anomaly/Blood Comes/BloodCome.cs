using UnityEngine;

public class BloodCome : MonoBehaviour
{
    [SerializeField] Animator animator;

    private bool hasTriggerd = false;
    private bool canTrigger = false;

    private void OnEnable()
    {
        canTrigger = true;
    }

    private void OnDisable()
    {
        canTrigger = false;
        hasTriggerd = false;
        animator.SetTrigger("Idle");
    }

    public void Trigger()
    {
        if (hasTriggerd || canTrigger == false) return;

        hasTriggerd = false;
        animator.SetTrigger("Trigger");
    }
}
