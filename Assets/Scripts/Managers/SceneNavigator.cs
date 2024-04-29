using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigator : MonoBehaviour
{
    public GameObject loadingScreen;
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

        loadingScreen.SetActive(false);
    }

    public void LoadCityCentre()
    {
        if (SceneManager.GetActiveScene().name != "Rotbrew_CityCentre")
        {
            loadingScreen.SetActive(true);
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Rotbrew_CityCentre");
        }
    }

    public void LoadIndustrialZone()
    {
        if (SceneManager.GetActiveScene().name != "Rotbrew_Industrial")
        {
            loadingScreen.SetActive(true);
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Rotbrew_Industrial");
        }
    }

    public void LoadSewer()
    {
        if (SceneManager.GetActiveScene().name != "Rotbrew_Sewer")
        {
            loadingScreen.SetActive(true);
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Rotbrew_Sewer");
        }
    }

     public void LoadFinalBossArena()
    {
        if (SceneManager.GetActiveScene().name != "Rotbrew_Kalos")
        {
            loadingScreen.SetActive(true);
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Rotbrew_Kalos");
        }
    }
}
