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
}
