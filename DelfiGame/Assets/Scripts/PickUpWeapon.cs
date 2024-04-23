using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public string name;
    public float fireRate;
    PlayerAttack playerAttack;
    public bool gun;
    public int ammo;

    void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    void Update()
    {


    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log("" + collider.name);
        if (collider.gameObject.tag == "Player"&& Input.GetMouseButton(1))
        {
            //Debug.Log("Player picked up gun: ");
            playerAttack.changingWeapon = true;
            playerAttack.fireRate = this.fireRate;
            playerAttack.weaponChangeCooldwon=0.5f;
            playerAttack.hasGun = true;
            playerAttack.currentWeapon = this.gameObject;
            if (name=="KNIFE")
            {
                playerAttack.isMeleGun = true;         
            }
            this.gameObject.SetActive(false);
        }

    }
}
