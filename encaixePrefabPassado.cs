using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encaixePrefabPassado : MonoBehaviour {

    public static encaixePrefabPassado singleton;
    private void Awake()
    {
        singleton = this;
    }


    public GameObject[] QuartPassado;
    GameObject copia;
    Transform posicao;
    [SerializeField]
    GameObject ampulheta;
    [SerializeField]
    GameObject[] coinPrefabs;
    [SerializeField]
    GameObject[] veiculosPrefabs;
    [SerializeField]
    GameObject[] propsPrefabs;
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
    GameObject passado;
    public GameObject player;

    public Material skytarde;
    private void Start()
    {
        
        int randomQuar = Random.Range(0, 3);
        copia = Instantiate(QuartPassado[randomQuar],new Vector3(player.transform.position.x - 5, player.transform.position.y, player.transform.position.z), Quaternion.identity,passado.transform);
        posicao = copia.transform.GetChild(0).GetChild(1);

        for (int i = 0; i < 10; i++)
        {
            spawnQuartPassado();
        }
    }

    public void spawnQuartPassado()
    {
        int randomQuar = Random.Range(0, 3);
        copia = Instantiate(QuartPassado[randomQuar],passado.transform);
        copia.transform.position = posicao.position;
        posicao = copia.transform.GetChild(0).GetChild(1);
        //spawnJetPack();
        //spawnPropsPrefabs();
        spawnVeiculosPrefabsPassado();
        //spawnPredios();
        spawnCoinsPassado();
        //spawnAmpulhetaPassado();
        spawnShieldPassado();
        spawnDoubleCoinPassado();
    }


    public void spawnDoubleCoinPassado()
    {
        int randomPosDoubleCoin = Random.Range(0, 4);
        Transform DoubleCoinPosition = copia.transform.GetChild(2).GetChild(5).GetChild(randomPosDoubleCoin);
        Instantiate(doublecoin, DoubleCoinPosition.position, Quaternion.identity, passado.transform);
    }

    public void spawnShieldPassado()
    {
        int RandomPosShield = Random.Range(0, 3);
        Transform ShieldPosition = copia.transform.GetChild(2).GetChild(4).GetChild(RandomPosShield);
        Instantiate(shield, ShieldPosition.position, Quaternion.identity, passado.transform);
    }


    public void spawnAmpulhetaPassado()
    {
        int RandomPosAmpulheta = Random.Range(0, 7);
        Transform AmpulhetaPosition = copia.transform.GetChild(2).GetChild(2).GetChild(RandomPosAmpulheta);
        Instantiate(ampulheta, AmpulhetaPosition.position, Quaternion.identity, passado.transform);
    }
    public void spawnCoinsPassado()
    {
        int RandomCoins = Random.Range(0, 3);
        Transform CoinPosition = copia.transform.GetChild(2).GetChild(1);
        Instantiate(coinPrefabs[RandomCoins], CoinPosition.position, Quaternion.identity, passado.transform);
    }
    public void spawnVeiculosPrefabsPassado()
    {
        int randomVeiculoPos = Random.Range(0, 6);
        Transform VeiculoPosition = copia.transform.GetChild(2).GetChild(0).GetChild(randomVeiculoPos);
        int RandomVeiculosPrefab = Random.Range(0, 4);
        Instantiate(veiculosPrefabs[RandomVeiculosPrefab], VeiculoPosition.position, Quaternion.identity, passado.transform);
    }


}
