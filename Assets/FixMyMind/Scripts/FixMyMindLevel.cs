using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FateGames;

public class FixMyMindLevel : LevelManager
{
    private DialogContoller dialogContoller;
    [SerializeField] private GameObject slider;

    private new void Awake()
    {
        base.Awake();
        dialogContoller = FindObjectOfType<DialogContoller>();
    }

    public override void FinishLevel(bool success)
    {
        GameManager.Instance.FinishLevel(success);
        print("level ended");
    }

    public override void StartLevel()
    {
        //print("level started");
        dialogContoller.UpdateUI();
        slider.SetActive(true);
    }
}
