using UnityEngine;

public class DestroyBehindPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player.position.z - transform.position.z > 10f)
        {
            Destroy(gameObject);
        }
    }
}
