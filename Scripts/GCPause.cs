using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GCPause : MonoBehaviour {

    public GameObject menu;
    public GameObject mobileControl;
    public Image buttonVolume;
    public GCCamera camera;


	void Update () {

        if (CrossPlatformInputManager.GetButtonDown("Cancel")) {
            Menus();

        }

	}

    public void Menus() {

        //if (PlayerBehaviour.inDeath == false) {
            menu.SetActive(true);
            mobileControl.SetActive(false);
            Time.timeScale = 0f;
            PlayerBehaviour.pontuado = false;
        //}

    }

    public void Voltar() {
        Time.timeScale = 1f;
        menu.SetActive(false);
        mobileControl.SetActive(false);
        PlayerBehaviour.pontuado = true;
    }

    public void mainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        PlayerBehaviour.ponto = 0;
    }

    public void Reinicio() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("RunnEnnio");
        PlayerBehaviour.ponto = 0;

    }

    public void Volume() {

        var volume = PlayerPrefs.GetInt("volume");
        var color = buttonVolume.color;
        if (volume == 1) {
            PlayerPrefs.SetInt("volume", 0);
            color.a = 0.4f;
            camera.DisableSom();

        }
        else {
            PlayerPrefs.SetInt("volume", 1);
            color.a = 1f;
            camera.EnableSom();

        }

         buttonVolume.color = color;

    }

}
