using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SoundtrackManager : MonoBehaviour
{
    [Header("FMOD Events")]
    public EventReference patrolSoundtrack;
    public EventReference chaseSoundtrack;
    private EventInstance currentSoundtrack;

    void Start()
    {
        // Start with the patrol soundtrack
        PlayPatrolSoundtrack();
    }

    public void PlayPatrolSoundtrack()
    {
        // Stop the current soundtrack
        if (currentSoundtrack.isValid())
            currentSoundtrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        // Play the patrol soundtrack
        currentSoundtrack = RuntimeManager.CreateInstance(patrolSoundtrack);
        currentSoundtrack.start();
    }

    public void PlayChaseSoundtrack()
    {
        // Stop the current soundtrack
        if (currentSoundtrack.isValid())
            currentSoundtrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        // Play the chase soundtrack
        currentSoundtrack = RuntimeManager.CreateInstance(chaseSoundtrack);
        currentSoundtrack.start();
    }
}
