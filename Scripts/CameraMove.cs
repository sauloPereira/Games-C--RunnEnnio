using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public Transform player; 
	
	void Start () {
	
	}
	
	
	void Update () {

       transform.position = new Vector3(0, player.position.y+0.5f, player.position.z-1.8f);

	}
}
