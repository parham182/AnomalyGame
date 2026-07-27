using System;
using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip takePill;
    [SerializeField] GameObject uiPill;
    public void Interact()
    {
        Player.instance.hasPills = true;
        SoundManager.instance.PlaySoundEffect(takePill);
        uiPill.SetActive(true);
        Destroy(gameObject);
    }
}
