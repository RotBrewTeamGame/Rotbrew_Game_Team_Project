using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string Rotbrew_CityCentre;

    public void LoadSceneOnClick()
    {
        LightingManager.Instance.SaveLightingSettings(); // Save lighting settings before loading new scene
        SceneManager.LoadScene(Rotbrew_CityCentre);
    }
}