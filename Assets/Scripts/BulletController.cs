using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameObject player;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        direction = player.GetComponent<PlayerController>().getDirection();

        Debug.Log("X" + direction.x);
        Debug.Log("Y" + direction.y);
        Debug.Log("Z" + direction.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.position + direction * Time.deltaTime;

        transform.position = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(this.gameObject);
    }
}
