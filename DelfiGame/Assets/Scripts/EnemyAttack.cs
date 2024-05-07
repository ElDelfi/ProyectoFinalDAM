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

    private Vector3 previousPosition;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public bool hasGun=true;
    private PickUpWeapon currentPickUpWeaponScr;
    void Start()
    {
        previousPosition = transform.position;
        currentPickUpWeaponScr = currentWeapon.GetComponent<PickUpWeapon>();
        animator = gameObject.GetComponent<Animator>();

        changeWeaponAnimatorState(true);

        if (currentWeapon.name == "SHOTGUN") //solucion al error que al reiniciar el nivel no vuelven a recargarse las balas
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

        //todo esto para ver si se mueva ya que no sirve la velocidad del rigidbody2d
        Vector3 currentPosition = transform.position;

        float distance = Vector3.Distance(currentPosition, previousPosition);

        previousPosition = currentPosition;

        animator.SetBool("moving", distance > 0.001f);//por poner algo pequeño de margen

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
    public void testShootingShotgun() {
        if (Time.time >= nextFireTime && hasGun && currentWeapon.GetComponent<PickUpWeapon>().currentAmmo >0)
        {
            animator.SetTrigger("shootShotgun");
            currentPickUpWeaponScr.currentAmmo--;
            FindObjectOfType<AudioManager>().Play("Shotgun");

            for (int i = 0; i < 5; i++) // Cambiar 5 por la variable que determines cuántas balas se disparan
            {
                // el 45 es el angulo de dispersion
                float spreadAngle = UnityEngine.Random.Range(-45 / 2f, 45 / 2f);
                Quaternion rotation = Quaternion.Euler(0f, 0f, firePoint.rotation.eulerAngles.z + spreadAngle);

                GameObject shotgunBullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                Rigidbody2D rbShotgunBullet = shotgunBullet.GetComponent<Rigidbody2D>();
                rbShotgunBullet.AddForce(rotation * Vector2.up * bulletForce, ForceMode2D.Impulse);

            }     
            nextFireTime = Time.time + currentPickUpWeaponScr.fireRate;
        }

    }

    public void testKnifeAttack() {
        animator.SetTrigger("knifeAttack");
        FindObjectOfType<AudioManager>().Play("Knife");
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(firePoint.position - new Vector3(0.3f, 0, 0), 0.2f);
        foreach (Collider2D player in hitPlayer)
        {
            if (player.tag == "Player")
            {             
               player.GetComponent<PlayerDeathController>().isDead = true;
            }
        }
    }

    public void changeWeaponAnimatorState(bool state) {
        switch (currentWeapon.name)
        {
            case "SHOTGUN":
                animator.SetBool("hasShotgun", state);
                break;            
            case "UZI":
                animator.SetBool("hasUzi", state);
                break;           
            case "KNIFE":
                animator.SetBool("hasKnife", state);
                break;
        }
    }
}
