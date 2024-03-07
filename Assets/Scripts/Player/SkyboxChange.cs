using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    public Material cityCentre;
    public Material industrial;
    public Material sewer;

    private void Start()
    {
        RenderSettings.skybox = cityCentre;
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "City Centre" && other.gameObject.tag == "Player")
        {
            RenderSettings.skybox = cityCentre;
        }
        if (this.gameObject.tag == "Industrial" && other.gameObject.tag == "Player")
        {
            RenderSettings.skybox = industrial;
        }
        if (this.gameObject.tag == "Sewer" && other.gameObject.tag == "Player")
        {
            RenderSettings.skybox = sewer;
        }
    }

}
