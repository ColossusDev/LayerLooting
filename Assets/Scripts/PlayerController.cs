using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float movespeed;

    [SerializeField] GameObject bullet;
    [SerializeField] int munition = 6;

    [SerializeField] Camera cam;

    private Rigidbody2D rigid;
    private Vector2 direction;
    private Vector2 movement;

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

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        faceMouse();

        checkForItem();

        rigid.MovePosition(rigid.position + movement * movespeed * Time.deltaTime);

        Vector3 camPos = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        cam.transform.position = camPos;
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

        if (hit == true)
        {
            if (hit.collider.gameObject.tag == "lootable" && hit.distance < 1)
            {
                hit.collider.gameObject.GetComponent<LootableController>().inRange();
                lastInRange = hit.collider.gameObject;
            }
            else if (lastInRange != null)
            {
                lastInRange.GetComponent<LootableController>().notInRange();
                lastInRange = null;
            }
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
