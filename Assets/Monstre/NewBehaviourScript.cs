using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Distance entre le joueur et l'ennemi
    private float Distance;

    // Cible de l'ennemi
    public Transform Target;

    //Distance de poursuite
    public float ChasseRange = 10;
    // Port�e des attaaues
    public float attackRange = 2.2f;

    // Cppmdpwn des attaques
    public float attackRepeatTime = 1;
    private float attackTime;

    //Montant des d�g�ts inflig�s
    public float TheDamage;

    // Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    // Animation de l'ennemi
    private Animator animations;

    // Vitesse par d�faut de l'agent
    private float defaultSpeed;
    private bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animator>();
        attackTime = Time.time;
        defaultSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Target = GameObject.Find("Cube").transform;


        
        Distance = Vector3.Distance(Target.position, transform.position);

        if (Distance > ChasseRange)
        {
            idle();
        }

        if (Distance < ChasseRange && Distance > attackRange)
        {
            Chase();
        }

        if (Distance <= attackRange && !attacking)
        {
            StartCoroutine(attack());
        }

        void Chase()
        {
            // Si l'animation qui est entrain de play est celle de l'attaque
            if (animations.GetCurrentAnimatorStateInfo(0).IsName("Zombie Attack")) return;

            //animations.Play("Orc Walk");
            animations.SetBool("IsWalking", true);
            agent.destination = Target.position;
            agent.isStopped = false;
            agent.speed = defaultSpeed;
        }

        IEnumerator attack()
        {
            if (Time.time > attackTime)
            {
                attacking = true;
                animations.SetTrigger("Attack");
                yield return new WaitForSeconds(1.25f);
                Target.GetComponent<playerStat>().ApplyDamage(TheDamage);
                attackTime = Time.time + attackRepeatTime;
                agent.isStopped = true;
                attacking = false;
                yield return new WaitForEndOfFrame();
            }
        }


        void idle()
        {
            //animations.Play("Orc Idle");
            animations.SetBool("IsWalking", false);
            agent.isStopped = true;
        }

        
    }
}
