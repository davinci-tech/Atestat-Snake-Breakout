using System;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float _leftLimit;
    private float _rightLimit;
    private float _length;
    private Collider2D _collider;
    public EdgeCollider2D walls;

    public void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _length = _collider.bounds.max.x - _collider.bounds.min.x;
        _leftLimit = float.MaxValue;
        _rightLimit = float.MinValue;
        foreach (var point in walls.points)
        {
            _leftLimit = Math.Min(_leftLimit, point.x);
            _rightLimit = Math.Max(_rightLimit, point.x);
        }
    }

    public void Update()
    {
        float newX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if (newX + _length / 2 > _rightLimit)
            newX = _rightLimit - _length / 2;
        if (newX - _length / 2 < _leftLimit)
            newX = _leftLimit + _length / 2;

        transform.position = new(
            newX,
            transform.position.y
        );
    }
}
