using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float destroyBulletTimer = 5f;

    void Update()
    {
        destroyBulletTimer -= Time.deltaTime;
        if (destroyBulletTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        //if (true) AQUI HACER UN IF PARA VER SI LE DA A UN ENEMIGO O NO
        //{

        //}
        //en el futuro probablemente añadir si le da a más cosas como paredes
    }
}
