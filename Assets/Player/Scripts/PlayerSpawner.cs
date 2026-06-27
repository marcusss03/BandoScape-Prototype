using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GridManager grid;
    public GameObject playerPrefab;
    public FollowPlayerOrbitingCamera MainCamera;

    public int spawnX = 5;
    public int spawnY = 0;

    void Start()
    {
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
        GameObject playerObj = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        MainCamera.Init(playerObj.transform);
    }
}
