using UnityEngine;
using System.Collections;

public class ObjetosBehaviour : MonoBehaviour
{

    public GameObject objeto;

    public float velocity;
    //public float activePosition;

    void Start() {

    }

    void Update() {

        transform.position += new Vector3(velocity, 0, 0);

        if (transform.position.x < -15)
        {
            Destroy(objeto);
            //objeto.SetActive(false);
        }

        if (PlayerBehaviour.ponto > 300) {

            velocity = -1f;

        }
        else if (PlayerBehaviour.ponto > 100) {

            velocity = -0.5f;

        }
        else if (PlayerBehaviour.ponto > 80) {

            velocity = -0.4f;

        }

    }

}
