using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (Player.instance.hasPills)
        {
            Player.instance.Sleep();
        } else
        {
            print("need pills to sleep");
        }
    }
}
