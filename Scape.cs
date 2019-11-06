using UnityEngine;
using System.Collections;

public class Scape : MonoBehaviour
{

	bool incarrang;
	public GameObject Escapepanel;
	void Start ()
	{
        incarrang = false;
	}
	

	void Update ()
	{
        if (incarrang)
        {

            if (Input.GetButtonDown("Buy"))
            {
                GameObject Player = GameObject.FindGameObjectWithTag("Player");
                Player.gameObject.SendMessage("Escape", SendMessageOptions.DontRequireReceiver);

            }
        }
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			incarrang = true;
			Escapepanel.SetActive (true);
		}
	}
	void OnTriggerExit(Collider other)
	{
       
            incarrang = false;
            Escapepanel.SetActive(false);
     
	}
}

