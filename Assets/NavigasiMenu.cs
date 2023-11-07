using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NavigasiMenu : MonoBehaviour
{

    public void SwitchToTargetScene(string targetSceneName)
    {
        SceneManager.LoadScene(targetSceneName);
    }
    public void SwitchToEasyGame(string targetSceneName)
    {
        string level = "easy";
        PlayerPrefs.SetString("setLevel", level);
        SceneManager.LoadScene(targetSceneName);
    }
    public void SwitchToMediumGame(string targetSceneName)
    {
        string level = "medium";
        PlayerPrefs.SetString("setLevel", level);
        SceneManager.LoadScene(targetSceneName);
    }
    public void SwitchToHardGame(string targetSceneName)
    {
        string level = "hard";
        PlayerPrefs.SetString("setLevel", level);
        SceneManager.LoadScene(targetSceneName);
    }
    public void quit(string quit){
         Application.Quit(); 
    }
}
