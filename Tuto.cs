using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tuto : MonoBehaviour {

    public GameObject Hud;
    bool tutoW=false;
    bool tutoAD = false;


    public void Start()
    {
        StartCoroutine(TW());
    }



    IEnumerator TW()
    {
        Time.timeScale = 0;
        Hud.transform.Find("Tutorial1").gameObject.SetActive(true);
        yield return new WaitUntil(apertouW);
        Hud.transform.Find("Tutorial1").gameObject.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(Esperar());
    }


    IEnumerator TAD()
    {
        Time.timeScale = 0;
        Hud.transform.Find("Tutorial1 (1)").gameObject.SetActive(true);
        yield return new WaitUntil(apertouAD);
        Hud.transform.Find("Tutorial1 (1)").gameObject.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(Esperar1());

    }


    IEnumerator TM1()
    {
        Time.timeScale = 0;
        Hud.transform.Find("Tutorial1 (2)").gameObject.SetActive(true);
        yield return new WaitUntil(apertouMOUSE0);
        Hud.transform.Find("Tutorial1 (2)").gameObject.SetActive(false);
        Time.timeScale = 1;

        StartCoroutine(EsperarSair());

    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(TAD());
    }



    IEnumerator Esperar1()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(TM1());
    }



    IEnumerator EsperarSair()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0;
        Time.timeScale = 0;
        Hud.transform.Find("Sair ou ficar").gameObject.SetActive(true);
    }

    bool apertouAD()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool apertouW()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool apertouMOUSE0()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Sair(string nomeScene)
    {
        SceneManager.LoadScene(nomeScene);
    }


}
