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
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animator>();
        attackTime = Time.time;
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

        if (Distance <= attackRange)
        {
            attack();
        }

        void Chase()
        {
            //animations.Play("Orc Walk");
            animations.SetBool("IsWalking", true);
            agent.destination = Target.position;
            agent.isStopped = false;
        }

        void attack()
        {
            if (Time.time > attackTime)
            {
                animations.SetTrigger("Attack");
                Target.GetComponent<playerStat>().ApplyDamage(TheDamage);
                Debug.Log("L'ennemi a envoy� " + TheDamage + " points de d�g�ts");
                attackTime = Time.time + attackRepeatTime;
                agent.isStopped = true;
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