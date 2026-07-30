using UnityEngine;

public class MainMenuSounds : MonoBehaviour
{
    [SerializeField] AudioSource audioSource; 
    [SerializeField] AudioClip doorOpenClip;
    [SerializeField] AudioClip doorCloseClip;
    [SerializeField] AudioClip BookFallClip;
    [SerializeField] AudioClip doorKnockClip;

    public void PlayOpenDoorSound()
    {
        SoundManager.instance.PlaySoundEffect(doorOpenClip, 0);
    }

    public void PlayCloseDoorSound()
    {
        SoundManager.instance.PlaySoundEffect(doorCloseClip, 0);
    }

    public void PlayBookFallSound()
    {
        if (BookFallClip == null) return;
        SoundManager.instance.PlaySoundEffect(BookFallClip, 0);
    }

    public void DoorKnockSound()
    {
        if (doorKnockClip == null) return;
        SoundManager.instance.PlaySoundEffect(doorKnockClip, 0);
    }
}
