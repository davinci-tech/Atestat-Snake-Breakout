using UnityEngine;

public class LevelGeneratorBehaviour : MonoBehaviour
{
    [SerializeField] public GameObject brickPrefab;
    [SerializeField] public uint columns = 12;
    [SerializeField] public uint rows = 3;
    [SerializeField] public float offsetX = .2f;
    [SerializeField] public float offsetY = .1f;

    void Start()
    {
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < columns; col++) {
                GameObject brick = Instantiate(brickPrefab, transform);
                brick.transform.position += 
                    Vector3.right * col * (brick.GetComponent<SpriteRenderer>().bounds.size.x + offsetX) +
                    Vector3.down * row * (brick.GetComponent<SpriteRenderer>().bounds.size.y + offsetY);
            }
        }
    }
}
