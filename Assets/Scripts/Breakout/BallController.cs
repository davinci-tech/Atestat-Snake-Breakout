using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BreakoutGameManager _gameManger;
    public float minSpeed = 20;
    public float maxSpeed = 30;
    public Vector3 velocity;

    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _gameManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<BreakoutGameManager>();
        _rigidBody.linearVelocity = new(0, -minSpeed);
    }

    public void FixedUpdate()
    {
        _rigidBody.linearVelocity = Utility.ClampMagnitude(_rigidBody.linearVelocity, maxSpeed, minSpeed); // clamp the speed of the ball
        if (Math.Abs(_rigidBody.linearVelocity.y) < 1)
            _rigidBody.linearVelocity = new(_rigidBody.linearVelocity.x, Math.Sign(_rigidBody.linearVelocity.y));
        velocity = _rigidBody.linearVelocity;


        if (Math.Abs(transform.position.y) >= 30 || Math.Abs(transform.position.x) >= 30)
        {
            _gameManger.DestroyedBall();
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Breakout/Brick")
        {
            _gameManger.DestroyedBrick();
            collision.gameObject.GetComponent<BrickController>().destroy();
        }
    }
}