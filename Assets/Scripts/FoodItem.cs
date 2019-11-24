using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public GameObject effect;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    public void Use()
    {
        Instantiate(effect, player.position, Quaternion.identity);
        //Später hier noch Heal und Food hinzufügen
        Destroy(gameObject);
    }
}
