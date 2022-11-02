using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnFunctions
{

    [YarnCommand("teleport")]
    public static void teleport(bool goingUp){
        GameObject player;
        player = GameObject.Find("player");

        if(goingUp){
            player.transform.position += new Vector3(-3,6,0);
        } else {
            player.transform.position += new Vector3(0,-7,0);
        }
    }

    [YarnCommand("play_sound")]
    public static void playSound(string name){
        GameObject player;
        AudioClip clipToPlay = Resources.Load<AudioClip>(name);
        player = GameObject.Find("player");

        AudioSource audio = player.GetComponent<AudioSource>();

        audio.clip = clipToPlay;
        audio.Play();
    }
}
