using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    AudioSource audio;
    public AudioClip clip;
    public GameObject Audio;
    public void Onclick_Menu()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        SceneManager.LoadScene("Menu");
    }
    public void Onclick_Exit()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        Application.Quit();
    }
    public void Onclick_Level_1()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        SceneManager.LoadScene("Level_1");
    }
    public void Onclick_Level_2()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        SceneManager.LoadScene("Level_2");
    }
    public void Onclick_Level_3()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        SceneManager.LoadScene("Level_3");
    }
}