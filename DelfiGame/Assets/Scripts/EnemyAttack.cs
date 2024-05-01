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
    private PickUpWeapon currentPickUpWeaponScr;
    void Start()
    {
        currentPickUpWeaponScr = currentWeapon.GetComponent<PickUpWeapon>();
        animator = gameObject.GetComponent<Animator>();


        if (currentWeapon.name == "SHOTGUN") //error que al reiniciar el nivel no vuelven a recargarse las balas
        {
            currentPickUpWeaponScr.currentAmmo = currentPickUpWeaponScr.initialAmmo;
        }
        else if (currentWeapon.name == "UZI")
        {
            currentPickUpWeaponScr.currentAmmo = currentPickUpWeaponScr.initialAmmo;
        }
    }

    void Update()
    {
        //animator.enabled = hasGun ? true : false;
        animator.SetBool("hasGun", hasGun);
    }

    public void testShooting() {
        if (Time.time >= nextFireTime && hasGun && currentWeapon.GetComponent<PickUpWeapon>().currentAmmo >0)
        {
            animator.SetTrigger("shootUzi");
            currentPickUpWeaponScr.currentAmmo--;
            FindObjectOfType<AudioManager>().Play("MachineGun");
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.transform.Rotate(Vector3.forward, 90);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            nextFireTime = Time.time + currentPickUpWeaponScr.fireRate;
        }

    }

}
