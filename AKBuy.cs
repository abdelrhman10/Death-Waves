using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKBuy : MonoBehaviour {
    bool in_rang = false;
    public GameObject Inter_Act = null;
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
                Player.gameObject.SendMessage("Enable_AK", SendMessageOptions.DontRequireReceiver);
                
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
