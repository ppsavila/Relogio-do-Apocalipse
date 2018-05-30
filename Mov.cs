using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour {



    float speed = 5;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);


    }
}
