using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathController : MonoBehaviour
{
    public bool isDead = false;
    public Sprite deadSprite;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement pm;
    private Animator animator;
    private FollowCursor cursor;
    private LegDirectionRotation legs;
    private PlayerAttack pa;
    private void Start()
    {
         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
         pm = this.GetComponent<PlayerMovement>();
         animator = this.GetComponent<Animator>();
         cursor = this.GetComponent<FollowCursor>();
         pa = this.GetComponent<PlayerAttack>();
         legs = this.GetComponentInChildren<LegDirectionRotation>();
    }
    void Update()
    {
        if (isDead)
        {
            playerDies();

            if (Input.GetKeyDown(KeyCode.R))
            {
                restartPlayer();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void playerDies()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;

        animator.enabled = false;

        if (pa.hasGun)
        {
            pa.ThrowWeapon();
        }
        cursor.enabled = false;
        legs.GetComponent<Animator>().enabled = false;
        pm.enabled = false;
        CapsuleCollider2D collider = this.GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
        spriteRenderer.sprite = deadSprite;

    }

    void restartPlayer()
    {

        legs.GetComponent<Animator>().enabled = true;


        animator.enabled = true;
        cursor.enabled = true;
        pm.enabled = true;
        CapsuleCollider2D collider = this.GetComponent<CapsuleCollider2D>();
        collider.enabled = true;
        isDead = false;
    }
}

//TODO PONER UNA INTERFAZ CON LA PUNTUACION Y LO DE REINICIAR
