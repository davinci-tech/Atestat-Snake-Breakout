using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EdgeCollider2D))]
public class GameControllerBehaviour : MonoBehaviour
{
    public void Awake()
    {
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();

        Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        Vector2 topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));
        Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
        Vector2 bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        
        edgeCollider.points = new Vector2[]{bottomLeft, topLeft, topRight, bottomRight};
    }

    public void OnBallEscaped() {
        Debug.Log("Ball Escaped. Resetting the scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
