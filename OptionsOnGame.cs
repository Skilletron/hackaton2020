using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsOnGame : MonoBehaviour
{
    public GameObject Menu;
    public AudioClip clip;
    public GameObject Audio;
    public void OnClickOptions()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        Menu.SetActive(true);
    }
    public void OnClickOptionsClose()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        Menu.SetActive(false);
    }
}
