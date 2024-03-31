using FMODUnity;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found More than one Audio Manager in the scene.");
        }
       if (instance = this)
        {
            Debug.Log(" Audio Manager is set up.");
        }
    }
    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
