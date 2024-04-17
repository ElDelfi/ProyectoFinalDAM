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
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //aqui tengo que hacer booleana en el update para el metodo para que corra el tiempo del timer
        if (isKnockedDown)
        {
            knockedDown();
        }
    }

    public void killedByBullet()
    {
        startDeath();
        spriteRenderer.sprite = spriteDeadBullet;
        Instantiate(bloodPoolPrefab, this.transform.position, this.transform.rotation);
    }

    public void knockedDown()
    {
        knockedDownTime -= Time.deltaTime;
        spriteRenderer.sprite = spriteKnockedDown;
        this.GetComponent<Collider2D>().enabled = false;

        if (knockedDownTime <= 0)
        {
            isKnockedDown = false;
            knockedDownTime = 2f;
            this.GetComponent<Collider2D>().enabled = true;
            spriteRenderer.sprite= spriteStanding;
        }
    }

    public void killedByMele()
    {
        startDeath();
        spriteRenderer.sprite = spriteDeadMele;
        Instantiate(bloodPoolPrefab, this.transform.position, this.transform.rotation);
    }

    private void startDeath()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //this.GetComponent<Transform>().rotation = Quaternion.Euler(0f, 0f, 0f);
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        this.GetComponent<Collider2D>().enabled = false;
    }
}
