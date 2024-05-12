using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public new string name;
    public float fireRate;
    PlayerAttack playerAttack;
    public bool gun;
    public int initialAmmo; //hacer variable de current ammo par separar al reiniciar
    public int currentAmmo;

    private void Awake()
    {
        if (this.name == "SHOTGUN")
        {
            initialAmmo = 6;
            currentAmmo = initialAmmo;
        }
        else if (this.name == "UZI")
        {
            initialAmmo = 30;
            currentAmmo = initialAmmo;

        }
    }
    void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
   
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log("" + collider.name);
        if (collider.gameObject.tag == "Player" && Input.GetMouseButton(1))
        {
            FindObjectOfType<AudioManager>().Play("PickUp");

            //Debug.Log("Player picked up gun: ");
            playerAttack.changingWeapon = true;
            playerAttack.fireRate = this.fireRate;
            playerAttack.weaponChangeCooldwon = 0.5f;
            playerAttack.hasGun = true;
            playerAttack.currentWeapon = this.gameObject;
            playerAttack.currentWeaponScript = this;
            if (name == "KNIFE")
            {
                playerAttack.isMeleGun = true;
            }
            this.gameObject.SetActive(false);
        }

    }
}
