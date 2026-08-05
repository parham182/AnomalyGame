using UnityEngine;

public class SlenderTrigger : MonoBehaviour
{
    [SerializeField] AudioClip footSound;
    [SerializeField] AudioSource screamSound;
    [SerializeField] GameObject slender;

    private bool hasTriggerd = false;
    private bool canTrigger = false;

    public bool canCloseDoor = false;

    public static SlenderTrigger instance;

    void Awake()
    {
        instance = this;
    }

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
        // footSound.Stop();
        screamSound.Stop();
    }

    public void ActiveSlender()
    {
        if (canTrigger || hasTriggerd) return;

        slender.SetActive(true);

        hasTriggerd = true;
    }
    public void PlayFootStep()
    {
        SoundManager.instance.PlaySoundEffect(footSound);
    }
    public void PlayScream()
    {
        screamSound.Play();
    }
    public void AnimationOver()
    {
        canCloseDoor = true;
    }
}
