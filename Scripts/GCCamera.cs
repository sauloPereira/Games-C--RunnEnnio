using UnityEngine;
using System.Collections;

public class GCCamera : MonoBehaviour {

    void Start() {
        if (PlayerPrefs.GetInt("volume") == 1)
            EnableSom();
        else
            DisableSom();

    }

    public void Update() {

    }

    public void EnableSom() {
        AudioListener.volume = 1f;

    }

    public void DisableSom() {
        AudioListener.volume = 0f;

    }

}
