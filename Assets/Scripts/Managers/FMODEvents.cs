using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player Footsteps")]
    [field: SerializeField] public EventReference playerFootsteps { get; private set; }

    [field: Header ("Potion Smash")]
    [field: SerializeField] public EventReference potionSmashed { get; private set;}

    [field: Header("Potion Throw")]
    [field: SerializeField] public EventReference potionThrow { get; private set; }

    public static FMODEvents instance {  get; private set; }

    private void Awake()
    {
        {
            if (instance != null) 
            {
                Debug.LogError("Found more than one FMOD Events instance in this scene.");
            }
            instance = this;
        }
    }
}
