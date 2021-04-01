using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMapManager : MonoBehaviour
{
    public Vector2 INVALIDPOS = new Vector2(-1, -1);

    public GameObject wallPrefab;
    public Transform wallParent;
    public GameObject cherriesPrefab;
    private GameObject cherries = null;
    
    private int mapWidth = 18;
    private int mapHeight = 10;

    private List<Vector2> snakePositions = new List<Vector2>();

    void Start()
    {
        BuildWall();
    }

    public void ResetMap(Vector2 startingPos)
    {
        FillSnakePositions(startingPos);
        Destroy(cherries);
        SpawnCherries();
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
            CreateWall(new Vector2(x, y));
        }
    }

    private void BuildHorizontalWall(int y)
    {
        for (int x = 1; x < mapWidth; x++)
        {
            CreateWall(new Vector2(x, y));
        }
    }

    private void CreateWall(Vector2 pos)
    {
        GameObject currWall = Instantiate(wallPrefab, pos, Quaternion.identity);
        currWall.transform.SetParent(wallParent);
    }

    public bool CheckAlive(Vector2 snakePosition)
    {
        foreach (Transform wall in wallParent)
        {
            if (snakePosition.Equals(new Vector2(wall.transform.position.x, wall.transform.position.y)))
            {
                return false;
            }
        }

        return true;
    }

    public void FillSnakePositions(Vector2 snakePos)
    {
        snakePositions.Clear();
        snakePositions.Add(snakePos);
    }

    public Vector2 MoveSnake(Vector2 newPos)
    {
        snakePositions.Insert(0, newPos);
        if (!CheckAteCherries(newPos))
        {
            snakePositions.RemoveAt(snakePositions.Count - 1);
            return INVALIDPOS;
        }
        return snakePositions[snakePositions.Count - 1];
    }

    private bool CheckAteCherries(Vector2 snakePos)
    {
        if (snakePos.Equals(new Vector2(cherries.transform.position.x, cherries.transform.position.y)))
        {
            Destroy(cherries);
            SpawnCherries();
            return true;
        }

        return false;
    }

    public void SpawnCherries()
    {
        int x = 0;
        int y = 0; 

        do
        {
            x = Random.Range(1, mapWidth);
            y = Random.Range(1, mapHeight);
        } while (snakePositions.Contains(new Vector2(x, y)));

        cherries = Instantiate(cherriesPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
