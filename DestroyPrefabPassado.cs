using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabPassado : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (other.gameObject.tag == "Pivot")
        {
                encaixePrefabPassado.singleton.spawnQuartPassado();
        }
    }
}
