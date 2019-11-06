using UnityEngine;
using System.Collections;

public class AimingDown : MonoBehaviour
{
	public Vector3 orriginalposition;
    public Vector3 scaraim;
    public Vector3 M4aim;
    public Vector3 laseraim;
    GameObject getplayer;
    public GameObject scarimage;
    public GameObject M4image;
    public GameObject laserimg;
    public GameObject sniperscope;
    public Camera maincam;
	void Start ()
	{
		orriginalposition = transform.localPosition;
        getplayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		aim ();  
	}
	void aim()
	{
        PlayerManager getweapon = getplayer.GetComponent<PlayerManager>();
		if (Input.GetButton ("Fire2")) 
		{
                
                 if (getweapon.enabledweapon.tag == "m4")
                {
                    M4image.SetActive(false);
                     transform.localPosition = Vector3.Lerp(transform.localPosition, M4aim, Time.deltaTime * 8);
                }
                 else if (getweapon.enabledweapon.tag == "scar")
                {
                    scarimage.SetActive(false);
                    transform.localPosition = Vector3.Lerp(transform.localPosition, scaraim, Time.deltaTime * 8);
                }
                 else if (getweapon.enabledweapon.tag == "laser")
                 {
                     transform.localPosition = Vector3.Lerp(transform.localPosition, laseraim, Time.deltaTime * 8);
                     laserimg.SetActive(false);
                     StartCoroutine(scoped());
                 }
		}
		else 
		{
			transform.localPosition = Vector3.Lerp (transform.localPosition, orriginalposition, Time.deltaTime * 8);
            if (getweapon.enabledweapon.tag == "m4")
                    M4image.SetActive(true);
            else if (getweapon.enabledweapon.tag == "scar")
                    scarimage.SetActive(true);
            else if (getweapon.enabledweapon.tag == "laser")
            {
                sniperscope.SetActive(false);
                scarimage.SetActive(false);
                maincam.fieldOfView = 60;
                laserimg.SetActive(true);
            }
		}
	}
    IEnumerator scoped()
    {
        yield return new WaitForSeconds(0.4f);
        sniperscope.SetActive(true);
        maincam.fieldOfView = 25f;
    }
}

