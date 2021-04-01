using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMapManager : MonoBehaviour
{
    public GameObject wall;
    
    private int mapWidth = 17;
    private int mapHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        BuildWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildWall()
    {
        BuildVerticalWall(0);
        BuildVerticalWall(mapWidth);
        BuildHorizontalWall(0);
        BuildHorizontalWall(mapHeight);
    }

    private void BuildVerticalWall(int x)
    {
        for (int y = 0; y < mapHeight + 1; y++)
        {
            Instantiate(wall, new Vector2(x, y), Quaternion.identity);
        }
    }

    private void BuildHorizontalWall(int y)
    {
        for (int x = 1; x < mapWidth; x++)
        {
            Instantiate(wall, new Vector2(x, y), Quaternion.identity);
        }
    }
}
