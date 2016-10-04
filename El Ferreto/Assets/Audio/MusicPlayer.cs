using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    
    public static bool exists = false;

    public AudioClip[] clips;
    private AudioSource audioSource;

   
	// Use this for initialization
	void Start () {
        
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;

        if (exists)
        {
            Destroy(this.gameObject);
        }else exists = true;
        
	}
	
    private AudioClip GetRandomClip()
    {
	    return clips[Random.Range(0, clips.Length)]; //looking for audio clips from 0 to n of clips
    }


	// Update is called once per frame
	void Update () {

        if (!audioSource.isPlaying) //if no music is playing
        {
            audioSource.clip = GetRandomClip(); //pick a random song clip
            audioSource.Play();  //play song
	    }   
        
    }


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


}

