using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 3f;
    public float rotationSpeed = 3f;

    private EnemyAttack enemyAttack;
    void Start()
    {
        enemyAttack = this.GetComponent<EnemyAttack>();
    }

    void Update()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        float playerRange = 5f;

        //TODO HACER CONDICION QUE SI EL JUGADOR DISPARA LOS ENEMIGOS SE ALERTEN!!!
        if (Vector3.Distance(transform.position, player.transform.position) < playerRange)
        {

            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

            // rotar al sprite para que nos mire
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
            targetRotation *= Quaternion.Euler(0, 0, 90);


            //  la rotación al enemigo
            transform.rotation = Quaternion.Euler(0f, 0f, targetRotation.eulerAngles.z);

            // mover al enemigo
            transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime, Space.World);



            enemyAttack.testShooting();

        }
    }
}
