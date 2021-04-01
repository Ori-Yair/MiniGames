using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayerController : MonoBehaviour
{
    private SnakeMove snakeMove;

    void Start()
    {
        snakeMove = FindObjectOfType<SnakeMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            snakeMove.ChangeDirection(SnakeMove.Direction.Up);
        }
        if (Input.GetKey("down"))
        {
            snakeMove.ChangeDirection(SnakeMove.Direction.Down);
        }
        if (Input.GetKey("right"))
        {
            snakeMove.ChangeDirection(SnakeMove.Direction.Right);
        }
        if (Input.GetKey("left"))
        {
            snakeMove.ChangeDirection(SnakeMove.Direction.Left);
        }
    }
}
