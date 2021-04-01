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

    private Vector2 startingPos = new Vector2(9, 5);

    // In seconds
    private float moveTimer = 0.4f;
    private float timePassed = 0.0f;

    private float moveDistance = 1.0f;
    private Direction moveDirection = Direction.Right;
    private Direction lastMoveDirection = Direction.Right;

    public GameObject snakePrefab;
    private List<GameObject> snake = new List<GameObject>();

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
        DestroySnake();
        snake.Add(Instantiate(snakePrefab, startingPos, Quaternion.identity));
        snake[0].transform.position = startingPos;

        snakeMapManager.ResetMap(startingPos);

        moveDirection = Direction.Right;
        lastMoveDirection = Direction.Right;

    }

    public void DestroySnake()
    {
        foreach (GameObject snakePart in snake)
        {
            Destroy(snakePart);
        }
        snake.Clear();
    }
    private void Move()
    {
        for (int i = snake.Count - 1; i > 0; i--)
        {
            snake[i].transform.position = snake[i - 1].transform.position;
        }

        switch (moveDirection)
        {
            case Direction.Up:
                snake[0].transform.position = new Vector2(snake[0].transform.position.x, snake[0].transform.position.y + moveDistance);
                break;
            case Direction.Down:
                snake[0].transform.position = new Vector2(snake[0].transform.position.x, snake[0].transform.position.y - moveDistance);
                break;
            case Direction.Right:
                snake[0].transform.position = new Vector2(snake[0].transform.position.x + moveDistance, snake[0].transform.position.y);
                break;
            case Direction.Left:
                snake[0].transform.position = new Vector2(snake[0].transform.position.x - moveDistance, snake[0].transform.position.y);
                break;
        }

    }

    private void CheckPosition()
    { 
        Vector2 snakePos = new Vector2(snake[0].transform.position.x, snake[0].transform.position.y);
        Vector2 tail = snakeMapManager.MoveSnake(snakePos);
        if (!tail.Equals(snakeMapManager.INVALIDPOS))
        {
            snake.Add(Instantiate(snakePrefab, tail, Quaternion.identity));
        }
        else
        {
            if (!snakeMapManager.CheckAlive(snakePos))
            {
                StartGame();
                return;
            }
        }

        lastMoveDirection = moveDirection;
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
