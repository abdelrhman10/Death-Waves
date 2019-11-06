using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health_PickUP : MonoBehaviour {


	//********************  Variables  **********************//
    bool in_rang = false;


	//********************  GameObjects  **********************//
    public GameObject Inter_Act=null;
    
    void Start()
    {
        Inter_Act.SetActive(false);
    }
    void Update()
    {
        
        if (Input.GetButtonDown("Buy"))
        {
            
            if (in_rang)
            {
                GameObject Player = GameObject.FindGameObjectWithTag("Player");
                Player.gameObject.SendMessage("Increas_Health", SendMessageOptions.DontRequireReceiver);
                
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            in_rang = true;
            Inter_Act.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Inter_Act.SetActive(false);
        in_rang = false;
    }
}
