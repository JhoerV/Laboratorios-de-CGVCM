using UnityEngine;

public class CardinalCameraSwitcher : MonoBehaviour
{
    [Header("Referencia principal")]
    [SerializeField] private Transform pivot;

    [Header("Configuración de cámara")]
    [SerializeField] private float radius = 50f;
    [SerializeField] private float height = 10f;
    [SerializeField] private Vector3 lookOffset = new Vector3(0f, 1.5f, 0f);
    [SerializeField] private float moveSmoothSpeed = 3f;
    [SerializeField] private float rotationSmoothSpeed = 3f;

    [Header("Controles")]
    [SerializeField] private KeyCode previousViewKey = KeyCode.Q;
    [SerializeField] private KeyCode nextViewKey = KeyCode.E;

    private int currentViewIndex;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private readonly Vector3[] cardinalDirections =
    {
        Vector3.forward,
        Vector3.right,
        Vector3.back,
        Vector3.left
    };

    private void Start()
    {
        CalculateTargetTransform();
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }

    private void Update()
    {
        HandleInput();
        MoveCamera();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(previousViewKey))
        {
            currentViewIndex--;

            if (currentViewIndex < 0)
            {
                currentViewIndex = cardinalDirections.Length - 1;
            }

            CalculateTargetTransform();
        }

        if (Input.GetKeyDown(nextViewKey))
        {
            currentViewIndex++;

            if (currentViewIndex >= cardinalDirections.Length)
            {
                currentViewIndex = 0;
            }

            CalculateTargetTransform();
        }
    }

    private void CalculateTargetTransform()
    {
        if (pivot == null)
        {
            return;
        }

        Vector3 direction = cardinalDirections[currentViewIndex];

        targetPosition = pivot.position - direction * radius + Vector3.up * height;

        Vector3 lookTarget = pivot.position + lookOffset;
        Vector3 lookDirection = lookTarget - targetPosition;

        targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    }

    private void MoveCamera()
    {
        if (pivot == null)
        {
            return;
        }

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * moveSmoothSpeed
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * rotationSmoothSpeed
        );
    }
}
