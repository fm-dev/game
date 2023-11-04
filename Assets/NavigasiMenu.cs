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
}
