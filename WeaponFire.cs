using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour {

    //********************  Classes  **********************//
    public PlayerManager Getting_Player_Ammo;
    private UI_Manager ui_manager;
    public UI_Manager UIM;


    //********************  GameObjects  **********************//
    public GameObject Weapon_sound;
	public GameObject Weapon_Reload_sound;
    public GameObject impact;
    public GameObject Blood_impact;
	public GameObject BulletPF;
    public GameObject noammosound;

    //********************  Game Compnents  **********************//
    public Camera fpscamera;
	public Transform BulletPosition;

    //********************  Variables  **********************//
    public int weapon_damage = 10;
    public float rang = 100f;
    public float fire_rate = 15f;
    private float next_time_fire = 0f;
    public int weapon_type_ammo_num = 30;
    public int magazin_size = 30;
    private bool Is_Realoading = false;
    public float Delay = 0;
	public float BulletSpeed=8f;
    
    //********************  Effects  **********************//
    public ParticleSystem muzzle_flash;
    
    
    void Awake()
    {
        ui_manager = GameObject.FindObjectOfType<UI_Manager>();
    }
	
	void Update () 
    {
        if (Input.GetButtonDown("Fire1") && magazin_size <= 0)
        {
            GameObject noammo = Instantiate(noammosound, transform.position, transform.rotation);
            Destroy(noammo, 1f);
        }
		if (Input.GetButton ("Fire1") && Time.time >= next_time_fire && magazin_size >= 1 && !Is_Realoading) 
		{
			magazin_size--;
			next_time_fire = Time.time + 1f / fire_rate;
			shoot ();
		} 
		
		if (Input.GetButtonDown("Reaload") && magazin_size < weapon_type_ammo_num &&Getting_Player_Ammo.Player_Ammo>0)
        {
            GameObject Reaload_sound = Instantiate(Weapon_Reload_sound, transform.position, transform.rotation);
            Destroy(Reaload_sound, 2f);
			Is_Realoading=true;
           
        }
		if (Is_Realoading) 
		{
            
			if (Delay > 2) 
			{
				Is_Realoading = false;
				Delay = 0;
				reaload ();
				UIM.SendMessage ("DeActivate_Reloading_Panel", SendMessageOptions.DontRequireReceiver);
                
			} 
			else 
			{
				Delay += Time.deltaTime;
				UIM.SendMessage ("Activate_Reloading_Panel", SendMessageOptions.DontRequireReceiver);
			}
		}
        transfer_Ammo_Data();
	}
    void shoot()
    {
        muzzle_flash.Play();
        //RaycastHit hit_ifo;
        GameObject Fire_sound= Instantiate(Weapon_sound,transform.position,transform.rotation);
		Destroy(Fire_sound, 2f);

		GameObject BulletGo= Instantiate(BulletPF,BulletPosition.position,BulletPosition.rotation);
		Destroy (BulletGo, 2f);
		Rigidbody PulletRP = BulletGo.GetComponent<Rigidbody> ();
		PulletRP.AddForce(BulletPosition.forward * BulletSpeed);

    }
    void reaload()
    {
            int used_ammo = weapon_type_ammo_num - magazin_size;

            if (Getting_Player_Ammo.Player_Ammo == 0)
            {
                GameObject noammo = Instantiate(noammosound, transform.position, transform.rotation);
                Destroy(noammo, 1f);
                
            }
            else if (magazin_size < weapon_type_ammo_num && Getting_Player_Ammo.Player_Ammo >= used_ammo)
            {
                Getting_Player_Ammo.Player_Ammo -= used_ammo;
                magazin_size = weapon_type_ammo_num;
            }
            else if (magazin_size < weapon_type_ammo_num && Getting_Player_Ammo.Player_Ammo < used_ammo && Getting_Player_Ammo.Player_Ammo > 0)
            {
                magazin_size += Getting_Player_Ammo.Player_Ammo;
                Getting_Player_Ammo.Player_Ammo = 0;
            }
            
    }
    void transfer_Ammo_Data()
    {
        ui_manager.AMMO_Update(magazin_size, Getting_Player_Ammo.Player_Ammo);
    }
}
