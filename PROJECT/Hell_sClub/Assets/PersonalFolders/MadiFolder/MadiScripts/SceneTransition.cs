using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneName;

    public void OnAnimationComplete()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("Quit :(");
    }
}
