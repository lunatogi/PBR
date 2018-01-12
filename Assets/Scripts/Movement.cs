using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    GameObject[] players;
 	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        players = GameObject.FindGameObjectsWithTag("Player");
	}


    public void PointerUp()
    {
        foreach (GameObject player in players)
        {
            player.SendMessage("PointerUp", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void GoRight()
    {
        foreach(GameObject player in players)
        {
            player.SendMessage("GoRight", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void GoLeft()
    {
        foreach (GameObject player in players)
        {
            player.SendMessage("GoLeft", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Attack()
    {
        foreach (GameObject player in players)
        {
            player.SendMessage("Attack", SendMessageOptions.DontRequireReceiver);
        }
    }

}
