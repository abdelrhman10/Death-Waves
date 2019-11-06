using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour 
{

	//********************  Classes  **********************//
    public PlayerManager get_Player_Info;
    public RoundsSystem Get_Zombie_Info;


	//********************  GameObjects  **********************//
	public GameObject Reloading_Panel;


	//********************  Variables  **********************//
    public Text Ammo;
    public Text Health;
    public Text XP;
    public Text Number_Of_Zombie;
    public Text Round;

	void Start ()
    {
		Reloading_Panel.SetActive (false);	
	}
	
	void Update ()
    {
        Health.text =get_Player_Info. Player_Health.ToString();
        XP.text = "XP: " + get_Player_Info.Player_XP.ToString();
        Number_Of_Zombie.text = "Zombies: " + Get_Zombie_Info.Zombie_Spawned_In_Round.ToString();
        Round.text = "Round: " + Get_Zombie_Info.Round.ToString(); 
	}
    public void AMMO_Update(int mag_size,int max_Ammo)
    {
        Ammo.text = mag_size.ToString() + "/" + max_Ammo.ToString();
    }
	void Activate_Reloading_Panel()
	{
		//Debug.Log ("Activated");
		Reloading_Panel.SetActive (true);
	}
	void DeActivate_Reloading_Panel()
	{
		Reloading_Panel.SetActive (false);
		//Debug.Log ("DEactivated");
	}
}
