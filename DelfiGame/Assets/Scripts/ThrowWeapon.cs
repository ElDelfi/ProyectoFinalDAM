using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    float timer = 1.0f;
    public Vector3 direction;
    Rigidbody2D rb;
    Collider2D col;

    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * 120);

        col = this.GetComponent<Collider2D>();
        col.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Slerp(this.transform.rotation, new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z - 1, this.transform.rotation.w), Time.deltaTime * 10);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            StopWeapon();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("arma lanzada choca");
        if (collision.gameObject.tag != "Player") //por ahora para q no choque con si mismo
        {
            //PONER LOGICA DE QUE HACER AL DARLE A ENEMIGO
            StopWeapon();

        }

    }

    private void StopWeapon()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        col.isTrigger = true;
        //rb.isKinematic = true;
        Destroy(this); //quita el script y luego se vuelve añadir si se vuelve a lanzar algo
    }
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        //PONER LOGICA DE QUE HACER AL DARLE A ENEMIGO
    //    }
    //    col.isTrigger = true;
    //    rb.isKinematic = true;
    //    Destroy(this);

    //}
}
