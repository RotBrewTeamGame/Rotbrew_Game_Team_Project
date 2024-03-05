using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found More than one Audio Manager in the scene.");
        }
        instance = this;
        eventInstances = new List<EventInstance>();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }
}
