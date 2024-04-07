using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegDirectionRotation : MonoBehaviour
{

    private Vector3 rotation;
    public GameObject playerObject;
    //añadimos ya de paso aqui para detectar si se esta moviendo y el animator
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //SE NECESITA ROTAR YA QUE POR COMO ESTAN LOS ASSETS HAY QUE GIRARLOS
        if (Input.GetKey(KeyCode.W))
        {
            rotation=new Vector3(0,0,90);
            transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotation = new Vector3(0, 0,180);
            transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rotation = new Vector3(0, 0,270);
            transform.eulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation = new Vector3(0, 0,0);
            transform.eulerAngles = rotation;

        }

        bool isPlayerMoving = playerObject.GetComponent<PlayerMovement>().moving;

        animator.SetBool("moving", isPlayerMoving);

        //transform.eulerAngles = rotation;
    }
}
