using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    Transform[] tiles;

    float tileLength;
    float halfTileLength;
    int currentLineIndex = 0;

    void Start()
    {
        // Works for Plane/Cube/etc.
        tileLength = tiles[0].GetComponent<Renderer>().bounds.size.z;
        halfTileLength = tileLength / 2f;
    }

    void Update()
    {
        // Move the next tile when player passes its FRONT edge
        if (player.position.z > tiles[currentLineIndex].position.z + halfTileLength + 10f)
        {
            MoveTileToFront();
        }
    }

    void MoveTileToFront()
    {
        Transform tile = tiles[currentLineIndex];

        // Find the furthest tile (highest Z center)
        float maxZ = tiles[0].position.z;
        for (int i = 1; i < tiles.Length; i++)
            if (tiles[i].position.z > maxZ)
                maxZ = tiles[i].position.z;

        // Move this tile to be after the furthest tile
        tile.position = new Vector3(tile.position.x, tile.position.y, maxZ + tileLength);

        currentLineIndex = (currentLineIndex + 1) % tiles.Length;
    }
}
