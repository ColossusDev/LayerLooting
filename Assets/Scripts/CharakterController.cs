using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterController : MonoBehaviour
{

    [SerializeField] float speed;

    private Rigidbody2D rigidbody2D;

    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        faceMouse();

        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2D.AddForce(Vector2.up * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidbody2D.AddForce(Vector2.down * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.AddForce(Vector2.right * speed);
        }
    }

    void faceMouse()
    {
        Vector3 mousepostion = Input.mousePosition;
        mousepostion = Camera.main.ScreenToWorldPoint(mousepostion);

        Vector2 direction = new Vector2(mousepostion.x - transform.position.x, mousepostion.y - transform.position.y);

        transform.right = direction;

    }
}
