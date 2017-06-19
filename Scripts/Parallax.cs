using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

    public float speed;
    public Material materialTextu;

    private void Start()
    {
        
    }

    void Update () {

        materialTextu.mainTextureOffset = new Vector2(Time.time * speed, 0);
	
	}
}
