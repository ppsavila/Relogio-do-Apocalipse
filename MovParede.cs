using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovParede : MonoBehaviour {

    float speed = 7;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);


    }
}
