using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private GameObject[] enemies;

    public Sprite openVan;
    private GameObject van;
    public GameObject exitZone;
    public TextMeshProUGUI vanText;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        van = GameObject.FindGameObjectWithTag("Van");
    }


    void Update()
    {
        if (allEnemiesDead())
        {
            van.GetComponent<SpriteRenderer>().sprite = openVan;
            exitZone.SetActive(true);
            vanText.gameObject.SetActive(true);
            Destroy(this);
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
