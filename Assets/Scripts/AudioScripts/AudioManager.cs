using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
   public static AudioManager instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found More than one Audio Manager in the scene.");
        }
        instance = this;
    }

    public void PlayOneShot (EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
