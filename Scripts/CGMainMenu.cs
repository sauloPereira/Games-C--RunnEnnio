using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CGMainMenu : MonoBehaviour {

    public GameObject panelMainMenu;
    public GameObject panelConfiguracoes;
    public Image buttonVolume;
    public GCCamera camera;
    public Text recordT;


    void Awake() {

        if (!PlayerPrefs.HasKey("volume")) {
            PlayerPrefs.SetInt("volume", 1);

        }

        var volume = PlayerPrefs.GetInt("volume");
        var color = buttonVolume.color;

        if (volume == 1) {
            color.a = 1f;
        }
        else {
            color.a = 0.4f;
        }
        buttonVolume.color = color;
    }

    public void Start() {

        recordT.text = PlayerPrefs.GetInt("record").ToString();

    }

    public void iniciarJogo() {

        SceneManager.LoadScene("RunnEnnio");

    }

    public void botaoConfiguration() {

        panelMainMenu.SetActive(false);
        panelConfiguracoes.SetActive(true);

    }

    public void Sair() {

        Application.Quit();

    }

    //configurações

    public void botaoVolume() {

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

    public void Voltar() {

        panelMainMenu.SetActive(true);
        panelConfiguracoes.SetActive(false);

    }

}
