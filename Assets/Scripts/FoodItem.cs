using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    public void Use()
    {
        //Später hier noch Heal und Food hinzufügen
        Destroy(gameObject);
    }
}
