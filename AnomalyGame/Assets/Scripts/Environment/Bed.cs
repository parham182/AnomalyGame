using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip sleepSound;
    [SerializeField] GameObject uiNotif;
    public void Interact()
    {
        if (Player.instance.hasPills)
        {
            SoundManager.instance.PlaySoundEffect(sleepSound);
            Player.instance.Sleep();
        } else
        {
            uiNotif.SetActive(true);
        }
    }
}
