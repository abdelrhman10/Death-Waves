using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Pick_UP : MonoBehaviour {

    bool in_rang = false;
    public GameObject Inter_Act = null;
    public GameObject pickupsound;
    void Start()
    {
        Inter_Act.SetActive(false);
    }
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetButtonDown("Buy"))
        {
            
            if (in_rang)
            {
                Player.gameObject.SendMessage("Increas_Ammo", SendMessageOptions.DontRequireReceiver);
                GameObject pickupsoundgo= Instantiate(pickupsound, transform.position, transform.rotation);
                Destroy(pickupsoundgo, 1f);
                //Debug.Log("message sent");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            in_rang = true;
            Inter_Act.SetActive(true);
            
            //Destroy(gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Inter_Act.SetActive(false);
        in_rang = false;
        
    }
}
