using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public bool isAlive;
    public bool NextState;

    private Rect collisionBox;
    Color colorAlive = new Color(0f, 1f, 0f);
    Color colorDead = new Color(1f, 0f, 0f);

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isAlive)
        {
            GetComponent<SpriteRenderer>().color = colorAlive;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = colorDead;
        }
    }
}