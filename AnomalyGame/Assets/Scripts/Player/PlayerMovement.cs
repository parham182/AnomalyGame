using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] Transform camHolder;
    [SerializeField] Animator camAnimator;
    [SerializeField] float gravity = -20f;
    [SerializeField] Joystick joystick;
    private CharacterController controller;

    Vector2 moveInput;
    private Vector3 velocity;

    public bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveInput.x = joystick.Horizontal;
        moveInput.y = joystick.Vertical;
        playerMove();
    }

    private void playerMove()
    {
        if (!canMove)
        {
            camAnimator.SetInteger("State", 1);
            return;
        }
        float speed = 0;
        
        Vector3 camForward = Quaternion.Euler(0, camHolder.eulerAngles.y, 0) * Vector3.forward;
        Vector3 camRight = Quaternion.Euler(0, camHolder.eulerAngles.y, 0) * Vector3.right;

        Vector3 moveDir = (camRight * moveInput.x + camForward * moveInput.y).normalized;

        // run or walk
        if (moveInput.y >= 0.9)
        {
            // run
            speed = runSpeed;
            camAnimator.SetInteger("State", 3);
        } else if (moveInput.x != 0 && moveInput.y != 0)
        {
            // walk
            speed = walkSpeed;
            camAnimator.SetInteger("State", 2);
        } else camAnimator.SetInteger("State", 1); // idle camera animation

        controller.Move(moveDir * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        Vector3 finalMove = velocity * Time.deltaTime;
        controller.Move(finalMove);
    }
}
