using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        //if (true) AQUI HACER UN IF PARA VER SI LE DA A UN ENEMIGO O NO
        //{
            
        //}
        //en el futuro probablemente añadir si le da a más cosas como paredes
    }
}
