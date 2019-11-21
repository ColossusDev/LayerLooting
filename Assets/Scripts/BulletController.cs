using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameObject player;

    Vector3 directionN;

    [SerializeField] float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        directionN = player.GetComponent<PlayerController>().getNormalizedDirection();

        Debug.Log("X" + directionN.x);
        Debug.Log("Y" + directionN.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.position + (directionN * speed) * Time.deltaTime;

        transform.position = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
