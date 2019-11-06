using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsSystem : MonoBehaviour 
{
	//********************  GameObjects  **********************//
	public Transform [] Spawn_Points;
	public GameObject Zombies1;
	public GameObject SoundTrack;
    public GameObject ZombieGo;

	//********************  Variables  **********************//
	public int Zombie_Spawned_In_Round=0;
	public int Round = 1;
	public int Zombie_Per_Round=5;
    public int Zombie_Count = 0;
	public float Delay_Between_Zombie = 0f;
    public float Delay_Between_Rounds = 0f;

	void Start ()
	{
        Zombie_Spawned_In_Round = Zombie_Per_Round;
		Instantiate (SoundTrack);
	}
	
	void Update () 
	{
        if (Zombie_Spawned_In_Round > 0 )
        {
            Spawninig_And_Delay();
        }
        else
        {
            if (Delay_Between_Rounds >10)
            {
                Zombie_Per_Round += 2;
                Zombie_Spawned_In_Round = Zombie_Per_Round;
                Zombie_Count = 0;
                Round++;
                Delay_Between_Rounds = 0;
            }
            else
            {
                Delay_Between_Rounds += Time.deltaTime;
            }
           
        }
    }
	void Spawn_Enemy()
	{
		Vector3 rand_spawn_points = Spawn_Points [Random.Range (0, Spawn_Points.Length)].position;
        
        if (Zombie_Count < Zombie_Per_Round)
        {
            ZombieGo = Instantiate(Zombies1, rand_spawn_points, Quaternion.identity);
            
            Zombie_Count++;
        }
        else
        {
            return;
        }
		
	}
    void Zombie_Die()
    {
        Zombie_Spawned_In_Round -= 1;
    }
    void Spawninig_And_Delay()
    {
        if (Delay_Between_Zombie > 1)
        {
            Spawn_Enemy();
            Delay_Between_Zombie = 0;
        }
        else
        {
            Delay_Between_Zombie += Time.deltaTime;
        }
    }
}
