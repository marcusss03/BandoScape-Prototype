using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GridManager grid;
    public GameObject playerPrefab;

    public int spawnX = 5;
    public int spawnY = 0;

    void Start()
    {
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
        Instantiate(playerPrefab, spawnPos, Quaternion.identity);
    }
}
