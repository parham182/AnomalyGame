using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    [SerializeField] InputActionReference flashlightToggel;
    [SerializeField] AudioSource audioSource;
    
    Light flashlight;
    bool isFlashLightOn;

    void OnEnable()
    {
        flashlightToggel.action.Enable();
    }
    void OnDisable()
    {
        flashlightToggel.action.Disable();
    }


    void Start()
    {
        flashlight = GetComponent<Light>();    
    }


    void Update()
    {
        if (flashlightToggel.action.WasCompletedThisFrame())
        {
            isFlashLightOn = !isFlashLightOn;
            flashlight.enabled = isFlashLightOn;
        }
    }
}
