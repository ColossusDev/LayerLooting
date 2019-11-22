using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] GameObject bullet;
    [SerializeField] int munition = 6;

    private Rigidbody2D rigid;
    private Vector2 direction;

    private GameObject lastInRange;

    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (munition > 0)
            {
                GameObject go = Instantiate(bullet, this.transform.position + (Vector3.Normalize(direction) / 2), this.transform.rotation);
                munition--;
            }
            else
            {
                // später Sound einbauen für leere Waffe
            }
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

        checkForItem();
    }

    void faceMouse()
    {
        Vector3 mousepostion = Input.mousePosition;
        mousepostion = Camera.main.ScreenToWorldPoint(mousepostion);

        direction = new Vector2(mousepostion.x - transform.position.x, mousepostion.y - transform.position.y);

        transform.right = direction;

    }

    void checkForItem()
    {
        // Das ist vermutlich die unperformanteste Stelle aller Zeit #PLS FIX
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction);

        if (hit.collider.gameObject.tag == "lootable" && hit.distance < 1)
            {
            hit.collider.gameObject.GetComponent<LootableController>().inRange();
            lastInRange = hit.collider.gameObject;
            }
        else if(lastInRange != null)
        { 
            lastInRange.GetComponent<LootableController>().notInRange();
            lastInRange = null;
        }
        

    }

    public Vector3 getNormalizedDirection()
    {
        return Vector3.Normalize(direction);
    }

    public int getMunition()
    {
        return munition;
    }
}
