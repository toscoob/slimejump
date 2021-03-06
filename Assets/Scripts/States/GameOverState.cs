﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameOverState : AState
{
    public GameObject uiObj;

    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = GlobalsManager.GetScore();
    }

    public override void Enter(AState from)
    {
        Assert.IsNotNull(uiObj, "uiObj not found!");
        uiObj.SetActive(true);

        Text scoreValText = uiObj.transform.Find("GOScoreVal").gameObject.GetComponent<Text>();
        Text hiScoreValText = uiObj.transform.Find("GOHiScoreVal").gameObject.GetComponent<Text>();

        scoreValText.text = score.GetScore().ToString();
        hiScoreValText.text = score.GetHiScore().ToString();
    }

    public override void Exit(AState to)
    {
        uiObj.SetActive(false);
    }

    // Update is called once per frame
    public override void Tick()
    {
        
    }

    public override string GetName()
    {
        return "GameOver";
    }

    public void ClickRetry()
    {
        manager.PopState();
    }

    public void ClickReturn()
    {
        manager.PopState();
        manager.SwitchState("Menu");
    }
}
