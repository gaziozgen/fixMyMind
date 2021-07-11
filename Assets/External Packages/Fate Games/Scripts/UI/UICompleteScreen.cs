using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace FateGames
{
    public class UICompleteScreen : UIElement
    {
        [HideInInspector] public bool Success = false;
        [SerializeField] private Text completeText = null;
        [SerializeField] private Text continueText = null;
        [SerializeField] private Color successColor;
        [SerializeField] private Color failColor;
        [SerializeField] private Sprite successEmoji;
        [SerializeField] private Sprite failEmoji;
        [SerializeField] private Image stripeImage;
        [SerializeField] private Image butonColor;
        [SerializeField] private Image emoji;
        [SerializeField] private GameObject sparkle;

        public void SetScreen(bool success, int level)
        {
            completeText.text = GameManager.Instance.LevelName + " " + level + (success ? " COMPLETED" : " FAILED");
            continueText.text = success ? "CONTINUE" : "TRY AGAIN";
            stripeImage.color = success ? successColor : failColor;
            emoji.sprite = success ? successEmoji : failEmoji;
            butonColor.color = success ? successColor : failColor;

            if (success)
            {
                sparkle.SetActive(true);
            }

        }

        protected override void Animate()
        {
            return;
        }

        // Called by ContinueButton onClick
        public void Continue()
        {
            GameManager.Instance.LoadCurrentLevel();
        }
    }
}