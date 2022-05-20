using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game
{
    public class BonusStageManager : MonoBehaviour
    {
        [SerializeField] private GameObject boss;
        public GameObject fakeloadScreen;
        public Image background;
        public AudioSource music, ambience;
        private void Start()
        {
            fakeloadScreen.SetActive(true);
            GameEvents.instance.onBossFightStart += BossFightStart;
            
            background = fakeloadScreen.GetComponent<Image>();
            GameManager.instance.UpdateGameState(GameState.Loading);
            StartCoroutine(FakeCountdown());
        }

        private void BossFightStart()
        {
            boss.SetActive(true);
        }

        IEnumerator Countdown()
        {
            int count = 4;
            while (count > 0)
            {
                yield return new WaitForSeconds(1f);
                count--;
                GameEvents.instance.CountDown();
            }

            GameManager.instance.UpdateGameState(GameState.Playing);
        }
        
        IEnumerator FakeCountdown()
        {
            int count = Random.Range(2, 4);
            while (count > 0)
            {
                yield return new WaitForSeconds(1f);
                count--;
            }
            
            DOTween.To(FadeLoad, 1, 0, 0.4f);
            music.Play();
            ambience.Play();
            DOTweenModuleAudio.DOFade(music, 0.5f, 1);
            DOTweenModuleAudio.DOFade(ambience, 0.5f, 1);
            GameManager.instance.UpdateGameState(GameState.Intro);
            StartCoroutine(Countdown());
        }

        void FadeLoad(float opacity)
        {
            background.color = new Color(0, 0, 0, opacity);
            //Debug.Log(opacity);
            if (opacity == 0)
            {
                fakeloadScreen.SetActive(false);
            }
        }

    }
}
