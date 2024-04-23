using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigator : MonoBehaviour
{
    public static SceneNavigator instance;
    private string previousSceneName;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        previousSceneName = SceneManager.GetActiveScene().name;
    }

    public void LoadCityCentre()
    {
        if (SceneManager.GetActiveScene().name != "Rotbrew_CityCentre")
        {
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Rotbrew_CityCentre");
        }
    }

    public void LoadIndustrialZone()
    {
        if (SceneManager.GetActiveScene().name != "Rotbrew_Industrial")
        {
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Rotbrew_Industrial");
        }
    }

    public void LoadSewer()
    {
        if (SceneManager.GetActiveScene().name != "Rotbrew_Sewer")
        {
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Rotbrew_Sewer");
        }
    }

     public void LoadFinalBossArena()
    {
        if (SceneManager.GetActiveScene().name != "Rotbrew_Kalos")
        {
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Rotbrew_Kalos");
        }
    }
}
