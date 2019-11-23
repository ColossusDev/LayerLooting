using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject eButton;
    SpriteRenderer eButtonRenderer;
    void Start()
    {
        eButtonRenderer = eButton.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inRange()
    {
        eButtonRenderer.enabled = true;
    }

    public void notInRange()
    {
        eButtonRenderer.enabled = false;
    }
}
