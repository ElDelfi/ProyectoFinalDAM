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
        if (isFollowing)
        {

            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        }
    }
}
