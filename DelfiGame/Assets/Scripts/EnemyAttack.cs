using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject uziPrefab;
    public GameObject knifePrefab;
    public GameObject shotgunPrefab;


    private Animator animator;
    public GameObject currentWeapon;
    private float nextFireTime = 0f; // time when the player can fire again
    public float cooldownTime = 0.3f; // cooldown 

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public bool hasGun=true;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
    }

    void Update()
    {

    }

    public void testShooting() {
        if (Time.time >= nextFireTime && hasGun)
        {
            currentWeapon.GetComponent<PickUpWeapon>().ammo--;
            FindObjectOfType<AudioManager>().Play("MachineGun");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.transform.Rotate(Vector3.forward, 90);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            nextFireTime = Time.time + currentWeapon.GetComponent<PickUpWeapon>().fireRate;
        }

    }

}
