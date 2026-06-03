using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController3D : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float rotationSpeed = 120f;

    [Header("Detección de suelo")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.25f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Interacción")]
    [SerializeField] private KeyCode interactionKey = KeyCode.F;
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private string targetTag = "Interactable";

    private Rigidbody rb;
    private Animator animator;

    private float horizontalInput;
    private float verticalInput;
    private bool jumpRequested;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ReadInput();
        RotatePlayer();
        CheckGround();
        UpdateAnimations();
        HandleInteraction();
    }

    private void FixedUpdate()
    {
        MovePlayer();

        if (jumpRequested)
        {
            Jump();
            jumpRequested = false;
        }
    }

    private void ReadInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    private void RotatePlayer()
    {
        float rotationInput = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationInput = -1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationInput = 1f;
        }

        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }

    private void MovePlayer()
    {
        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveDirection = transform.TransformDirection(inputDirection);

        Vector3 newVelocity = moveDirection * moveSpeed;
        newVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = newVelocity;
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(
            rb.linearVelocity.x,
            jumpForce,
            rb.linearVelocity.z
        );

        if (animator != null)
        {
            animator.SetTrigger("Jump");
        }
    }

    private void CheckGround()
    {
        if (groundCheck == null)
        {
            isGrounded = false;
            return;
        }

        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    private void UpdateAnimations()
    {
        if (animator == null)
        {
            return;
        }

        float speedValue = new Vector2(horizontalInput, verticalInput).magnitude;

        animator.SetFloat("Speed", speedValue);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void HandleInteraction()
    {
        if (!Input.GetKeyDown(interactionKey))
        {
            return;
        }

        if (animator != null)
        {
            animator.SetTrigger("Interact");
        }

        Vector3 origin = transform.position + Vector3.up;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origin, direction * interactionRange, Color.red, 2f);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, interactionRange))
        {
            Debug.Log("Objeto detectado: " + hit.collider.name);

            if (hit.collider.CompareTag(targetTag))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.Log("No se detectó ningún objeto interactuable.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
        {
            return;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
