using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public GameObject currentWeapon;
    public bool hasGun = false;
    public bool isMeleGun = false;
    public float fireRate = 0.1f;
    float nextFireTime = 0f; // time when the player can fire again
    public float cooldownTime = 0.3f; // cooldown 

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    private float meleeRange = 0.25f;
    private float meleeCooldown = 1f;
    private float nextMeleTime = 0f;

    public float weaponChangeCooldwon = 0.5f; //necesario porque si no al recoger un arma la suelta instantaneamente por el button(1) del raton
    public bool changingWeapon = false;

    private EnemyDamaged enemyDamagedScript;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //funcion para lanzar el arma actual TODO ARREGLAR YA QUE LO QUITA AL INSTANTE DEPSUES DE COGERLA

        if (hasGun && Input.GetMouseButtonDown(1) && !changingWeapon)
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
            if (weaponChangeCooldwon <= 0)
            {
                changingWeapon = false;
            }
        }
    }

    public void Attack()
    {
        if (hasGun && !isMeleGun)
        {
            //en este switch añadir las armas
            switch (currentWeapon.name)
            {
                case "UZI":
                    animator.SetBool("hasUzi", true);
                    //Vector3 relativePosition = this.gameObject.transform.position + new Vector3(1f, 0.3f, 0);
                    //firePoint.transform.position = relativePosition;
                    break;
                case "SHOTGUN":
                    animator.SetBool("hasShotgun", true);
                    break;
            }
            //Debug.Log("DISPARO DE: " + currentWeapon.name);
            if (Time.time >= nextFireTime)
            {
                switch (currentWeapon.name)
                {
                    case "UZI":
                        animator.SetTrigger("uziShoots");
                        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                        bullet.transform.Rotate(Vector3.forward, 90); //NECESARIO YA QUE EL PREFAB APARECE SIEMPRE EN HORIZONTAL EN VEZ DE VERTICAL 
                        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                        rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

                        break;
                    case "SHOTGUN":

                        animator.SetTrigger("shotgunShoots");
                        for (int i = 0; i < 5; i++) // Cambiar 5 por la variable que determines cuántas balas se disparan
                        {
                            // el 45 es el angulo de dispersion
                            float spreadAngle = UnityEngine.Random.Range(-45 / 2f, 45 / 2f);
                            Quaternion rotation = Quaternion.Euler(0f, 0f, firePoint.rotation.eulerAngles.z + spreadAngle);

                            GameObject shotgunBullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                            Rigidbody2D rbShotgunBullet = shotgunBullet.GetComponent<Rigidbody2D>();
                            rbShotgunBullet.AddForce(rotation * Vector2.up * bulletForce, ForceMode2D.Impulse);

                        }
                        break;
                }
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            if (isMeleGun)
            {
                animator.SetBool("hasKnife", true);
            }

            if (Time.time >= nextMeleTime)
            {
                if (isMeleGun)
                {
                    animator.SetTrigger("knifeAttack");
                }
                else
                {
                    animator.SetTrigger("meleAttack");
                }
                //tiene sobrecarga con LayerMask para filtrar layers
                nextMeleTime = Time.time + meleeCooldown;

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firePoint.position - new Vector3(0.65f, 0, 0), meleeRange);
                foreach (Collider2D enemy in hitEnemies)
                {
                    if (enemy.tag == "Enemy")
                    {
                        Debug.Log("KAPOW");
                        enemyDamagedScript = enemy.gameObject.GetComponent<EnemyDamaged>();
                        if (isMeleGun)
                        {
                            enemyDamagedScript.killedByMele();
                        }
                        else
                        {
                            enemyDamagedScript.isKnockedDown = true;
                        }
                    }
                }
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
            case "KNIFE":
                animator.SetBool("hasKnife", false);
                isMeleGun = false;
                break;
        }
        hasGun = false;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
        currentWeapon.AddComponent<ThrowWeapon>();
        Vector3 direction = new Vector3(mousePosition.x - this.transform.position.x, mousePosition.y - this.transform.position.y, 0);
        currentWeapon.GetComponent<Rigidbody2D>().isKinematic = false;
        currentWeapon.GetComponent<ThrowWeapon>().direction = direction;
        currentWeapon.transform.position = firePoint.position;
        currentWeapon.transform.eulerAngles = this.transform.eulerAngles;
        currentWeapon.SetActive(true);
        //Destroy(currentWeapon);
    }

    private void OnDrawGizmos()
    {
        //fue para ver el radio del melee al principio para ajustarlo guay
        Gizmos.DrawSphere(firePoint.position - new Vector3(0.65f, 0, 0), meleeRange);
    }
}

//TODO UTILIZAR EL BOOL DE HASMELEWEAPON PARA DIFERENCIAR ENTE CUCHILLO Y PUÑO PARA ANIMACIONES Y A LA HORA DE LLAMAR A ENEMY DAMAGED