using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Troca : MonoBehaviour {

    public Material skyboxFuturo;
    public Material skyboxPassado;

    public GameObject luzFuturo;
    public GameObject luzPassado;

    public GameObject faseFuturo;
    public GameObject fasePassado;


    public GameObject Player;

    private void FixedUpdate()
    {

        
        if (Player_Manager.singlePLayer.isActiveSwitch== true)
        {
            if (Input.GetButton("Switch"))
            {
               
                Player_Manager.singlePLayer.barra = 0;

                RenderSettings.skybox = skyboxPassado;

                luzFuturo.SetActive(false);
                luzPassado.SetActive(true);

                faseFuturo.SetActive(false);
                fasePassado.SetActive(true);

                StartCoroutine(voltar());
            }

        }
    }


    IEnumerator voltar()
    {
        yield return new WaitForSeconds(10f);

        RenderSettings.skybox = skyboxFuturo;

        luzFuturo.SetActive(true);
        luzPassado.SetActive(false);

        faseFuturo.SetActive(true);
        fasePassado.SetActive(false);


    }



}
