using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

	//********************  GameObjects  **********************//
	GameObject Add_XP_To_Player;
	public GameObject ZombieDieSound;
    public GameObject Zombiedieparticle;
	//********************  Variables  **********************//
	public int health=10; 
	int XP_Value=50;
	public float Delay = 0;
    Animator Anim;
    public bool isdead = false;

	void Start () 
    {
        health = 10;
        Anim = GetComponent<Animator>();
        
		Add_XP_To_Player= GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
		increas_health ();
	}
    public void takedamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !isdead)
        {
            GameObject Zombie_Minus = GameObject.FindGameObjectWithTag("Manager");
            Zombie_Minus.SendMessage("Zombie_Die", SendMessageOptions.DontRequireReceiver);
            if (Add_XP_To_Player != null)
            {
                Add_XP_To_Player.SendMessage("Increas_XP", XP_Value, SendMessageOptions.DontRequireReceiver);
            }
            Die();
        }
        else
            return;
    }
    void Die()
    {
        isdead = true;
        Anim.SetBool("die", true);
        Destroy(gameObject,2.5f);
		GameObject diesound = Instantiate (ZombieDieSound,transform.position,transform.rotation);
		Destroy (diesound, 2);
    }
	void increas_health()
	{
		if (Delay > 10)
		{
			Delay= 0;
			health += 1;
		}
		else
		{
			Delay+= Time.deltaTime;
		}
	}
}
