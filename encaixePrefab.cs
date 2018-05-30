using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encaixePrefab : MonoBehaviour {

    
    public GameObject[] Quart;

    GameObject copia;

    Transform posicao;


    [SerializeField]
    GameObject ampulheta;
    [SerializeField]
    GameObject[] coinPrefabs;
    [SerializeField]
    GameObject[] veiculosPrefabs;
    [SerializeField]
    Transform[] veiculosPosition;
    [SerializeField]
    Transform[] propsPosition;

    [SerializeField]
    GameObject jetpack;

    [SerializeField]
    GameObject shield;

    [SerializeField]
    GameObject doublecoin;

    [SerializeField]
    GameObject futuro;

    public GameObject player;


    //Singleton
    public static encaixePrefab singleton;

    public Material skybnoite;

    private void Awake()
    {
        singleton = this;
    }
    //Singleton


        

    public void Start()
    {
        
        int randomQuar = Random.Range(0, 3);
        copia = Instantiate(Quart[randomQuar],new Vector3(player.transform.position.x-5,player.transform.position.y,player.transform.position.z),Quaternion.identity,futuro.transform);
        posicao = copia.transform.GetChild(0).GetChild(1);

        for (int i = 0; i < 5; i++)
        {
            spawnQuartFuturo();
        }
    }

//Spawm environment
    public void spawnQuartFuturo()
    { 
        int randomQuar = Random.Range(0, 3);
        copia = Instantiate(Quart[randomQuar], futuro.transform);
        copia.transform.position = posicao.position;
        posicao = copia.transform.GetChild(0).GetChild(1);
        //spawnJetPack();
        //spawnPropsPrefabs();
        //spawnPredios();

        int range = Random.Range(0, 6);


        switch(range){
            case 0:
                spawnVeiculosPrefabs();
                break;
            case 1:
                spawnCoins();
                spawnVeiculosPrefabs();
                break;
            case 2:
                spawnAmpulheta();
                break;
            case 3:
                spawnShield();
                break;
            case 4:
                spawnDoubleCoin();
                break;
        }
        
        spawnCoins();




    }


    public void spawnVeiculosPrefabs()
    {
        int randomVeiculoPos=Random.Range(0,6);
        Transform VeiculoPosition = copia.transform.GetChild(2).GetChild(0).GetChild(randomVeiculoPos);
        int RandomVeiculosPrefab = Random.Range(0, 4);
        Instantiate(veiculosPrefabs[RandomVeiculosPrefab], VeiculoPosition.position, Quaternion.identity, futuro.transform);
    }



//spawn Environment


//Spawn Coletaveis


    public void spawnCoins()
    {
        int RandomCoins = Random.Range(0, 3);
        Transform CoinPosition = copia.transform.GetChild(2).GetChild(1);
        Instantiate(coinPrefabs[RandomCoins], CoinPosition.position, Quaternion.identity, futuro.transform);
    }


    //spawn ampulheta futuro e passado
    public void spawnAmpulheta()
    {
        int RandomPosAmpulheta = Random.Range(0,7);
        Transform AmpulhetaPosition = copia.transform.GetChild(2).GetChild(2).GetChild(RandomPosAmpulheta);
        Instantiate(ampulheta, AmpulhetaPosition.position, Quaternion.identity, futuro.transform);
    }

    /*
    public void spawnJetPack()
    {
        Transform JetpackPosition = copia.transform.GetChild(2).GetChild(8);
        Instantiate(jetpack,JetpackPosition.position, Quaternion.identity);
    }*/


    //spawb shield futuro e passado
    public void spawnShield()
    {
        int RandomPosShield = Random.Range(0, 3);
        Transform ShieldPosition = copia.transform.GetChild(2).GetChild(4).GetChild(RandomPosShield);
        Instantiate(shield, ShieldPosition.position, Quaternion.identity, futuro.transform);
    }


    //Spawn moedas futuro e passado
    public void spawnDoubleCoin()
    {
        int randomPosDoubleCoin = Random.Range(0, 4);
        Transform DoubleCoinPosition = copia.transform.GetChild(2).GetChild(5).GetChild(randomPosDoubleCoin);
        Instantiate(doublecoin, DoubleCoinPosition.position, Quaternion.identity, futuro.transform);
    }



}
