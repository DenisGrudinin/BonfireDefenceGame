using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Joystick joystick;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(h * speed, v * speed);
        }
        else 
        {
            float h = joystick.Horizontal;
            float v = joystick.Vertical;
            rb.velocity = new Vector2(h * speed, v * speed);
        }
    }
}
