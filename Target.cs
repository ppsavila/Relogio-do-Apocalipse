using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
   
    public int jeepVida = 20;
    public GameObject Explosion;
    public void jeepDamage(int dano)
    {
        jeepVida -= dano;
        if (jeepVida <= 0)
        {
            dieJeep();
        }

    }

    void dieJeep()
    {
        GameObject ExplosionGO = Instantiate(Explosion, transform.position, Quaternion.identity);
        
        Destroy(ExplosionGO, 2f);

        Destroy(gameObject);

    }

}



