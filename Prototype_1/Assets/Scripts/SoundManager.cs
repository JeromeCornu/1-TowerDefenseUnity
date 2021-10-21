using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioSource sfxSource;

    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void Start()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sfx") as AudioClip[];

        foreach (AudioClip clip in clips)
        {
            audioClips.Add(clip.name, clip);
        }
    }

    // SFX
    public void PlaySFX(string name)
    {
        sfxSource.PlayOneShot(audioClips[name]);
    }

}
