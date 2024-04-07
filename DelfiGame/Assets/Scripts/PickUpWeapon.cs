using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public float fireRate;
    PlayerAttack playerAttack;
    public bool gun, oneHanded, shotgun;
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
        //Debug.Log ("Collision");
        if (collider.gameObject.tag == "Player" && Input.GetMouseButtonDown(1))

            Debug.Log("Player picked up gun: ");
         
            this.gameObject.SetActive(false); 
        
    }
}
