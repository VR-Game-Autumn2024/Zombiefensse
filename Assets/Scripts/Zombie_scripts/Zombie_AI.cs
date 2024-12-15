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

    //attaque du zombie
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Variables de dégats du Zombie
    public float Damage;

    //Appel la vie du personnage
    GameObject viePersonnage;
    public viePersonnage viePersoScript;

    //Sons
    public AudioClip zombieAttackSon;
    public AudioSource audioSource;

    //Animation
    public Animator animator;

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

    void Update()
    {
        agent.SetDestination(player.position);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChassePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        
    }
    //Déplacement du zombie si il ne voit pas le joueur
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

    //Point de marche du zombie si il ne voit pas le joueur
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

    //Lorque le zombie voit le joueur
    private void ChassePlayer()
    {
        agent.SetDestination(player.position);
    }

    //Script de l'attaque du Zombie
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            //Intéraction avec la vie du joueur
            viePersoScript.vieActuelle -= Damage;
            //joue l'animation et le son du zombie
            animator.SetBool("attaque", true);
            audioSource.PlayOneShot(zombieAttackSon);
        }
    }
     //Intervalle d'attaque du zombie
    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("attaque", false);
    }

    //Pour voir la distance de l'attaque du zombie et la distance de vue du zombie
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
