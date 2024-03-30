using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using DG.Tweening;


namespace GM
{
    public class GameUIHandler : Handler
    {
        GameUIController uiController { get { return GameUIController.Instance; } }

        public GameObject sniperscope;
        [SerializeField] TextMeshProUGUI timetext;
        [SerializeField] TextMeshProUGUI scoretext;
        [SerializeField] GameObject ActivateObject;
        [SerializeField] TextMeshProUGUI hitscore;


        private void Start()
        {

        }

        public override void Init()
        {
            base.Init();
            
        }
        public void InitValues()
        {
            timetext.text = "00";
            scoretext.text = "000";
            ActivateObject.SetActive(false);
        }

        public override void DeInit()
        {
            base.DeInit();
        }

        public void CrossHair(bool enable)
        {
            sniperscope.SetActive(enable);
        }

        public void EnableSniperScope(bool val)
        {
            sniperscope.SetActive(val);
        }
        public void ActivatePausehandler()
        {
            uiController.ActivatePauseHandler();
            GameManager.Instance.PauseGame();

        }
        public void SetTime(float Time)
        {
            timetext.text = Time.ToString("00.00");
        }
        public void SetScore(float score,float currentscore)
        {
            scoretext.text = score.ToString("000");
            scoretext.transform.DOScale(1.2f, 0.3f).OnComplete(() =>
            scoretext.transform.DOScale(1.0f, 0.3f)
            );
            SetHitScore(currentscore);
            hitscore.transform.DOScale(1.2f, 0.3f).OnComplete(() =>
            hitscore.transform.DOScale(1.0f, 0.3f)
            );
        }
        public void SetHitScore(float score)
        {
            ActivateObject.SetActive(true);
            hitscore.text = $"+{score}";
            StartCoroutine(StopScore());
        }
        IEnumerator StopScore()
        {
            yield return new WaitForSecondsRealtime(2);
            ActivateObject.SetActive(false);
        }

    }
}
