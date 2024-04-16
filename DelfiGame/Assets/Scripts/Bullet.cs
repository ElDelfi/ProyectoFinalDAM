using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float destroyBulletTimer = 5f;
    public GameObject bulletImpactPrefab;
    public GameObject bulletBloodPrefab;

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
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "FirePoint")
        {
            if (collision.gameObject.tag == "Enemy") //AQUI HACER UN IF PARA VER SI LE DA A UN ENEMIGO O NO
            {
                Instantiate(bulletBloodPrefab, this.transform.position, this.transform.rotation);

            }
            else
            {
                Instantiate(bulletImpactPrefab, this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
}
