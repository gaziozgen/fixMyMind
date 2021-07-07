using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FateGames;

public class FixMyMindLevel : LevelManager
{
    private new void Awake()
    {
        base.Awake();
    }

    public override void FinishLevel(bool success)
    {
        GameManager.Instance.FinishLevel(success);
        print("level ended");
    }

    public override void StartLevel()
    {
        //print("level started");
    }
}
