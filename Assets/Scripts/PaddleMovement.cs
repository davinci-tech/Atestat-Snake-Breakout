using System;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position = new Vector3(
            Mathf.Clamp(
                transform.position.x,
                Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x + transform.lossyScale.x / 2,
                Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane)).x - transform.lossyScale.x / 2
            ),
            transform.position.y,
            transform.position.z
        );
    }
}
