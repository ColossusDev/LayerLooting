using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    GameObject player;
    [SerializeField] GameObject munText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int mun = player.GetComponent<PlayerController>().getMunition();
        munText.GetComponent<Text>().text = mun.ToString();
    }

}
