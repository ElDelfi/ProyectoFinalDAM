using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{



    private EnemyDamaged enemyDamagedScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyDamagedScript = collision.gameObject.GetComponent<EnemyDamaged>();
            enemyDamagedScript.isKnockedDown = true;
        }
    }
}
