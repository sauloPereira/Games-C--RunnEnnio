using UnityEngine;
using System.Collections;

public class Spawns : MonoBehaviour {

    public GameObject[] objetos;
    public GameObject[] spawns;
    float velocityBall = 1;

	// Use this for initialization
	void Start () {

        StartCoroutine("spawn");

	}
	
	// Update is called once per frame
	void Update () {
	


	}
    int numero2;
    int numero;
    IEnumerator spawn() {

        yield return new WaitForSeconds(velocityBall);
        numero = Random.Range(0, spawns.Length);
        numero2 = Random.Range(0, objetos.Length);
        Instantiate(objetos[numero2].gameObject,spawns[numero].transform.position, spawns[numero].transform.rotation);
        StartCoroutine("spawn");
        velocityBall -= 0.01f;
       
    }
}
