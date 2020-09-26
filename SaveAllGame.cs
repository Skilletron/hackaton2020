using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class SaveAllGame : MonoBehaviour
{
   
    public DataManager dataManager;
    public Store Weapon;
    public int Money;
    public Options Volume;
   
   



    void Start()
    {
        
        dataManager.Load();
        Money = dataManager.data.Money_Player;
        Weapon.IsAK = dataManager.data.IsAK;
        Weapon.IsRevolver = dataManager.data.IsRevolver;
        Weapon.IsGlock = dataManager.data.IsGlock;
        
    }

    // Update is called once per frame
    void Update()
    {
        dataManager.Save();
        
        dataManager.data.Money_Player = Money;
        dataManager.data.IsAK = Weapon.IsAK;
        dataManager.data.IsRevolver = Weapon.IsRevolver;
        dataManager.data.IsGlock = Weapon.IsGlock;


        /////////////////////////////////////////////////
    }
    
      
    }

