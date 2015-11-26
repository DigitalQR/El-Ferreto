using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] clips;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
	}
	
    private AudioClip GetRandomClip()
        {
	        return clips[Random.Range(0, clips.Length)]; //looking for audio clips from 0 to n of clips
        }


	// Update is called once per frame
	void Update () {
	    if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        
        }
	}
}
