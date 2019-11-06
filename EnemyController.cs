using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
	
	//********************  GameObjects  **********************//
    Transform target;

    public TakeDamage dead;
    public NavMeshAgent agent;
     Animator Anim;


	//********************  Variables  **********************//
    public int Damage_Value =3;
	public float Delay = 0;
	public float move_speed = 0.05f;
	void Start () 
    {
        dead = gameObject.GetComponent<TakeDamage>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Anim=GetComponent<Animator>();
        Damage_Value = 3;
	}
	
	// Update is called once per frame
	void Update () 
    {
            EnemyFollowPlayer(); 
		Increas_Damage_Value ();
	}
    void EnemyFollowPlayer()
    {
        if (!dead.isdead)
        {
            agent.SetDestination(target.position);
            Vector3 Destance = target.position - this.transform.position;
            Destance.y = 0;

            //target.SendMessage("Take_Damage", Damage_Value, SendMessageOptions.DontRequireReceiver);
            //********************************************************************************************************
            if (Destance.magnitude > 3)
            {
                Anim.SetBool("Attack", false);
                Anim.SetBool("Walk", true);
            }
            else
            {
                Anim.SetBool("Attack", true);
                Anim.SetBool("Walk", false);
                target.SendMessage("Take_Damage", Damage_Value, SendMessageOptions.DontRequireReceiver);
            }
        }
        else
            return;
        //**********************************************************************************************************
    }
    void Increas_Damage_Value()
    {
		if (Delay > 15)
		{
			Delay= 0;
			Damage_Value += 1;
		}
		else
		{
			Delay+= Time.deltaTime;
		}
    }
    
}
