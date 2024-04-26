using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public GameObject bloodPoolPrefab;
    public Sprite spriteDeadBullet;
    public Sprite spriteDeadMele;
    public Sprite spriteKnockedDown;
    public Sprite spriteStanding;

    private float knockedDownTime = 2f;
    public bool isKnockedDown = false;
    private SpriteRenderer spriteRenderer;

    private Score score;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        score = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<Score>();
    }

    void Update()
    {
        //aqui tengo que hacer booleana en el update para el metodo para que corra el tiempo del timer
        if (isKnockedDown)
        {
            resetVelocity();
            knockedDown();
        }
    }

    public void killedByBullet()
    {
        score.AddScore(1000, this.transform.position);
        score.increaseMultiplier();
        startDeath();
        spriteRenderer.sprite = spriteDeadBullet;
        Instantiate(bloodPoolPrefab, this.transform.position, this.transform.rotation);
        this.gameObject.tag = "Dead";
    }

    public void knockedDown()
    {
        if (this.gameObject.tag=="Enemy") //para que no lo haga si ya esta muerte por un bug
        {
            FindObjectOfType<AudioManager>().Play("Damaged");

            //score.AddScore(500, this.transform.position);
            knockedDownTime -= Time.deltaTime;

            spriteRenderer.sprite = spriteKnockedDown;
            this.GetComponent<Collider2D>().isTrigger = true;
            this.GetComponent<EnemyIA>().enabled = false;

            if (knockedDownTime <= 0)
            {
                isKnockedDown = false;
                knockedDownTime = 2f;
                this.GetComponent<Collider2D>().isTrigger = false;
                spriteRenderer.sprite = spriteStanding;
                this.GetComponent<EnemyIA>().enabled = true;

            }
        }
       
    }

    public void killedByMele()
    {

        score.AddScore(500, this.transform.position);
        score.increaseMultiplier();
        startDeath();
        spriteRenderer.sprite = spriteDeadMele;
        Instantiate(bloodPoolPrefab, this.transform.position, this.transform.rotation);
        this.gameObject.tag = "Dead";

    }

    private void startDeath()
    {
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

    public void gloryKill() {
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
}
