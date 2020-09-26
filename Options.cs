using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    Animator animator;
    public GameObject Option;
    public Slider Slider;
    AudioSource audio;
    public AudioClip clip;
    public GameObject Audio;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Update()
    {
        AudioListener.volume = Slider.value;
        
    }
    public void OnclickButtonOptions()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        animator = Option.GetComponent<Animator>();
        animator.SetBool("IsClick",true) ;
        animator.SetBool("IsClickExit", false);
    }
    public void OnclickButtonOptionsExit()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        animator = Option.GetComponent<Animator>();
        animator.SetBool("IsClick", false);
        animator.SetBool("IsClickExit", true);
    }
    public void OnclickButtonMuteSound()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        Slider.value = 0;
    }
   
}
