using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.instance.hasPills = true;
    }
}
