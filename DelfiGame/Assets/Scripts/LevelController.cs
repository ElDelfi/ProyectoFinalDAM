using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private GameObject[] enemies;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }


    void Update()
    {
        if (allEnemiesDead())
        {
            Debug.Log("FIN DEL JUEGO");
        }
    }

    private bool allEnemiesDead() {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].tag != "Dead")
            {
                return false;
            }
        }
        return true;
    }
}
