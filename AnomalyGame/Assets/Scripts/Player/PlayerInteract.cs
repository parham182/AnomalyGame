using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public InputActionReference interactButton;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;

    void OnEnable()
    {
        interactButton.action.Enable();
    }
   void OnDisable()
    {
        interactButton.action.Disable();
    }

    void Update()
    {
        if (interactButton.action.WasPressedThisFrame())
        {
            Ray ray = new Ray(playerCamera.transform.position,
                              playerCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
