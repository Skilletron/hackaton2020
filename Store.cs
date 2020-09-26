using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    Animator animator;
    public int Money;
    public GameObject Stores;
    public GameObject Glock;
    public GameObject Ak;
    public GameObject Revolver;
    public Text Glock_text;
    public Text Ak_text;
    public Text Revolver_text;
    public Text Glock_text_Eqp, Ak_text_Eqp, Revolver_text_Eqp;
    AudioSource audio;
    public AudioClip clip,clip_2;
    public GameObject Audio;
    public GameObject Buy_Revolver, Buy_Glock, Buy_AK, Eqp_Revolver, Eqp_Glock, Eqp_AK;
    public DataManager dataManager;
    public SaveAllGame playerData;
    public int IsAK, IsGlock, IsRevolver;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
      
    }
    private void Update()
    {
        Money = dataManager.data.Money_Player;
        if (playerData.Money >= 500 & Money - 500 > 0)
        {
            Buy_Glock.GetComponent<Button>().interactable = true;

        }
        else
        {
            Buy_Glock.GetComponent<Button>().interactable = false;
        }
        if (playerData.Money >= 3500 & Money - 3500 > 0)
        {
            Buy_Revolver.GetComponent<Button>().interactable = true;
        }
        else
        {
            Buy_Revolver.GetComponent<Button>().interactable = false;
        }
        if (playerData.Money >= 8500 & Money - 8500 > 0)
        {
            Buy_AK.GetComponent<Button>().interactable = true;
        }
        else
        {
            Buy_AK.GetComponent<Button>().interactable = false;
        }
        if(IsRevolver == 1)
        {
            Eqp_AK.GetComponent<Button>().interactable = true;
            Eqp_Glock.GetComponent<Button>().interactable = true;
            Eqp_Revolver.GetComponent<Button>().interactable = false;
            Glock_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Revolver_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Ak_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Revolver_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировано";
            Ak_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировать";
            Glock_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировать";
            
        }
        if (IsGlock == 1)
        {
            Eqp_AK.GetComponent<Button>().interactable = true;
            Eqp_Revolver.GetComponent<Button>().interactable = true;
            Eqp_Glock.GetComponent<Button>().interactable = false;
            Glock_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Revolver_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Ak_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Glock_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировано";
            Ak_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировать";
            Revolver_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировать";
        }
        if (IsAK == 1)
        {
            Eqp_Revolver.GetComponent<Button>().interactable = true;
            Eqp_Glock.GetComponent<Button>().interactable = true;
            Eqp_AK.GetComponent<Button>().interactable = false;
            Glock_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Revolver_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Ak_text.gameObject.GetComponent<Text>().text = "Улучшить";
            Ak_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировано";
            Revolver_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировать";
            Glock_text_Eqp.gameObject.GetComponent<Text>().text = "Экипировать";
            
        }
    }
    public void OnclickButtonStore()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        animator = Stores.GetComponent<Animator>();
        animator.SetBool("IsClick", true);
        animator.SetBool("IsClickExit", false);
    }
    public void OnclickButtonStoreExit()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        animator = Stores.GetComponent<Animator>();
        animator.SetBool("IsClick", false);
        animator.SetBool("IsClickExit", true);
    }
    public void OnclickButtonStore_Glock_true()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        Glock.gameObject.SetActive(true);
        Revolver.gameObject.SetActive(false);
        Ak.gameObject.SetActive(false);
    }
   
    public void OnclickButtonStore_Ak_true()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        Ak.gameObject.SetActive(true);
        Revolver.gameObject.SetActive(false);
        Glock.gameObject.SetActive(false);
    }
 
    public void OnclickButtonStore_Revolver_true()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        Revolver.gameObject.SetActive(true);
        Glock.gameObject.SetActive(false);
        Ak.gameObject.SetActive(false);
    }
    public void OnclickButton_Revolver_Buy()
    {
        Eqp_Revolver.GetComponent<Button>().interactable = true;
        playerData.Money -= 3500;
        Audio.GetComponent<AudioSource>().PlayOneShot(clip_2);
        

    }
    public void OnclickButton_Glock_Buy()
    {
        Eqp_Glock.GetComponent<Button>().interactable = true;
        Audio.GetComponent<AudioSource>().PlayOneShot(clip_2);
        playerData.Money -= 500;
       Glock_text.gameObject.GetComponent<Text>().text = "Улучшить";

    }
    public void OnclickButton_AK_Buy()
    {
       Eqp_AK.GetComponent<Button>().interactable = true;
        Audio.GetComponent<AudioSource>().PlayOneShot(clip_2);
        playerData.Money -= 8500;
       

    }
    public void OnclickButton_AK_Eqp()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        IsRevolver = 0;
        IsGlock = 0;
        IsAK = 1;       
    }
    public void OnclickButton_Glock_Eqp()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        IsRevolver = 0;
        IsAK = 0;
        IsGlock = 1;            
    }
    public void OnclickButton_Revolver_Eqp()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(clip);
        IsGlock = 0;
        IsAK = 0;
        IsRevolver = 1;        
    }

}
