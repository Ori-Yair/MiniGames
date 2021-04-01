using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Down,
        Right,
        Up
    }

    // In seconds
    private float moveTimer = 0.6f;
    private float timePassed = 0.0f;

    private float moveDistance = 1.0f;
    private Direction moveDirection = Direction.Right;

    public GameObject snake;

    void FixedUpdate()
    {
        timePassed += Time.fixedDeltaTime;

        if (timePassed >= moveTimer)
        {
            Move();
            timePassed = 0;
        }
    }

    private void Move()
    {
        switch (moveDirection)
        {
            case Direction.Up:
                snake.transform.position = new Vector3(snake.transform.position.x, snake.transform.position.y + moveDistance, snake.transform.position.z);
                break;
            case Direction.Down:
                snake.transform.position = new Vector3(snake.transform.position.x, snake.transform.position.y - moveDistance, snake.transform.position.z);
                break;
            case Direction.Right:
                snake.transform.position = new Vector3(snake.transform.position.x + moveDistance, snake.transform.position.y, snake.transform.position.z);
                break;
            case Direction.Left:
                snake.transform.position = new Vector3(snake.transform.position.x - moveDistance, snake.transform.position.y, snake.transform.position.z);
                break;
        }
    }

    public void ChangeDirection(Direction moveDirection)
    {
        // If current and new direction are not opposite
        if (((int)this.moveDirection + (int)moveDirection) % 2 == 1)
            this.moveDirection = moveDirection;
       
    }

}
