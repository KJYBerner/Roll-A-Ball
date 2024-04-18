using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    //Will cahnge our scene to the string passed in
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName); ;
    }

    //Reloads the current scne we are in
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Load out Title scene
    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ToLevelSelectScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ToLvl1Scene()
    {
        SceneManager.LoadScene("Main");
    }


    //Gets our active scenes name
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ToLevel2Scene()
    {
        SceneManager.LoadScene("Lvl 2");
    }

    public void ToLevel3Scene()
    {
        SceneManager.LoadScene("Lvl 3");
    }

    public void ToLevel4Scene()
    {
        SceneManager.LoadScene("Lvl 4");
    }

    public void ToLevel5Scene()
    {
        SceneManager.LoadScene("Lvl 5");
    }
}
