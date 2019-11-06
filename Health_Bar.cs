using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar : MonoBehaviour {

    public PlayerManager get_health;
    float health;
	void Start () 
    {
        
	}
	
	void Update ()
    {
        Manage_Progress_Bar();
        
	}
    void Manage_Progress_Bar()
    {
        health = get_health.Player_Health;
        if(health>=0)
            transform.localScale = new Vector3(health / 100, 1, 1);
    }
}
