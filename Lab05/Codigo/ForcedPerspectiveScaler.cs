using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForcedPerspectiveScaler : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private Camera playerCamera;

    [Header("Controles")]
    [SerializeField] private KeyCode pickupKey = KeyCode.E;
    [SerializeField] private KeyCode dropKey = KeyCode.Q;

    [Header("Configuración")]
    [SerializeField] private float rayDistance = 100f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float dropHeightOffset = 0.15f;

    private Rigidbody rb;
    private bool isHeld;

    private Vector3 originalScale;
    private float initialDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        HandleInput();

        if (isHeld)
        {
            FollowCameraRay();
            UpdateObjectScale();
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(pickupKey) && !isHeld)
        {
            PickUp();
        }

        if (Input.GetKeyDown(dropKey) && isHeld)
        {
            Drop();
        }
    }

    private void PickUp()
    {
        if (rayOrigin == null)
        {
            Debug.LogWarning("No se asignó el punto de origen del rayo.");
            return;
        }

        isHeld = true;

        rb.isKinematic = true;
        rb.useGravity = false;

        initialDistance = Vector3.Distance(rayOrigin.position, transform.position);

        if (initialDistance <= 0.01f)
        {
            initialDistance = 0.01f;
        }
    }

    private void Drop()
    {
        isHeld = false;

        rb.isKinematic = false;
        rb.useGravity = true;

        transform.position += Vector3.up * dropHeightOffset;

        rb.linearVelocity *= 0.5f;
        rb.angularVelocity = Vector3.zero;
    }

    private void FollowCameraRay()
    {
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, groundLayer))
        {
            transform.position = hit.point;
        }
    }

    private void UpdateObjectScale()
    {
        float currentDistance = Vector3.Distance(rayOrigin.position, transform.position);
        float scaleFactor = currentDistance / initialDistance;

        transform.localScale = originalScale * scaleFactor;
    }
}

