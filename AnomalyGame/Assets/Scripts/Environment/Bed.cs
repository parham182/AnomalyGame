using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip sleepSound;
    public void Interact()
    {
        if (Player.instance.hasPills)
        {
            SoundManager.instance.PlaySoundEffect(sleepSound);
            Player.instance.Sleep();
        } else
        {
            NotifManager.instance.ShowNotif("بدون قرص نمیتونم بخوابم", 3);
        }
    }
}
