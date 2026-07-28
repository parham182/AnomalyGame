using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip sleepSound;
    [SerializeField] PillChoseManager pillChoseManager;
    public void Interact()
    {
        if (Player.instance.hasPills)
        {
            // SoundManager.instance.PlaySoundEffect(sleepSound);
            // open pill selecting options
            pillChoseManager.OpenOptions();
        } else
        {
            NotifManager.instance.ShowNotif("بدون قرص نمیتونم بخوابم", 3);
        }
    }
}
