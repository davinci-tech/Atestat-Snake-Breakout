using UnityEngine;

public class WallController : MonoBehaviour
{
    private BoxCollider2D _wallBoundries;
    public float xGap = 0;
    public float yGap = 0;
    public int columns = 7;
    public int rows = 5;
    public bool modify = true;
    public Transform brickPrefab;

    public void FixedUpdate()
    {
        _wallBoundries = GetComponent<BoxCollider2D>();
        if (modify)
        {
            SpawnWalls();
            modify = false;
        }
    }

    public void SpawnWalls()
    {
        Vector2 colliderSize = _wallBoundries.size;
        float totalWidth = colliderSize.x;
        float totalHeight = colliderSize.y;

        // Calculate brick dimensions accounting for gaps between them
        float brickWidth = (totalWidth - (columns - 1) * xGap) / columns;
        float brickHeight = (totalHeight - (rows - 1) * yGap) / rows;

        // Calculate starting position (bottom-left corner of grid)
        float startX = -totalWidth / 2 + brickWidth / 2;
        float startY = -totalHeight / 2 + brickHeight / 2;

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                // Calculate position with gaps incorporated in the spacing
                Vector3 brickPosition = new Vector3(
                    startX + col * (brickWidth + xGap),
                    startY + row * (brickHeight + yGap),
                    0f
                );

                Transform brick = Instantiate(brickPrefab, transform);
                brick.localPosition = brickPosition;
                brick.localScale = new Vector3(brickWidth, brickHeight, 1f);
            }
        }
    }

    public int BrickCount()
    {
        return columns * rows;
    }
}
