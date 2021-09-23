using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    AudioSource intro;
    int lastTime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        intro = GetComponent<AudioSource>();
        intro.clip = audioClips[0];
        intro.clip.LoadAudioData();
        Debug.Log(intro.clip);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if ((int)timer == 5)
        {
            intro.clip = audioClips[1];
            Debug.Log(intro.clip);
        }
        /*if ((((int)timer) - lastTime) == 1)
        {
            lastTime = (int)timer;
            Debug.Log((int)timer);
        } */

    }
}
