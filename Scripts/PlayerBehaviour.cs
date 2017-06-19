using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviour : MonoBehaviour {

    public Animator animator;
    public GameObject player;
    public GameObject hit;
    public GameObject gameOver;
    public GameObject mobileControl;

    public float velocity;
    public float forceJump;

    public float timeTemp;
    public float downTemp;

    public float invencivel;

    public static bool inDeath;
    public static bool pontuado;
    public bool ifInGround;
    public bool isDown = false;
    public bool doubleJump = false;
    public GameObject inGround;
    public GameObject activeCoins;
    public GameObject activeLife;
    public Transform colisor;

    public int life = 1;
    public static float ponto;
    public int coins;
    public int photos;
    public Text coin;
    public Text photo;
    public Text pontos;
    public Text lifet;

    public Text recordT;
    public Text scoreT;
    public int record;

    public AudioClip soundJump;
    public AudioClip soundCoin;
    public AudioClip soundlife;
    public AudioClip soundCollider;
    public AudioClip soundDamage;

    void Start () {

        pontuado = true;

	}


    void Update()
    {

        pontos.text = "0" + Mathf.Round (ponto);
        coin.text = "X " + coins;
        lifet.text = "X " + life;
        photo.text = "X " + photos;

        if (pontuado) {
            ponto += 1 * Time.deltaTime;
        
        }

        record = (int)ponto + coins;

        if (record > PlayerPrefs.GetInt("record")) {
            PlayerPrefs.SetInt("record", record);

        }
        
        PlayerPrefs.SetInt("score", record);

        if (velocity == 0)
        {
            animator.SetFloat("velocity", Mathf.Abs(0));
        }

        //JUMP=================================
        ifInGround = Physics2D.Linecast(transform.position, inGround.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        Jump();

        if (photos > 0 && !ifInGround && doubleJump == true) {

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * 500);

                GetComponent<AudioSource>().clip = soundJump;
                GetComponent<AudioSource>().Play();
                doubleJump = false;
                photos--;

            }
            
        }

       
        //==========================================

        Down();

    }


    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "addLife") {
            if (life < 3) {
                life++;

            }
            if (life >= 3) {
                coins += 30;

            }
            GetComponent<AudioSource>().clip = soundlife;
            GetComponent<AudioSource>().Play();
            Particula();

        }

        else if (other.tag == "addCoin") {
            coins++;
            Particula();

            GetComponent<AudioSource>().clip = soundCoin;
            GetComponent<AudioSource>().Play();

        }


        else if (other.tag == "Damage") {

            if (invencivel <= 0f) {
                life--;
                GetComponent<AudioSource>().clip = soundCollider;
                GetComponent<AudioSource>().Play();
                hitPrefab();
                if (life == 0)
                {
                    GameOver();
                    player.SetActive(false);

                }

                invencivel = 0.7f;

            }

            GetComponent<AudioSource>().clip = soundDamage;
            GetComponent<AudioSource>().Play();


        }

        else if (other.tag == "addPhoto") {
            photos++;
            Particula();

            GetComponent<AudioSource>().clip = soundlife;
            GetComponent<AudioSource>().Play();

        }

    }

    private void FixedUpdate()
    {
        Invencivel();
    }

    public void Invencivel()
    {
        var cor = GetComponent<SpriteRenderer>().color;
        if (invencivel > 0f)
        {
            if (cor.a == 1f)
                cor.a = 0f;
            else
                cor.a = 1f;
            invencivel -= Time.deltaTime;
        }
        else
            cor.a = 1f;

        GetComponent<SpriteRenderer>().color = cor;
    }


    public void Particula() {
 
         var prefabParticulas = Resources.Load("Prefabs/ParticlesItens");
         var particulas = GameObject.Instantiate(prefabParticulas) as GameObject;
         particulas.transform.position = player.transform.position;
         particulas.transform.parent = player.transform;
         GameObject.Destroy(particulas, 0.5f);

    }


    public void hitPrefab() {

        var prefabHit = Resources.Load("Prefabs/hit");
        var getHit = Instantiate(hit);
        getHit.transform.position = player.transform.position;
        Destroy(getHit, 0.5f);
        
    }

    public void GameOver() {
        inDeath = true;
        gameOver.SetActive(true);
        mobileControl.SetActive(false);
        Time.timeScale = 0f;
        pontuado = false;

        scoreT.text = PlayerPrefs.GetInt("score").ToString();
        recordT.text = PlayerPrefs.GetInt("record").ToString();


    }

    public void Jump() {

        if (CrossPlatformInputManager.GetButtonDown("Jump") && ifInGround)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * forceJump);

            GetComponent<AudioSource>().clip = soundJump;
            GetComponent<AudioSource>().Play();

            doubleJump = true;
        }

        animator.SetBool("inGround", ifInGround);

    }

    public void Down() {

        if (CrossPlatformInputManager.GetButtonDown("Down") && ifInGround && isDown == false) //(Input.GetKeyDown(KeyCode.DownArrow) && ifInGround && isDown == false)
        {
            isDown = true;
            colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.80f, colisor.position.z);
            timeTemp = 0;
            animator.SetTrigger("down");

        }

        if (isDown)
        {
            timeTemp += Time.deltaTime;
            if (timeTemp >= downTemp)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.80f, colisor.position.z);

                isDown = false;
            }

        }

    }

}
