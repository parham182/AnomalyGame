using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform cam;
    [SerializeField] AudioSource walkAudioSource;
    [SerializeField] AudioClip[] walkClips;
    [SerializeField] float gravity = -20f;
    private CharacterController controller;

    Vector2 moveInput;
    private Vector3 velocity;

    public bool canMove = true;
    public bool IsMoving { get; private set; }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (walkAudioSource != null)
        {
            walkAudioSource.loop = true;
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        playerMove();
    }

    private void playerMove()
    {
        if (!canMove) return;
        
        Vector3 camForward = Quaternion.Euler(0, cam.eulerAngles.y, 0) * Vector3.forward;
        Vector3 camRight = Quaternion.Euler(0, cam.eulerAngles.y, 0) * Vector3.right;

        Vector3 moveDir = camRight * moveInput.x + camForward * moveInput.y;

        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        Vector3 finalMove = velocity * Time.deltaTime;
        controller.Move(finalMove);
    }
}
