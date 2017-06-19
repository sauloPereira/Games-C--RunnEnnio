using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject objeto;
    public float velocity;


	void Start () {

        
	}
	
    void Update () {

        transform.position += new Vector3(velocity, 0, 0);

        if (transform.position.x < -15) {
            Destroy(objeto);


        }

    }
}
