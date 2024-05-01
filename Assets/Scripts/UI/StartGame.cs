using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{
    public TMP_Text buttonText;

    public void LoadSceneOnClick()
    {
        LightingManager.Instance.SaveLightingSettings(); // Save lighting settings before loading new scene
        SceneManager.LoadScene("Rotbrew_CityCentre");
        buttonText.text = "Loading...";
    }
}