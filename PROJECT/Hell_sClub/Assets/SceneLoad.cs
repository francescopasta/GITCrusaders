using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("ChapelScene_Madi_Fran");
    }
}
