using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Forward Movement")]
    [SerializeField]
    private float forwardSpeed = 8f;

    [Header("Lane Movement")]
    [SerializeField]
    private float laneOffset = 2f;

    [SerializeField]
    private float laneChangeSpeed = 12f;

    [Header("Jump")]
    [SerializeField]
    private float jumpForce = 7f;

    [SerializeField]
    private float groundCheckDistance = 0.2f;

    [SerializeField]
    private LayerMask groundMask = ~0;

    private int laneIndex = 1;
    private float targetX;

    private bool isGrounded;
    private Rigidbody rb;
    private CapsuleCollider col;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        targetX = transform.position.x;
    }

    void Update()
    {
        CheckGround();
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        // Constant forward movement (+Z)
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        // Lane input
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            laneIndex = Mathf.Max(0, laneIndex - 1);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            laneIndex = Mathf.Min(2, laneIndex + 1);

        // Target x for lane
        targetX = (laneIndex - 1) * laneOffset;

        // Smooth x move
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetX, laneChangeSpeed * Time.deltaTime);
        transform.position = pos;
    }

    void HandleJump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Reset vertical speed so jump is consistent
            Vector3 v = rb.linearVelocity;
            v.y = 0f;
            rb.linearVelocity = v;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CheckGround()
    {
        // Raycast from near the bottom of the capsule
        Vector3 bottom = col.bounds.center;
        bottom.y = col.bounds.min.y + 0.05f;

        isGrounded = Physics.Raycast(bottom, Vector3.down, groundCheckDistance, groundMask);

        // Debug line (visible in Scene view while playing)
        Debug.DrawRay(
            bottom,
            Vector3.down * groundCheckDistance,
            isGrounded ? Color.green : Color.red
        );
    }
}
