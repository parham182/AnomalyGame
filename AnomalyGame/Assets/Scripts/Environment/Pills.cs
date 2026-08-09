using System;
using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip takePill;

    public void Interact()
    {
        Player.instance.hasPills = true;
        SoundManager.instance.PlaySoundEffect(takePill);
        // NotifManager.instance.ShowNotif("قرص های خواب", 3);
        Destroy(gameObject);
    }
}
