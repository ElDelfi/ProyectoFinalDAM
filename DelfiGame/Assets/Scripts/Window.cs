using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite brokenWindow;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet"|| collision.gameObject.tag == "Weapon")
        {
            FindObjectOfType<AudioManager>().Play("Glass");
            GetComponent<BoxCollider2D>().enabled = false;
            spriteRenderer.sprite = brokenWindow;
            spriteRenderer.sortingOrder = 1; //para que no de problemas 
        }
    }
}
