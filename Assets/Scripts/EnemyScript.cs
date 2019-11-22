using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    GameObject player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movespeed;
    private Vector2 movement;

    private bool activ = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (activ == true)
        {
            Vector3 direction = player.transform.position - this.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            rb.rotation = angle;

            direction.Normalize();
            movement = direction;
            rb.MovePosition(transform.position + (direction * movespeed * Time.deltaTime));
        }
        else
        {
            checkForPlayerInRange();
        }
        
    }

    void checkForPlayerInRange()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 2)
        {
            activ = true;
        }
    }
}
