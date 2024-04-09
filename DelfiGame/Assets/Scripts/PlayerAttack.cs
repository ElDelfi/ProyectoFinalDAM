using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    GameObject currentWeapon;
    public bool hasGun = false; // A MACHETE AQUI PARA PROBAR/
    float fireRate = 0.1f;
    float nextFireTime = 0f; // time when the player can fire again
    public float cooldownTime = 0.3f; // cooldown 

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    private float meleeRange = 0.5f;
    private float meleeCooldown = 1f;
    private float nextMeleTime = 0f;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        Debug.Log("PIUMMM");

        if (hasGun)
        {

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

    //private void OnDrawGizmos()
    //{
    //    fue para ver el radio del melee al principio para ajustarlo guay
    //    Gizmos.DrawSphere(firePoint.position, meleeRange);
    //}
}
