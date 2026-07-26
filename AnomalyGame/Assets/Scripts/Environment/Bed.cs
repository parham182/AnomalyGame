using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (Player.instance.hasPills)
        {
            print("can sleep");
        } else
        {
            print("sleep");
        }
    }
}
