using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 3f;
    public float rotationSpeed = 3f;
    private Vector3 startingPosition; //para el comportamiento de Roam 
    private Vector3 roamingPosition;
    private LayerMask layerMask = 1 << 7; //la capa del raycast, muros,puertas,jugador
    private float attackRange;
    private EnemyAttack enemyAttack;
    private float hearShotRange=15f;

    private Vector3 playerLastPosition = Vector3.zero;

    private PlayerAttack playerAttackScr;

    public NavMeshAgent navMeshAgent;
    private enum State
    {
        Roaming,
        ChaseTarget,
        GoingBackToStart,
        Waiting
    }
    private State state;
    private void Awake()
    {
        state = State.Waiting;
    }
    void Start()
    {
        enemyAttack = this.GetComponent<EnemyAttack>();
        startingPosition = this.transform.position;
        roamingPosition = GetRoamingPosition();
        playerAttackScr = player.GetComponent<PlayerAttack>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;

        transform.Translate(transform.up * 1.01f * Time.deltaTime, Space.World); //esta linea es para activar las animaciones de los enemigos y poder ver las armas,ya que para cambiar el estado inicial de la animaci�n debe de haber movimiento, un poco jaimitada pero funciona

        switch (enemyAttack.currentWeapon.name)
        {       
            case "UZI":
                attackRange = 6f;
                break;
            case "SHOTGUN":
                attackRange = 3f;
                break;
        }
    }
    IEnumerator ResetPlayerShootingFlag()
    {
        yield return new WaitForSeconds(0.5f);
        playerAttackScr.isPlayerShooting = false;
    }

    void Update()
    {
        if (playerAttackScr.isPlayerShooting&& Vector3.Distance(transform.position, player.transform.position) < hearShotRange) //si el player dispara pasaremos la posici�n, ya que es como si lo detectaran los enemigos
        {
            playerLastPosition = player.transform.position;
            //playerAttackScr.isPlayerShooting = false; //cambiado aqui si nod aba errores
            StartCoroutine(ResetPlayerShootingFlag());
        }

        switch (state)
        {
            case State.Roaming:

                if (playerLastPosition != Vector3.zero) //al volver a roaming desde chase, el valor de lastposition tendr� algo y as� seguir� la �ltima posici�n del jugador, y luego volver� a roaming 
                {
                    RotateToPoint(playerLastPosition);
                    navMeshAgent.SetDestination(playerLastPosition);
                    //MoveTo(playerLastPosition);
                    if (Vector3.Distance(transform.position, playerLastPosition) < 0.5f)
                    {
                        roamingPosition = GetRoamingPosition();
                        playerLastPosition = Vector3.zero;
                    }

                }
                else
                {
                    MoveTo(roamingPosition);

                    if (Vector3.Distance(transform.position, roamingPosition) < 0.5f) //0.5 para dejar margen
                    {
                        roamingPosition = GetRoamingPosition();
                    }
                }

                FindPlayer();


                break;
            case State.ChaseTarget:
                ChasePlayer();
                break;
            //case State.GoingBackToStart:
            //MoveTo(startingPosition);
            //if (Vector3.Distance(transform.position, startingPosition) < 0.5f)
            //{

            //    state = State.Roaming;
            //}
            //break;
            case State.Waiting:
                FindPlayer();
                if (playerLastPosition != Vector3.zero)
                {
                    state= State.Roaming;
                }
                break;
        }


    }


    private void FindPlayer()
    {
        float playerRange = 10f;

        if (Vector3.Distance(transform.position, player.transform.position) < playerRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 7f, layerMask);

            Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * 7f, Color.red);
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                state = State.ChaseTarget;
            }
        }
    }

    private void ChasePlayer()
    {

        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        // rotar al sprite para que nos mire
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
        targetRotation *= Quaternion.Euler(0, 0, 90);
        //  la rotaci�n al enemigo
        transform.rotation = Quaternion.Euler(0f, 0f, targetRotation.eulerAngles.z);
        // mover al enemigo
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime, Space.World);


        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 7f, layerMask);
        Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * 7f, Color.red);

        if (hit.collider != null && hit.collider.tag == "Player")
        {
            playerLastPosition = player.transform.position;


            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                if (enemyAttack.hasGun)
                {
                    switch (enemyAttack.currentWeapon.name)
                    {
                        case "KNIFE":
                            enemyAttack.testKnifeAttack();
                            break;
                        case "UZI":
                            enemyAttack.testShooting();
                            break;
                        case "SHOTGUN":
                            enemyAttack.testShootingShotgun();
                            break;
                    }
                }
            }
        }
        else
        {
            state = State.Roaming;
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
    public void RotateToPoint(Vector3 targetPosition) //creado para las pruebas con el navmesh
    {

        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);
        targetRotation *= Quaternion.Euler(0, 0, 90);
        transform.rotation = Quaternion.Euler(0f, 0f, targetRotation.eulerAngles.z);

    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDir() * Random.Range(2f, 4f);
    }

    public Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall" || collision.gameObject.name == "Window")
        {
            roamingPosition = GetRoamingPosition();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        roamingPosition = GetRoamingPosition();

    }
}
