using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 3f;
    public float rotationSpeed = 3f;
    private Vector3 startingPosition; //para el comportamiento de Roam 
    private Vector3 roamingPosition;

    private EnemyAttack enemyAttack;

    private enum State
    {
        Roaming,
        ChaseTarget,
        GoingBackToStart,
    }
    private State state;
    private void Awake()
    {
        state = State.Roaming;
    }
    void Start()
    {
        enemyAttack = this.GetComponent<EnemyAttack>();
        startingPosition = this.transform.position;
        roamingPosition = GetRoamingPosition();
 
    }

    void Update()
    {
        switch (state)
        {
            case State.Roaming:
                MoveTo(roamingPosition);
                if (Vector3.Distance(transform.position, roamingPosition) < 0.5f) //0.2 para dejar margen
                {
                    roamingPosition = GetRoamingPosition();
                }
                FindPlayer();

                break;
            case State.ChaseTarget:
                ChasePlayer();
                break;
            case State.GoingBackToStart:
                //MoveTo(startingPosition);
                //if (Vector3.Distance(transform.position, startingPosition) < 0.5f)
                //{

                //    state = State.Roaming;
                //}
                break;
        }


    }

    private void FindPlayer()
    {
        float playerRange = 5f;

        //TODO HACER CONDICION QUE SI EL JUGADOR DISPARA LOS ENEMIGOS SE ALERTEN!!!
        if (Vector3.Distance(transform.position, player.transform.position) < playerRange)
        {
            state = State.ChaseTarget;
        }
    }

    private void ChasePlayer()
    {

        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        // rotar al sprite para que nos mire
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
        targetRotation *= Quaternion.Euler(0, 0, 90);


        //  la rotación al enemigo
        transform.rotation = Quaternion.Euler(0f, 0f, targetRotation.eulerAngles.z);

        // mover al enemigo
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime, Space.World);



        float attackRange = 3f;
        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            if (enemyAttack.hasGun)
            {
                enemyAttack.testShooting();

            }
        }


        //float stopChaseRange = 15f;
        //if (Vector3.Distance(transform.position, player.transform.position) < stopChaseRange)
        //{
        //    state = State.GoingBackToStart;
        //}
    }

    public void MoveTo(Vector3 targetPosition)
    {
        SetTargetPosition(targetPosition);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {

        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);
        targetRotation *= Quaternion.Euler(0, 0, 90);
        transform.rotation = Quaternion.Euler(0f, 0f, targetRotation.eulerAngles.z);

        transform.Translate(directionToTarget * moveSpeed * Time.deltaTime, Space.World);

    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDir() * Random.Range(5f, 10f);
    }

    public Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}

//HACER FUNCION PARA MOVER Y ROTAR

//CUANDO SE CHOQUE QUE GIRE