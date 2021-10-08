using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// PAS FINI : https://www.youtube.com/watch?v=AFcHsKd_aMo&t=0s à 4:57
public class SoundActive : MonoBehaviour
{
    [SerializeField] Image SoundOff;
    [SerializeField] Image SoundOn;
    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if  (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }

    public void UpdateButtonIcon()
    {
        if (muted == false)
        {
            SoundOn.enabled = true;
            SoundOff.enabled = false;
        }
        else
        {
            SoundOn.enabled = false;
            SoundOff.enabled = true;
        }
        Save();
        UpdateButtonIcon();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

}
