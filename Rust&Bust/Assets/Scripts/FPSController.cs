using UnityEngine;

public class FPSController : MonoBehaviour
{
    public Transform cameraTransform;
    private Rigidbody rb;

    public float moveSpeed = 6f;
    public float sprintSpeed = 10f;
    public float crouchSpeed = 3f;
    public float jumpForce = 5f;

    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    private bool isGrounded;

    private bool isCrouching = false;
    public float crouchCameraOffset = 0.5f; // how much the camera moves down

    private Vector3 originalCameraPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalCameraPosition = cameraTransform.localPosition;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            moveSpeed = sprintSpeed;
        }
        else if (isCrouching)
        {
            moveSpeed = crouchSpeed;
        }
        else
        {
            moveSpeed = 6f;
        }

        // Crouch with Ctrl
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (!isCrouching) StartCrouch();
        }
        else
        {
            if (isCrouching) StopCrouch();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        Vector3 velocity = moveDirection * moveSpeed;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void StartCrouch()
    {
        isCrouching = true;
        cameraTransform.localPosition = originalCameraPosition - new Vector3(0f, crouchCameraOffset, 0f);
    }

    void StopCrouch()
    {
        isCrouching = false;
        cameraTransform.localPosition = originalCameraPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}