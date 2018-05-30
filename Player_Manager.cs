using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class Player_Manager : MonoBehaviour
{


    public static Player_Manager singlePLayer;
    private void Awake()
    {
        singlePLayer = this;
    }

    public Animator Anime;


    //Manager do personagem incluindo coleta de itens e de processamento das funçoes 
    public bool loadPassado = false;
    public bool loadFuturo = true;
    public Camera cam;
    public Vector3 MousePosition;
    public PostProcessingProfile profile;

    //AUDIOS
    public AudioSource Audiocoin;


    //power up jetpack
    public bool isActiveJetpack = false;
    public ParticleSystem jetPackParticle;
    public GameObject prefabJetpack;
    public GameObject Jetpack;

    //powerup escudo
    public bool isActiveShield = false;
    public GameObject shieldGO;
    public Material doubleCoin;
    public Material coin;
    Material Aux;

    //personagem status
    public string nome;
    public int pontos = 0;
    public int valorCoin = 10;
    public int dinheiro = 0;
    public int barra = 0;
    public int vidas = 3;
    float speed = 5f;
    float jumpSpeed = 8.0F;
    float gravity = 15.0F;
    Vector3 moveDirection;
    Rigidbody rb;
    //personagem status 

    public bool isActiveSmoke = false;
    public bool isActiveSwitch = false;
    public Text pontosUI;
    public Text dinheiroUI;
    public Image[] vida;
    public GameObject[] ampulhetaHUD;
    int posAmpulheta = 0;
    public GameObject Hud;
    public GameObject Player;
    string prefabColidido;
    public GameObject Arma;
    public ParticleSystem particle;
    public GameObject impact;
    public Vector3 pos;
   
   



    private void Start()
    {



        coin.color = Color.white;
        profile.vignette.enabled = false;
        //profile.colorGrading.enabled = false;
        DontDestroyOnLoad(Player);
    }

    private void FixedUpdate()
    {

        MousePosition = cam.WorldToScreenPoint(Input.mousePosition);
        //mov();
        updatePontos();
        danoHud();
        HUDampulheta();
        isAlive();
        Movimento();
        ShootDefault();
        Mirar();
    }

    //Condição de derrota
    void isAlive()
    {   
        if (vidas <= 0)
        {

            Time.timeScale = 0;
            Hud.transform.GetChild(16).GetComponent<Text>().enabled = true;
            //StartCoroutine(Dead());
            Player.GetComponentInChildren<Renderer>().enabled = false;
            profile.vignette.enabled = false;
            //profile.colorGrading.enabled = true;
            if (Input.GetMouseButton(0))
                SceneManager.LoadSceneAsync("HUDFINAL", LoadSceneMode.Single);
        }
    }

    void danoHud()
    {
        if (vidas == 2)
        {
            vida[2].color = Color.red;
        }
        if (vidas == 1)
        {
            vida[1].color = Color.red;
        }
        if (vidas == 0)
        {
            vida[0].color = Color.red;
        }

    }




    //Fim Condição de derrota

    //Respostas a Colisoes
    private void OnTriggerEnter(Collider other)
    {
        prefabColidido = other.gameObject.transform.tag;
        
        switch (prefabColidido)
        {
            case "Coin":


                Audiocoin.Play();
                dinheiro += valorCoin;
                dinheiroUI.text = " Dinheiro : " + dinheiro.ToString();
                Destroy(other.gameObject);
                break;

            case "ampulheta":

                GameObject.Find("CroMe.V1").GetComponent<AudioSource>().Play();

                if (barra < 100)
                {
                    barra += 50;  
                }

                if (barra >= 100)
                {
                    isActiveSwitch = true;
                }
                Destroy(other.gameObject);
                break;

            case "smoke":

                isActiveSmoke = true;
                Destroy(other.gameObject);

                break;

            case "jetpack":
                StartCoroutine(jetpack());
                Destroy(other.gameObject);
                break;

            case "shield":
                GameObject.Find("shield").GetComponent<AudioSource>().Play();
                shieldGO.GetComponent<Renderer>().enabled = true;
                isActiveShield = true;
                Destroy(other.gameObject);
                break;

            case "doublecoin":
                StartCoroutine(DoubleCoin());
                Destroy(other.gameObject);
                break;

            case "jeep":
                Anime.SetTrigger("Hit");
                if (isActiveShield != true)
                {
                    vidas -= 1;
                    StartCoroutine(Dano());
                }
                else
                {
                    shieldGO.GetComponent<Renderer>().enabled = false;
                    isActiveShield = false;
                }
                Target target = other.transform.GetComponent<Target>();
                target.jeepDamage(20);

                break;



        }
    }
    int frame = 0;
    void updatePontos()
    {
       
        frame += 1;
        if (frame >= 15) {
            pontos += 1;
            pontosUI.text = "Pontos : " + pontos.ToString();
            frame = 0;
        }

        }
    //Fim respostas a colisoes

    void HUDampulheta()
    {
        if (barra == 25)
        {
            ampulhetaHUD[0].GetComponent<Image>().enabled = true;
            ampulhetaHUD[1].GetComponent<Image>().enabled = true;
        }
        if (barra == 50)
        {
            ampulhetaHUD[2].GetComponent<Image>().enabled = true;
            ampulhetaHUD[3].GetComponent<Image>().enabled = true;
        }
        if (barra == 75)
        {
            ampulhetaHUD[4].GetComponent<Image>().enabled = true;
            ampulhetaHUD[5].GetComponent<Image>().enabled = true;
        }
        if (barra == 100)
        {
            ampulhetaHUD[6].GetComponent<Image>().enabled = true;
            ampulhetaHUD[7].GetComponent<Image>().enabled = true;
        }
        if (barra == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                ampulhetaHUD[i].GetComponent<Image>().enabled = false;
            }
        }


    }


    //movimentação personagem
    void Movimento()
    {
        float z = 0;
        CharacterController controller = GetComponent<CharacterController>();
        Anime.SetBool("isGrounded", controller.isGrounded);
        if (controller.isGrounded)
        {
           
            z = Input.GetAxis("Horizontal");
            moveDirection = new Vector3(1f, 0, z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetKeyDown(KeyCode.W))
            {
                Anime.SetTrigger("Jump");
                moveDirection.y = jumpSpeed;
                
            }
            if (controller.isGrounded)
            {
                Anime.SetTrigger("isGrounded");
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }

    IEnumerator Dano()
    {
        profile.vignette.enabled = true;
        yield return new WaitForSecondsRealtime(2f);
        profile.vignette.enabled = false;
    }

    void Mirar()
    {

    }


    void ShootDefault()
    {
        int damage = 5;
        float range = 100f;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButton("Fire1"))
        {
            particle.Play();
            GameObject.Find("MuzzleFlashEffect").GetComponent<AudioSource>().Play();
            if (Physics.Raycast(ray, out hit))
            {

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.jeepDamage(damage);
                }
                GameObject impatcGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impatcGO, 2f);
            }
        }

    }

    IEnumerator jetpack()
    {
        isActiveJetpack = true;
        Jetpack.SetActive(true);
        yield return new WaitForSeconds(15f);//depois a gente decide o tempo 
    }


    /* IEnumerator Dead()
     {
         SceneManager.LoadSceneAsync("HUDFINAL", LoadSceneMode.Single);
         yield return new WaitForSeconds(5f);
     }*/

    IEnumerator DoubleCoin()
    {
        valorCoin = 20;
        coin.color = Color.green;
        yield return new WaitForSeconds(6f);
        valorCoin = 10;
        coin.color = Color.white;

    }

}
