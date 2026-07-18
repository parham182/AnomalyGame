using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float cameraSens = 0.1f;
    [SerializeField] Transform playerBody;
    [SerializeField] float xClampMin = -90f;
    [SerializeField] float xClampMax = 90f;
    [SerializeField] RectTransform cameraTouchArea;
    
    private Vector2 lookInput;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private bool isTouchingCameraArea = false;
    private int touchFingerId = -1;

    void Start()
    {
        xRotation = transform.localEulerAngles.x;
        if (xRotation > 180f) xRotation -= 360f;
        
        yRotation = playerBody != null ? playerBody.localEulerAngles.y : 0f;
    }

    void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Touchscreen.current == null) return;

        var touches = Touchscreen.current.touches;
        
        for (int i = 0; i < touches.Count; ++i)
        {
            var touch = touches[i];
            
            if (touch.press.wasPressedThisFrame)
            {
                Vector2 touchPos = touch.position.ReadValue();
                
                if (IsPointerOverUI(touchPos))
                {
                    continue; 
                }
                
                if (IsTouchInCameraArea(touchPos))
                {
                    isTouchingCameraArea = true;
                    touchFingerId = i;
                }
            }
            else if (touch.press.wasReleasedThisFrame && touchFingerId == i)
            {
                isTouchingCameraArea = false;
                touchFingerId = -1;
            }

            if (isTouchingCameraArea && touchFingerId == i && touch.press.isPressed)
            {
                Vector2 delta = touch.delta.ReadValue();
                lookInput = delta * cameraSens;
                MoveCamera();
            }
        }
    }

    private bool IsTouchInCameraArea(Vector2 touchPosition)
    {
        if (cameraTouchArea == null) 
            return !IsPointerOverUI(touchPosition); 

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            cameraTouchArea, 
            touchPosition, 
            null, 
            out Vector2 localPoint
        );
        
        return cameraTouchArea.rect.Contains(localPoint);
    }

    private bool IsPointerOverUI(Vector2 screenPosition)
    {
        if (EventSystem.current == null) return false;
        
        var pointerData = new PointerEventData(EventSystem.current)
        {
            position = screenPosition
        };
        
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        
        return results.Count > 0;
    }

    private void MoveCamera()
    {
        yRotation += lookInput.x;
        xRotation -= lookInput.y;
        xRotation = Mathf.Clamp(xRotation, xClampMin, xClampMax);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        if (playerBody != null)
        {
            playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }}
