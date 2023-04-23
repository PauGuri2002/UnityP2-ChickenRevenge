using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class chickenControl : MonoBehaviour
{
    [Header("Player Physics Parameters")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float gravity = 9.81f;

    private float speed;

    private float verticalMove;
    [HideInInspector] public Vector3 externalForces = Vector3.zero;

    private Vector2 move = new Vector2(0, 0);

    private bool isRunning;
    [HideInInspector] public bool movementEnabled = true;

    [Header("Dash Controls")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCD = 5f;
    private bool dashReady = true;
    private float dashPlayerControll = 1f;

    [Header("Camera")]
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject modelKFC;

    [Header("Player Animator")]
    [SerializeField] private Animator _playerAnimator;

    CharacterController characterController;

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
        if (!movementEnabled)
        {
            move = Vector2.zero;
            return;
        }

        move = WASD.ReadValue<Vector2>();
        _playerAnimator.SetBool("moving", move.magnitude > 0);
    }

    // Sprint Function
    public void OnSpeedUp(InputAction.CallbackContext theSpeed)
    {
        if (!movementEnabled)
        {
            _playerAnimator.SetFloat("Walk/Run", 0);
            isRunning = false;
            return;
        }

        if (theSpeed.started)
        {
            _playerAnimator.SetFloat("Walk/Run", 1);
            isRunning = true;
        }

        if (theSpeed.canceled)
        {
            _playerAnimator.SetFloat("Walk/Run", 0);
            isRunning = false;
        }
    }

    IEnumerator Dash()
    {
        float timeDash = Time.time;

        dashReady = false;

        while (Time.time < timeDash + dashTime)
        {
            dashPlayerControll = dashSpeed;
            yield return null;

        }

        dashPlayerControll = 1;
        yield return new WaitForSeconds(dashCD);
        dashReady = true;
    }
    public void OnDash(InputAction.CallbackContext theDash)
    {
        if (!movementEnabled) { return; }

        if (dashReady == true)
        {
            if (theDash.started)
            {
                _playerAnimator.SetTrigger("dash");
                StartCoroutine(Dash());
            }
        }
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
        characterController.Move((hvMove * dashPlayerControll + externalForces) * Time.deltaTime);
        if (horizontalMove.magnitude > 0) { modelKFC.transform.rotation = Quaternion.LookRotation(horizontalMove); }

        // reset all properties when grounded
        if (characterController.isGrounded)
        {
            verticalMove = 0;
        }
    }
}