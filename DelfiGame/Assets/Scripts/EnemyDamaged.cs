using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamaged : MonoBehaviour
{
    public GameObject bloodPoolPrefab;
    public Sprite spriteDeadBullet;
    public Sprite spriteDeadMele;
    public Sprite spriteKnockedDown;
    public Sprite spriteStanding;
    private Animator animator;
    private float knockedDownTime = 2f;
    public bool isKnockedDown = false;
    private SpriteRenderer spriteRenderer;
    private EnemyAttack enemyAttackScr;
    private Score score;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        score = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<Score>();
        enemyAttackScr = this.GetComponent<EnemyAttack>();
        animator=this.GetComponent<Animator>();

    }

    void Update()
    {
        //aqui tengo que hacer booleana en el update para el metodo para que corra el tiempo del timer
        if (isKnockedDown)
        {
            animator.enabled = false;
            resetVelocity();
            knockedDown();
        }
    }

    public void killedByBullet()
    {
        animator.enabled = false;
        enemyLosesWeapon();
        score.AddScore(1000, this.transform.position);
        score.increaseMultiplier();
        startDeath();
        spriteRenderer.sprite = spriteDeadBullet;
        Instantiate(bloodPoolPrefab, this.transform.position, this.transform.rotation);
        this.gameObject.tag = "Dead";
    }

    public void knockedDown()
    {
        if (this.gameObject.tag == "Enemy") //para que no lo haga si ya esta muerte por un bug
        {
            enemyAttackScr.changeWeaponAnimatorState(false); //para que ponga a false para el animator que ya no tenemos el arma

            FindObjectOfType<AudioManager>().Play("Damaged");

            //score.AddScore(500, this.transform.position);
            knockedDownTime -= Time.deltaTime;

            spriteRenderer.sprite = spriteKnockedDown;
            this.GetComponent<Collider2D>().isTrigger = true;
            this.GetComponent<EnemyIA>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;

            enemyLosesWeapon();
            enemyAttackScr.hasGun=false;

            if (knockedDownTime <= 0)
            {
                isKnockedDown = false;
                knockedDownTime = 2f;
                this.GetComponent<Collider2D>().isTrigger = false;
                spriteRenderer.sprite = spriteStanding;
                this.GetComponent<EnemyIA>().enabled = true;
                this.GetComponent<NavMeshAgent>().enabled = true;

                animator.enabled = true;

            }
        }

    }

    public void killedByMele()
    {
        animator.enabled = false;
        enemyLosesWeapon();
        score.AddScore(500, this.transform.position);
        score.increaseMultiplier();
        startDeath();
        spriteRenderer.sprite = spriteDeadMele;
        Instantiate(bloodPoolPrefab, this.transform.position, this.transform.rotation);
        this.gameObject.tag = "Dead";

    }

    private void startDeath()
    {
        this.GetComponent<NavMeshAgent>().enabled = false;

        FindObjectOfType<AudioManager>().Play("Die");

        this.GetComponent<EnemyIA>().enabled = false;
        resetVelocity();
        //this.GetComponent<Transform>().rotation = Quaternion.Euler(0f, 0f, 0f);
        this.GetComponent<Collider2D>().enabled = false;
    }

    private void resetVelocity()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }

    public void gloryKill()
    {
        Debug.Log("EXECUTED");
        this.GetComponent<EnemyIA>().enabled = false;
        resetVelocity();
        score.AddScore(1000, this.transform.position);
        score.increaseMultiplier();
        this.GetComponent<Collider2D>().isTrigger = false;
        startDeath();
        spriteRenderer.sprite = spriteDeadBullet;
        Instantiate(bloodPoolPrefab, this.transform.position, this.transform.rotation);
        this.gameObject.tag = "Dead";

        //TODO AHORA QUE SE CAMBIO POR TRIGGER SI ESTA DENTRO EL PERSONAJE HACER EJECUCION
        //PENSARLO!!!!!!!!!!!!!!!!!!!!!
    }

    public void enemyLosesWeapon()
    {
        if (enemyAttackScr.hasGun)
        {

            switch (enemyAttackScr.currentWeapon.name) //nombre del arma que tiene encima
            {
                case "KNIFE":
                    GameObject knife = Instantiate(enemyAttackScr.knifePrefab, this.transform.position, this.transform.rotation);
                    knife.name = enemyAttackScr.knifePrefab.name; //NECESARIO YA QUE SI NO EL NOMBRE SER� (CLONE) Y DESPUES SE LIAN LOS OTROS SCRIPT AL COMPARAR CADENAS
                    break;
                case "UZI":
                    GameObject uzi = Instantiate(enemyAttackScr.uziPrefab, this.transform.position, this.transform.rotation);
                    uzi.name = enemyAttackScr.uziPrefab.name; 
                    uzi.GetComponent<PickUpWeapon>().currentAmmo =  enemyAttackScr.currentWeapon.GetComponent<PickUpWeapon>().currentAmmo;
                    break;
                case "SHOTGUN":
                    GameObject shotgun = Instantiate(enemyAttackScr.shotgunPrefab, this.transform.position, this.transform.rotation);
                    shotgun.name = enemyAttackScr.shotgunPrefab.name; 
                    shotgun.GetComponent<PickUpWeapon>().currentAmmo =  enemyAttackScr.currentWeapon.GetComponent<PickUpWeapon>().currentAmmo;

                    break;
            }
            enemyAttackScr.hasGun = false;
        }
    }
}
