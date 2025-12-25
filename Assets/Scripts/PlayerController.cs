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
        transform.Translate(Vector3.forward * forwardSpeed * TimeOnly.deltaTime);

    }
}
