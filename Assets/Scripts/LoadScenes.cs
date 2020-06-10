using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadTerrain()
    {
        SceneManager.LoadScene("Terrain");
    }

    public void LoadAR()
    {
        SceneManager.LoadScene("ARMobile");
    }
    
}
