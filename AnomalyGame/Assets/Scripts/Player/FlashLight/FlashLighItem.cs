using UnityEngine;

public class FlashLighItem : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.instance.flashLight.hasFlashLight = true;
        Destroy(gameObject);
    }
}
