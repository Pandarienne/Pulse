using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource ambience;
    // Start is called before the first frame update
    void Start()
    {
        ambience = GetComponent<AudioSource>();
        ambience.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
