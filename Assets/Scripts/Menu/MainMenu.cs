using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string mainSceneName;


    public void Play()
    {
        SceneManager.LoadScene(mainSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
