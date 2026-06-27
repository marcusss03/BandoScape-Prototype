using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 20;
    public int height = 20;

    public TileLibrary tileLibrary;

    void Start()
    {
        RenderMap();
    }

    void RenderMap()
    {
        for (int x = 0; x < width; x += 2)
        {
            for (int y = 0; y < height; y += 2)
            {
                Vector3 pos = new Vector3(x, 0, y);
                Instantiate(tileLibrary.grassPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
