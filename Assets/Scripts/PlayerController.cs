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

    private int laneIndex = 1;
    private float targetX;

    void Start()
    {
        targetX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            laneIndex = Mathf.Max(0, laneIndex - 1);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            laneIndex = Mathf.Min(2, laneIndex + 1);

        // left=-laneOffset, mid=0, right=+laneOffset
        targetX = (laneIndex - 1) * laneOffset;

        // Smooth move toward target X
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetX, laneChangeSpeed * Time.deltaTime);
        transform.position = pos;
    }
}
