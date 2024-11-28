using NUnit.Framework.Internal.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie_AI : MonoBehaviour
{
    //Déplacement du zombie
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Variables de vie et de dégats du Zombie
    public float Damage;
    public float Health;

    //Appel la vie du personnage
    GameObject viePersonnage;
    public viePersonnage viePersoScript;

    //Animation
    public Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        viePersoScript = viePersonnage.GetComponent<viePersonnage>();

        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        player = GameObject.Find("DeplacementJoueur").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChassePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        
    }

    private void Patrolling()
    {
        if (walkPointSet) searchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkpoint);
        }
        Vector3 distanceToWalkPoint =  transform.position - walkpoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void searchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.z + randomZ);

        if(Physics.Raycast(walkpoint, -transform.up,2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    private void ChassePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            //Attaque du Zombie
            viePersoScript.vieActuelle -= Damage;
            animator.SetBool("attaque", true);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("attaque", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
