using UnityEngine;

public class FoodItemController : MonoBehaviour
{
    private Transform _transform;
    public Vector2 upperRightLimit = Constants.Snake.upperRightLimit;
    public Vector2 bottomLeftLimit = Constants.Snake.bottomLeftLimit;

    public void ChangePosition()
    {
        Vector2 newPosition = new(
            Mathf.Round(Random.Range(bottomLeftLimit.x, upperRightLimit.x)),
            Mathf.Round(Random.Range(bottomLeftLimit.y, upperRightLimit.y))
        );

        _transform.position = newPosition;
    }

    public void Start()
    {
        _transform = GetComponent<Transform>();
    }
}
