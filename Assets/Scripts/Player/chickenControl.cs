using UnityEngine;
using UnityEngine.InputSystem;

public class chickenControl : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float gravity = 9.81f;

    [SerializeField] private GameObject cam;

    [SerializeField]
    private Animator _playerAnimator;

    CharacterController characterController;

    public float speed;

    private float verticalMove;

    private Vector2 move = new Vector2(0, 0);

    private bool isRunning;

    [SerializeField] private GameObject modelKFC;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        speed = walkSpeed;
    }

    void Update()
    {
        Movement();

        if (characterController.isGrounded)
        {
            if (isRunning)
            {
                speed = runSpeed;
            }
            else
            {
                speed = walkSpeed;
            }
        }

        else
        {
            if (!isRunning)
            {
                speed = walkSpeed;
            }
        }
    }

    public void OnMove(InputAction.CallbackContext WASD)
    {
        move = WASD.ReadValue<Vector2>();
    }

    // Sprint Function
    public void OnSpeedUp(InputAction.CallbackContext theSpeed)
    {
        if (theSpeed.started)
        {
            isRunning = true;
        }

        if (theSpeed.canceled)
        {
            isRunning = false;
        }
    }
    public void OnDash(InputAction.CallbackContext theJump)
    {
        // code dash
    }

    void Movement()
    {
        if (characterController.enabled == false) { return; }

        verticalMove -= gravity * Time.deltaTime;

        //camera direction
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 horizontalMove = forward * move.y + right * move.x;

        Vector3 hvMove = new Vector3(horizontalMove.x * speed, verticalMove, horizontalMove.z * speed);
        characterController.Move(hvMove * Time.deltaTime);

        if (horizontalMove.magnitude > 0) { modelKFC.transform.rotation = Quaternion.LookRotation(horizontalMove); }

        // reset all properties when grounded
        if (characterController.isGrounded)
        {
            verticalMove = 0;
        }
    }

    public void Flying(bool value)
    {
        _playerAnimator.SetBool("flying", value);
    }
}