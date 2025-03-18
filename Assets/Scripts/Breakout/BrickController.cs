using UnityEngine;

public class BrickController : MonoBehaviour
{
    private BrickType _type;
    private BreakoutGameManager _gameManager;
    public Transform ballPrefab;

    public void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<BreakoutGameManager>();
        _type = RandomType();
        if (_type == BrickType.MORE_BALLS)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    public void destroy()
    {
        if (_type == BrickType.MORE_BALLS)
        {
            Instantiate(ballPrefab).position = transform.position;
            _gameManager.CreatedBall();
        }

        Destroy(gameObject);
    }

    public BrickType RandomType()
    {
        float value = Mathf.Round(Random.Range(1, 100));
        if (value <= 10) // 1 in 10 bricks should spawn more balls when destroyed
            return BrickType.MORE_BALLS;
        return BrickType.CLASSIC;
    }
}

public enum BrickType
{
    MORE_BALLS,
    CLASSIC,
}