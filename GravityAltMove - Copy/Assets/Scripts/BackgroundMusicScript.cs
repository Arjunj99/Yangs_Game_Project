using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    private static BackgroundMusicScript instance = null;
 	public static BackgroundMusicScript Instance {
        get { return instance; }
}

 void Awake() 
 {
     if (instance != null && instance != this) {
         Destroy(this.gameObject);
         return;
     } else {
         instance = this;
     }
     DontDestroyOnLoad(this.gameObject);
 }

}

//Courtesy of: https://answers.unity.com/questions/11314/audio-or-music-to-continue-playing-between-scene-c.html