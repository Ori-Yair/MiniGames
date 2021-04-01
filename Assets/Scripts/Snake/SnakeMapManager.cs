using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMapManager : MonoBehaviour
{
    public GameObject wallPrefab;
    public Transform wallParent;
    
    private int mapWidth = 18;
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
            CreateWall(x, y);
        }
    }

    private void BuildHorizontalWall(int y)
    {
        for (int x = 1; x < mapWidth; x++)
        {
            CreateWall(x, y);
        }
    }

    private void CreateWall(int x, int y)
    {
        GameObject currWall = Instantiate(wallPrefab, new Vector2(x, y), Quaternion.identity);
        currWall.transform.SetParent(wallParent);
    }

    public bool CheckAlive(int x, int y)
    {
        foreach (Transform wall in wallParent)
        {
            if (x == wall.position.x && y == wall.position.y)
            {
                return false;
            }
        }

        return true;
    }
}
