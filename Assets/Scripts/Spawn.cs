using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 0.5f);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
