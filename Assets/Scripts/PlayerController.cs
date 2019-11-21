using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] GameObject bullet;

    private Rigidbody2D rigid;
    private Vector2 direction;

    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        faceMouse();

        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector2.up * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector2.down * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector2.right * speed);
        }

    }

    void faceMouse()
    {
        Vector3 mousepostion = Input.mousePosition;
        mousepostion = Camera.main.ScreenToWorldPoint(mousepostion);

        direction = new Vector2(mousepostion.x - transform.position.x, mousepostion.y - transform.position.y);

        transform.right = direction;

    }

    public Vector3 getDirection()
    {
        return direction;
    }
}
