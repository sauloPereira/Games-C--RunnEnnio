using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnObj : MonoBehaviour {

    public float maxHeight;
    public float minHeight;
    //public int maxObj;
    //public List<GameObject> obj; 

    
    private int posicao;
    public float y;

    private float currentRateSpawn;

    public float rateSpawn;     //Tempo para respawn

    public GameObject prefab;


	void Start () {

        currentRateSpawn = 0;

	/*========Respawn por SetActive====================
        for (int i = 0; i < maxObj; i++) {

            GameObject timeObj = Instantiate(prefab)  as GameObject;
            obj.Add(timeObj);
            timeObj.SetActive(false);

        }
    =================================================*/
	}
	

	void Update () {

        currentRateSpawn += Time.deltaTime;

        if (currentRateSpawn >= rateSpawn) {
            currentRateSpawn = 0;
            //Spawn();
            GameObject tempPrebaf = Instantiate(prefab) as GameObject;
            posicao = Random.Range(1, 100);
            if (posicao > 50) {
                y = maxHeight;      //-0.04f;
            }
            else {
                y = minHeight;      //-3.4f;
            }
            tempPrebaf.transform.position = new Vector3(transform.position.x, y, transform.position.z);


        }

	
	}
    /*=============Respawn por SetActive====================
    private void Spawn() {

        float randomPosition = Random.Range(minHeight, maxHeight);

        GameObject timeObj = null;

        for (int i = 0; i < maxObj; i++) {
            if (obj[i].activeSelf == false) {
                timeObj = obj[i];

                break;
            }

        }

        if (timeObj != null) {
            timeObj.transform.position = new Vector3(transform.position.x, randomPosition, transform.position.z);
            timeObj.SetActive(true);

        }


    }

    ==================================================*/
}
