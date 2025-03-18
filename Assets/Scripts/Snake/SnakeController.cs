using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    private Vector3 _direction = Vector2.left;
    private Transform _transform;
    private Vector2 _actualPosition;
    private List<Transform> _segments;
    private SnakeScoreManager _scoreManager;
    private SnakeTimeManager _timeManager;
    public Transform snakeSegmentPrefab;
    public float speed = .25f;
    public float speedMultiplier = .05f;
    public static int initialLength = 3;

    public void Start()
    {
        _transform = GetComponent<Transform>();
        _actualPosition = _transform.position;
        _scoreManager = GameObject.FindGameObjectWithTag("Snake/ScoreManager").GetComponent<SnakeScoreManager>();
        _timeManager = GameObject.FindGameObjectWithTag("Snake/TimeManager").GetComponent<SnakeTimeManager>();
        InitializeSegments();
    }

    public void Update()
    {
        Vector3 newDirection = _direction;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            newDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            newDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            newDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            newDirection = Vector2.left;
        }

        // do not let the user bite itself by going back
        if (newDirection != -1 * _direction)
        {
            // do not immediately set the direction, put it in the queue instead
            _direction = newDirection;
        }
    }

    public void FixedUpdate()
    {
        _actualPosition = new Vector2(
            _actualPosition.x + _direction.x * speed,
            _actualPosition.y + _direction.y * speed
        );

        var newPosition = new Vector3(
            Mathf.Round(_actualPosition.x),
            Mathf.Round(_actualPosition.y)
        );

        if (newPosition != _segments[0].position)
        {
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
                Assert.AreEqual(_segments[i].position.x * 100 % 100, 0); // make sure it is an integer
            }

            _segments[0].position = newPosition;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Snake/Food")
        {
            collider.gameObject.GetComponent<FoodItemController>().ChangePosition();
            Grow();
            _scoreManager.AteFood();
        }
        else if (collider.tag == "Snake/Energizer")
        {
            collider.gameObject.GetComponent<EnergizerItemController>().ChangePosition();
            _scoreManager.AteEnergizer();
            speed += speedMultiplier;
        }
        else if (collider.tag == "Snake/Dagger")
        {
            Destroy(collider.GameObject());
            _scoreManager.AteDagger(); // half the score
            _timeManager.AteDagger(); // double the time
            int cntToRemove = (_segments.Count - 1) / 2; // half the length of the snake
            for (int i = 0; i < cntToRemove; i++)
            {
                Destroy(_segments[^1].gameObject);
                _segments.Remove(_segments[^1]);
            }
        }
        else if (collider.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(snakeSegmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    public void InitializeSegments()
    {
        _segments = new List<Transform> { _transform };
        for (int i = 1; i <= initialLength; i++)
        {
            Transform newSegment = Instantiate(snakeSegmentPrefab).transform;
            newSegment.position = _transform.position - _direction * i; // add segments in the opposite direction
            _segments.Add(newSegment);
        }
    }

}
