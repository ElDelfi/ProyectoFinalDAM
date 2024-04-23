using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLegsRotation : MonoBehaviour
{
    private Vector3 rotation;
    public GameObject enemyObject;
    public Animator animator;

    private Vector3 previousPosition;

    void Start()
    {
        rotation = new Vector3(0, 0, 0);
        previousPosition = enemyObject.transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = enemyObject.transform.position;

        // Check if the current position is different from the previous position
        bool isEnemyMoving = currentPosition != previousPosition;
        //Debug.Log("Current " + currentPosition +"Previus: " +previousPosition+"  "+isEnemyMoving);

        animator.SetBool("moving", isEnemyMoving);

        Vector3 enemyPosition = enemyObject.GetComponent<EnemyIA>().transform.position;

        ////SE NECESITA ROTAR YA QUE POR COMO ESTAN LOS ASSETS HAY QUE GIRARLOS
        //orden wasd
        if (enemyPosition.y>0) 
        {
            rotation = new Vector3(0, 0, 90);
            transform.eulerAngles = rotation;
        }
        if (enemyPosition.x < 0)
        {
            rotation = new Vector3(0, 0, 180);
            transform.eulerAngles = rotation;
        }
        if (enemyPosition.y < 0)
        {
            rotation = new Vector3(0, 0, 270);
            transform.eulerAngles = rotation;
        }
        if (enemyPosition.x > 0)
        {
            rotation = new Vector3(0, 0, 0);
            transform.eulerAngles = rotation;
        }

        previousPosition = currentPosition;
    }
}
