using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    private SnakeMapManager snakeMapManager;

    public enum Direction
    {
        Left,
        Down,
        Right,
        Up
    }

    private int startingX = 9;
    private int startingY = 5;

    // In seconds
    private float moveTimer = 0.4f;
    private float timePassed = 0.0f;

    private float moveDistance = 1.0f;
    private Direction moveDirection = Direction.Right;
    private Direction lastMoveDirection = Direction.Right;

    public GameObject snake;

    void Start()
    {
        snakeMapManager = FindObjectOfType<SnakeMapManager>();

        StartGame();
    }

    void FixedUpdate()
    {
        timePassed += Time.fixedDeltaTime;

        if (timePassed >= moveTimer)
        {
            Move();
            CheckPosition();
            timePassed = 0;
        }
    }

    public void StartGame()
    {
        snake.transform.position = new Vector2(startingX, startingY);
        snakeMapManager.FillSnakePositions(new Vector2(startingX, startingY));

        moveDirection = Direction.Right;
        lastMoveDirection = Direction.Right;

    }

    private void Move()
    {
        switch (moveDirection)
        {
            case Direction.Up:
                snake.transform.position = new Vector2(snake.transform.position.x, snake.transform.position.y + moveDistance);
                break;
            case Direction.Down:
                snake.transform.position = new Vector2(snake.transform.position.x, snake.transform.position.y - moveDistance);
                break;
            case Direction.Right:
                snake.transform.position = new Vector2(snake.transform.position.x + moveDistance, snake.transform.position.y);
                break;
            case Direction.Left:
                snake.transform.position = new Vector2(snake.transform.position.x - moveDistance, snake.transform.position.y);
                break;
        }

        
    }

    private void CheckPosition()
    { 
        if (snakeMapManager.MoveSnake(new Vector2(snake.transform.position.x, snake.transform.position.y)))
        {
            lastMoveDirection = moveDirection;
        }
        else
        {
            StartGame();
        }
    }

    public void ChangeDirection(Direction moveDirection)
    {
        // If last and new direction are not opposite
        if (((int)lastMoveDirection + (int)moveDirection) % 2 == 1)
        {
            this.moveDirection = moveDirection;
        }
    }

}
