﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameObject player;

    Vector3 directionN;

    [SerializeField] float speed = 1;
    [SerializeField] float dmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        directionN = player.GetComponent<PlayerController>().getNormalizedDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.position + (directionN * speed) * Time.deltaTime;

        transform.position = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.GetComponent<EnemyScript>().gettingHit(dmg);
        }

        Destroy(this.gameObject);
    }
}
