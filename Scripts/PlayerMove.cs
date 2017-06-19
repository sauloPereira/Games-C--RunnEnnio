using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public float velocity;
    static int Tempo;

    public int life = 5;
    public int pontos;
    public Text lifeT;
    public Text pontosT;
    public GameObject gameOver;

	void Start () {

        StartCoroutine("tempo");

	}


    void Update()
    {

        if (life <= 0)
        {
            gameOver.SetActive(true);
        }
        else
        {
            gameOver.SetActive(false);
        
            lifeT.text = "Life: " + life;
            pontosT.text = "Coin: " + pontos;

            if (this.transform.position.x < (-2.6f))
            {
                this.transform.position = new Vector3(-2.6f, transform.position.y, transform.position.z);
            }
            else if (this.transform.position.x > (2.6f))
            {
                transform.position = new Vector3(2.6f, transform.position.y, transform.position.z);
            }
            else
            {
                this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0, velocity * Time.deltaTime);
            }

        }

	}

    IEnumerator tempo() {

        yield return new WaitForSeconds(1);
        Tempo++;
        velocity += 0.1f;
    }

     void OnTriggerEnter(Collider other) {

        if (other.tag == "addLife") {
            if (life < 5) {
                life++;
                Debug.Log("+ vida");
            }
            pontos++;
            Debug.Log("+ coins");
        }
        else if (other.tag == "addCoin") {
            pontos++;
            Debug.Log("+ coins");
        }
        else if (other.tag == "Damage") {
            life--;
            Debug.Log("+ dano");
        }

        Destroy(other.gameObject);

    }

    void Reiniciou() {

        life = 5;
        pontos = 0;

    }

}
