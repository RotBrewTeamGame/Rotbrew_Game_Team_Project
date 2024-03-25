using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string GAD3_NightOwls_Rotbrew_V2;

    public void LoadSceneOnClick()
    {
        LightingManager.Instance.SaveLightingSettings(); // Save lighting settings before loading new scene
        SceneManager.LoadScene(GAD3_NightOwls_Rotbrew_V2);
    }
}