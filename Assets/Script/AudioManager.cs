using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Variables
	public static AudioManager instance;
	public AudioMixerGroup mixerGroup;
	public Sound[] sounds;
    public String nameOfMainSong;

    //Function to call or do thing when the scripts awake
	void Awake()
	{
        //Dont Destroy system its to play music in all scenes without stop them when you reset the scene or load other.
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

    //When the function start in the start of the game, play the main song
    void Start()
    {
        Play(nameOfMainSong);
    }

    //You send in the inspector a name of a sound or music you added to the array after to play it.
    public void Play(string sound)
	{
        //If the name dosent exist, call the exception to save the error and tell you what happend
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

}
