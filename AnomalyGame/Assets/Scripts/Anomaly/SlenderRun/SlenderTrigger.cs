using UnityEngine;

public class SlenderTrigger : MonoBehaviour
{
    [SerializeField] AudioSource screamSound;
    [SerializeField] GameObject slender;

    private bool hasTriggerd = false;
    private bool canTrigger = false;

    void Start()
    {
        slender.SetActive(false);
    }

    private void OnEnable()
    {
        canTrigger = true;
    }

    private void OnDisable()
    {
        canTrigger = false;
        hasTriggerd = false;
        slender.SetActive(false);
        screamSound.Stop();
    }

    public void ActiveSlender()
    {
        if (hasTriggerd || canTrigger == false) return;

        hasTriggerd = true;
        slender.SetActive(true);
        screamSound.Play();
    }
}
