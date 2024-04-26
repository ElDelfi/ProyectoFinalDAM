using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float destroyBulletTimer = 5f;
    public GameObject bulletImpactPrefab;
    public GameObject bulletBloodPrefab;
    private EnemyDamaged enemyDamagedScript;

    private PlayerDeathController playerDeathController;

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
                enemyDamagedScript = collision.gameObject.GetComponent<EnemyDamaged>();
                enemyDamagedScript.killedByBullet();
            }
            else if (collision.gameObject.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play("Die");

                playerDeathController = collision.gameObject.GetComponent<PlayerDeathController>();
                playerDeathController.isDead = true;
            }
            else
            {
                Instantiate(bulletImpactPrefab, this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyDamaged>().gloryKill();
            Instantiate(bulletBloodPrefab, this.transform.position, this.transform.rotation);

        }
    }
}
