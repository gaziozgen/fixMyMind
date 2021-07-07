using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FateGames;

public class DialogContoller : MonoBehaviour
{
    private FixMyMindLevel levelManager;

    [SerializeField] private Dialog dialog;
    [SerializeField] private Text otherSide;
    [SerializeField] private Text button1;
    [SerializeField] private Text button2;
    [SerializeField] private Slider slider;
    [SerializeField] private Animator char1;
    [SerializeField] private Image emoji;
    [SerializeField] private Sprite[] emojis;


    private int indexNo = 0;
    private float happines;

    void Awake()
    {
        levelManager = (FixMyMindLevel)LevelManager.Instance;
        UpdateUI();
    }

    public void Button1()
    {
        indexNo = (indexNo * 2) + 1;
        UpdateUI();
    }

    public void Button2()
    {
        indexNo = (indexNo * 2) + 2;
        UpdateUI();
    }

    private void UpdateUI()
    {
        float newHappines = dialog.happinesPoints[indexNo];

        HappinesUpdate(newHappines);

        if (indexNo != 0)
        {
            Animate(newHappines);
        }

        otherSide.text = dialog.otherSide[indexNo];

        bool finish = false;
        for (int i = 0; i < dialog.finishIndexes.Length; i++)
        {
            if (dialog.finishIndexes[i] == indexNo)
            {
                finish = true;
                Finish();
            }
        }

        if (!finish)
        {
            button1.text = dialog.us[(indexNo * 2) + 1];
            button2.text = dialog.us[(indexNo * 2) + 2];
        }
    }

    private void HappinesUpdate(float newHappines)
    {

        LeanTween.value(transform.gameObject, (h) => { slider.value = h / 100; }, happines, happines + newHappines, Mathf.Abs(newHappines) * 0.02f);

        happines += newHappines;

        if (happines >= 80)
        {
            emoji.sprite = emojis[4];
        }
        else if (happines >= 60)
        {
            emoji.sprite = emojis[3];
        }
        else if (happines >= 40)
        {
            emoji.sprite = emojis[2];
        }
        else if (happines >= 20)
        {
            emoji.sprite = emojis[1];
        }
        else
        {
            emoji.sprite = emojis[0];
        }

        // bitiþ zamanlamasý ve emoji deðiþimi
    }

    private void Animate(float happines)
    {
        if (char1)
        {
            if (happines > 20)
            {
                char1.SetTrigger("Clap");
            }
            else if (happines > 0)
            {
                char1.SetTrigger("Cheer");
            }
            else if (happines < 0)
            {
                char1.SetTrigger("Sad");
            }
        }
        else
        {
            print("character 1 empty");
        }

    }

    private void Finish()
    {


        button1.transform.parent.gameObject.SetActive(false);
        button2.transform.parent.gameObject.SetActive(false);

        bool result = false;
        
        if (happines >= 60)
        {
            result = true;
        }

        levelManager.FinishLevel(result);
    }
}
