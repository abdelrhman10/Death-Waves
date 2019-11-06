using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

	//********************  Variables  **********************//
    public int Player_Health = 100;
    public int Player_Ammo = 100;
    public int Player_XP = 1500;
    public float Delay_Between_Zombie = 0;
    public bool isescaped;
    public float escapingdelay = 0f;
	//********************  GameObjects  **********************//
    //public GameObject AK = null;
    public GameObject scaraimimage;
    public GameObject M4aimimage;
    public GameObject Scar = null;
    public GameObject M4A1 = null;
    public GameObject Laser = null;
    //public GameObject AK_Icon = null;
    public GameObject Scar_Icon = null;
    public GameObject M4A1_icon = null;
    public GameObject Laser_Icon=null;
    public GameObject enabledweapon;
    public GameObject winpanel;
    public GameObject gameoverpanel;
    public GameObject pickupsound;
    //****************otherclasses**************//

    void Start()
    {
        M4A1.SetActive(true);
        M4A1_icon.SetActive(true);
        enabledweapon = M4A1;
        M4aimimage.SetActive(true);
        scaraimimage.SetActive(false);
        isescaped = false;
        gameoverpanel.SetActive(false);
    }
    void Update()
    {
        if (Player_Health <= 0)
        {
            StartCoroutine(GameOver());
        }
        if (isescaped)
        {
            StartCoroutine(Escapping());
            
        }
    }
    void Increas_Health()
    {
            
            if (Player_Health < 100 && Player_XP >= 100)
            {
                
                if (Player_Health > 75 )
                {
                    Player_Health = 100;
                    Player_XP -= 100;
                }
                else 
                {
                    Player_Health += 25;
                    Player_XP -= 100;
                }
                GameObject pickupsoundgo = Instantiate(pickupsound, transform.position, transform.rotation);
                Destroy(pickupsoundgo, 1f);
            }
    }
    public void Take_Damage(int damage_value)
    {
        if (Delay_Between_Zombie > 1)
        {
            if (Player_Health < damage_value)
            {
                Player_Health = 0;
            }
            else
            {
                Delay_Between_Zombie = 0;
                Player_Health -= damage_value;
            }
        }
        else
        {
            Delay_Between_Zombie += Time.deltaTime;
        }
    }
    void Increas_Ammo()
    {
        if (Player_XP >= 50)
        {
            Player_Ammo += 20;
            Player_XP -= 50;
        }
    }
    void Enable_Scar()
    {
        if (Player_XP >= 1000)
        {
            scaraimimage.SetActive(true);
            M4aimimage.SetActive(false);
            Scar.SetActive(true);
            Scar_Icon.SetActive(true);
            //AK.SetActive(false);
            M4A1.SetActive(false);
            Laser.SetActive(false);
            Laser_Icon.SetActive(false);
            M4A1_icon.SetActive(false);
            //AK_Icon.SetActive(false);
            Player_XP -= 1000;
            enabledweapon = Scar;
        }
    }
    /*void Enable_AK()
    {
        if (Player_XP >= 500)
        {
            AK.SetActive(true);
            AK_Icon.SetActive(true);
            M4A1.SetActive(false);
            Scar.SetActive(false);
            Scar_Icon.SetActive(false);
            M4A1_icon.SetActive(false);
            Laser.SetActive(false);
            Laser_Icon.SetActive(false);
            Player_XP -= 500;
        }
    }*/
    void Enable_Laser()
    {
        if (Player_XP >= 5000)
        {
            M4aimimage.SetActive(false);
            scaraimimage.SetActive(true);
            Laser.SetActive(true);
            Laser_Icon.SetActive(true);
            //AK.SetActive(false);
            //AK_Icon.SetActive(false);
            M4A1.SetActive(false);
            Scar.SetActive(false);
            Scar_Icon.SetActive(false);
            M4A1_icon.SetActive(false);
            Player_XP -= 5000;
            enabledweapon = Laser;
        }
    }
	void Increas_XP(int XP_value)
	{
		Player_XP += XP_value;
	}
    void Escape()
    {
        if (Player_XP >= 10000)
        {
            
            winpanel.SetActive(true);
            isescaped = true;
        }
    }
    IEnumerator Escapping()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainScene");
    }
    IEnumerator GameOver()
    {
        
        gameoverpanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainScene");
        gameoverpanel.SetActive(false);
       
    }
}
