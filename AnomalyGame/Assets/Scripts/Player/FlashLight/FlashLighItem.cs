using UnityEngine;

public class FlashLighItem : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.instance.flashLight.hasFlashLight = true;
        BoxMessage.instance.ShowMessage("flashlight: press (f) to on/off it", 3f);
        Destroy(gameObject);
    }
}
