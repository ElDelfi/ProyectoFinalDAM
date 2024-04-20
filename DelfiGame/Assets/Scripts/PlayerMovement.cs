using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 movementDirection = Vector3.zero;
    public bool moving = false;
    public Animator animator;

    void Update()
    {
        // reinicio del vector de dirección de movimiento para q no se siga moviendo
        movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDirection += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection += Vector3.right;
        }

        // si no esta parado es true
        moving = movementDirection != Vector3.zero;

        // si se mueve, aplicamos el movimiento
        if (moving)
        {
            transform.Translate(movementDirection.normalized * speed * Time.deltaTime, Space.World);
        }

        animator.SetBool("moving", moving);
    }
}