using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour {

    Player_Manager player;


     void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
       
        if (other.gameObject.tag == "Pivot")
        {
                encaixePrefab.singleton.spawnQuartFuturo();
        }
            
     }
}
