using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public GameObject currentWeapon;
    public bool hasGun = false; 
    float fireRate = 0.1f;
    float nextFireTime = 0f; // time when the player can fire again
    public float cooldownTime = 0.3f; // cooldown 

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    private float meleeRange = 0.5f;
    private float meleeCooldown = 1f;
    private float nextMeleTime = 0f;

    public float weaponChangeCooldwon = 0.5f; //necesario porque si no al recoger un arma la suelta instantaneamente por el button(1) del raton
    public bool changingWeapon = false;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //funcion para lanzar el arma actual TODO ARREGLAR YA QUE LO QUITA AL INSTANTE DEPSUES DE COGERLA

        if (hasGun && Input.GetMouseButtonDown(1)&&!changingWeapon)
        {

            ThrowWeapon();
        }

        if (Input.GetMouseButton(0))
        {
            Attack();
        }

        //este if es solo para evitar que nada mas coger o cambiar de arma la eliminemos
        if (changingWeapon)
        {
            weaponChangeCooldwon -= Time.deltaTime;
            if (weaponChangeCooldwon<=0)
            {
                changingWeapon = false;
            }
        }
    }

    public void Attack()
    {
        //Debug.Log("PIUMMM");

        if (hasGun)
        {
            //en este switch añadir las armas
            switch (currentWeapon.name)
            {
                case "UZI":
                    animator.SetBool("hasUzi", true);
                    animator.SetTrigger("uziShoots");

                    //Vector3 relativePosition = this.gameObject.transform.position + new Vector3(1f, 0.3f, 0);
                    //firePoint.transform.position = relativePosition;
                    break;
                case "SHOTGUN":
                    animator.SetBool("hasShotgun", true);
                    animator.SetTrigger("shotgunShoots");
                    break;
            }
            Debug.Log("DISPARO DE: " + currentWeapon.name);
            if (Time.time >= nextFireTime)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.transform.Rotate(Vector3.forward, 90); //NECESARIO YA QUE EL PREFAB APARECE SIEMPRE EN HORIZONTAL EN VEZ DE VERTICAL 
                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                nextFireTime = Time.time + fireRate;

            }

        }
        else
        {
            if (Time.time >= nextMeleTime)
            {

                animator.SetTrigger("meleAttack");

                //tiene sobrecarga con LayerMask para filtrar layers
                nextMeleTime = Time.time + meleeCooldown;
            }

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firePoint.position, meleeRange);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("KAPOW");
            }
        }
        animator.SetBool("hasGun", hasGun);
    }
    public void ThrowWeapon()
    {
        switch (currentWeapon.name)
        {
            case "UZI":
                animator.SetBool("hasUzi", false);
                break;
            case "SHOTGUN":
                animator.SetBool("hasShotgun", false);
                break;
        }
        Destroy(currentWeapon);
        hasGun = false;
    }

    //private void OnDrawGizmos()
    //{
    //    fue para ver el radio del melee al principio para ajustarlo guay
    //    Gizmos.DrawSphere(firePoint.position, meleeRange);
    //}
}
