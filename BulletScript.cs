using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    GameObject enabledweapon;
    GameObject getplayer;
    public GameObject BloodImpact;
    public GameObject dustimpact;

    public int weapondamage;
	void Start ()
	{
	    
	}
	void Update ()
	{
        gettingweapondamage();
	}
	void OnTriggerEnter(Collider other)
	{

		if (other!=null) 
		{
			TakeDamage target = other.GetComponent<TakeDamage> ();
            if (other.gameObject.tag == "Zombie")
            {
                GameObject BloodGo = Instantiate(BloodImpact, transform.position, transform.rotation);
                Destroy(gameObject);
                target.takedamage(weapondamage);
                Destroy(BloodGo,2);
            }
            else if (other.gameObject.tag == "Player")
            {
                return;
            }
            else
            {
                GameObject dustgo = Instantiate(dustimpact, transform.position, transform.rotation);
                Destroy(gameObject,2);
                Destroy(dustgo, 2);
            }
		}
	}
    void gettingweapondamage()
    {
        getplayer = GameObject.FindGameObjectWithTag("Player");
        PlayerManager getweapon = getplayer.GetComponent<PlayerManager>();
        enabledweapon = getweapon.enabledweapon;
        WeaponFire getweaponpower = enabledweapon.GetComponent<WeaponFire>();
        weapondamage = getweaponpower.weapon_damage;
        //Debug.Log(getweaponpower.weapon_damage);
    }
}

