﻿using UnityEngine;
using System.Collections;

public class MakeMoney : MonoBehaviour {
    GameObject[] man;
    PlayerMoney money;
    int getmoney=0;
    public int getmoneylimit = 100;
    int starttime;
    NowLevel userId;
    // Use this for initialization
    void Start () {
        
        money = GameObject.Find("Main Camera").GetComponent<PlayerMoney>();
       /* var sceneManager=GameObject.Find("SceneManager2");
        if (null == sceneManager)
        {
            starttime = 1;
        }
        else
        {
            starttime = GameObject.Find("SceneManager2").GetComponent<SceneManager2>().brokenRate*60;
        }*/
        if (this.name == "Baker_house (Clone)")
        {
            InvokeRepeating("StartMakeMoney", 1f, 0f);
        }
    }
    void OnMouseDown()
    {
        if (money.money + getmoney < 100000)
        {
            money.money += getmoney;
            getmoney = 0;
        }
        else if (money.money + getmoney > 100000)
        {
            getmoney = 0;
            money.money = 99999;
        }

    }
    void StartMakeMoney()
    {
        InvokeRepeating("earnMoney", 1f, 1f);
    }
    void earnMoney()
    {
        man = GameObject.FindGameObjectsWithTag("Man");
        getmoney += man.Length;
        if (getmoney >= getmoneylimit)
        {
            getmoney = getmoneylimit;
        }
    }
}
