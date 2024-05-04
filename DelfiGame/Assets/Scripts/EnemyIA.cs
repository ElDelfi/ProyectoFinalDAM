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
    private LayerMask layerMask = 1 << 7; //la capa del raycast, muros,puertas,jugador
    private bool wallHit=false;

    private EnemyAttack enemyAttack;

    private Vector3 playerLastPosition= Vector3.zero;

    private PlayerAttack playerAttackScr;

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
        playerAttackScr = player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (playerAttackScr.isPlayerShooting) //si el player dispara pasaremos la posición, ya que es como si lo detectaran los enemigos
        {
            playerLastPosition = player.transform.position;
            playerAttackScr.isPlayerShooting = false; //cambiado aqui si nod aba errores
        }

        switch (state)
        {
            case State.Roaming:

               

                if (playerLastPosition!=Vector3.zero) //al volver a roaming desde chase, el valor de lastposition tendrá algo y así seguirá la última posición del jugador, y luego volverá a roaming 
                {
                    MoveTo(playerLastPosition);
                    if (Vector3.Distance(transform.position, playerLastPosition) < 0.5f ) 
                    {
                        roamingPosition = GetRoamingPosition();
                        playerLastPosition = Vector3.zero;
                    }
                }
                else
                {
                    MoveTo(roamingPosition);

                    if (Vector3.Distance(transform.position, roamingPosition) < 0.5f || wallHit) //0.5 para dejar margen
                    {
                        wallHit = false;
                        roamingPosition = GetRoamingPosition();
                    }
                    FindPlayer();
                }

            
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
        //  la rotación al enemigo
        transform.rotation = Quaternion.Euler(0f, 0f, targetRotation.eulerAngles.z);
        // mover al enemigo
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime, Space.World);


        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, 7f, layerMask);
        Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * 7f, Color.red);

        if (hit.collider != null && hit.collider.tag == "Player")
        {
            playerLastPosition=player.transform.position;

            float attackRange = 3f;
            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                if (enemyAttack.hasGun)
                {
                    switch (enemyAttack.currentWeapon.name)
                    {
                        case "KNIFE":
                            //TODO HACER EL MELE DEL ENEMIGO
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

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDir() * Random.Range(5f, 10f);
    }

    public Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall"||collision.gameObject.name == "Window")
        {
            wallHit=true;
        }
    }
}

//HACER FUNCION PARA MOVER Y ROTAR