using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CameraRotation cameraRotation;
    [SerializeField] PlayerMovement playerMovement;

    public bool hasPills = false;
    public static Player instance;

    private void Awake() { instance = this; }

    public void DisableControl() {
        playerMovement.canMove = false;
        cameraRotation.enable = false;
    }

    public void EnableControl() {
        playerMovement.canMove = true;
        cameraRotation.enable = true;
    }

    public void Sleep()
    {
        print("player sleeped");
    }
}
