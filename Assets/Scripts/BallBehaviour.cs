using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] public float speed = 10f;
    [SerializeField] public UnityEvent ballEscaped;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.linearVelocity =  (3 * Vector2.up + Vector2.right) * speed;
    }

    void Update()
    {
        Vector3 viewportCoordinates = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportCoordinates.y < 0) {
            ballEscaped.Invoke();
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = rigidbody2D.linearVelocity.normalized * speed;
    }

    void OnCollisionExit2D(Collision2D collision) {
        speed += 0.02f;
        if (collision.gameObject.tag == "Brick") {
            Destroy(collision.gameObject);
        } else if (collision.gameObject.name == "Paddle") {
            Debug.Log("Paddle");
        }
    }
}
