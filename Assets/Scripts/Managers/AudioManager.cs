using FMODUnity;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private Dictionary<string, EventInstance> zoneSoundtracks;
    private string currentZone = "";

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
        zoneSoundtracks = new Dictionary<string, EventInstance>();
    }

    public void PlayZoneSoundtrack(string zone)
    {
        if (zoneSoundtracks.ContainsKey(zone))
        {
            // If the soundtrack for the specified zone is already playing, return
            if (zone == currentZone)
            {
                Debug.Log("Zone soundtrack for " + zone + " is already playing.");
                return;
            }

            // Stop the currently playing soundtrack
            StopCurrentSoundtrack();

            // Play the soundtrack for the specified zone
            zoneSoundtracks[zone].start();
            currentZone = zone;

            Debug.Log("Playing zone soundtrack for " + zone);
        }
        else
        {
            Debug.LogWarning("Soundtrack for zone " + zone + " is not found.");
        }
    }

    public void StopCurrentSoundtrack()
    {
        if (!string.IsNullOrEmpty(currentZone) && zoneSoundtracks.ContainsKey(currentZone))
        {
            zoneSoundtracks[currentZone].stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentZone = "";
            Debug.Log("Stopped current zone soundtrack.");
        }
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

    public void AddZoneSoundtrack(string zone, EventInstance eventInstance)
    {
        if (!zoneSoundtracks.ContainsKey(zone))
        {
            zoneSoundtracks.Add(zone, eventInstance);
            Debug.Log("Added soundtrack for zone: " + zone);
        }
        else
        {
            Debug.LogWarning("Soundtrack for zone " + zone + " already exists.");
        }
    }
}
