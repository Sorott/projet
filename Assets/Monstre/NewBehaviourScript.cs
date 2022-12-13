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
    // Portée des attaaues
    public float attackRange = 2.2f;

    // Cppmdpwn des attaques
    public float attackRepeatTime = 1;
    private float attackTime;

    //Montant des dégâts infligés
    public float TheDamage;

    // Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    // Animation de l'ennemi
    private Animation animations;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Target = GameObject.Find("Player").transform;

        Distance = Vector3.Distance(Target.position, transform.position);

        if (Distance > ChasseRange)
        {
            idle();
        }

        if (Distance < ChasseRange && Distance > attackRange)
        {
            Chase();
        }

        if (Distance > ChasseRange)
        {
            attack();
        }

        void Chase()
        {
            animations.Play("walk");
            agent.destination = Target.position;
        }

        void attack()
        {
            if (Time.time > attackTime)
            {
                animations.Play("Hit");
                Target.GetComponent<PlayerHP>().ApplyDamage(TheDamage);
                Debug.Log("L'ennemi a envoyé " + TheDamage + " points de dégâts");
                attackTime = Time.time + attackRepeatTime;
            }
        }


        void idle()
        {
            animations.Play("idle");
        }


    }
}
