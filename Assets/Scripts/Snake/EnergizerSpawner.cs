using UnityEngine;

public class EnergizerSpawner : MonoBehaviour
{
    private SnakeScoreManager _scoreManager;
    public Transform energizerPrefab;

    public void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("Snake/ScoreManager").GetComponent<SnakeScoreManager>();
    }

    public void Update()
    {
        
    }
}
