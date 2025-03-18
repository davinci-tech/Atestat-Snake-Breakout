using UnityEngine;

public class DaggerItemController : MonoBehaviour
{
    public void ChangePosition()
    {
        transform.position = new(
            Mathf.Round(Random.Range(Constants.Snake.bottomLeftLimit.x, Constants.Snake.upperRightLimit.x)),
            Mathf.Round(Random.Range(Constants.Snake.bottomLeftLimit.y, Constants.Snake.upperRightLimit.y))
        );
    }
}
