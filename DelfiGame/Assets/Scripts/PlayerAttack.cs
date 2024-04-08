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
    public float cooldownTime = 1f; // cooldown 

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    public float meleeRange = 0.5f;



    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Attack();
            nextFireTime = Time.time + fireRate; 
        }
    }

    public void Attack()
    {
        Debug.Log("PIUMMM");

        if (hasGun)
        {
         
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.transform.Rotate(Vector3.forward, 90); //NECESARIO YA QUE EL PREFAB APARECE SIEMPRE EN HORIZONTAL EN VEZ DE VERTICAL 
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


        }
        else
        {
            animator.SetTrigger("meleAttack");

            //tiene sobrecarga con LayerMask para filtrar layers
            Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(firePoint.position, meleeRange);
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
