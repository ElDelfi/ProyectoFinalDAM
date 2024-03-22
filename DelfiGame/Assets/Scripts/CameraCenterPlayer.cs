using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenterPlayer : MonoBehaviour
{
    public GameObject player;
    public bool isFollowing = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //necesario para el efecto de zoom al pulsar shift
    public void setFollowing(bool isFollowing)
    {
        this.isFollowing = isFollowing;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isFollowing = false;
            player.GetComponent<PlayerMovement>().moving = false;
        }
        else
        {
            isFollowing = true;
        }

        if (isFollowing)
        {

            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        }
        else
        {
            //esto es para mover con el shift y el raton para  ver mas hacia delante como en el juego
            Vector3 newCamPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            newCamPosition.z = Camera.main.transform.position.z;
            Vector3 dirToMove = newCamPosition - this.transform.position;

            //ASI TENEMOS UN TOPE PARA QUE NO SE VAYA LEJOS SOLO SI ES VISIBLE EN PANTALLA EL SPRITE DEL JUGADOR
            if (player.GetComponent<SpriteRenderer>().isVisible)
            {
                transform.Translate(dirToMove * Time.deltaTime * 2);

            }

        }
    }
}
