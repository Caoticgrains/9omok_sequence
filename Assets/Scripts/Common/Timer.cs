using System;
using UnityEngine;

namespace Common
{
    public class Timer : MonoBehaviour
    {
        // [SerializeField] private Image fillImage;
        // [SerializeField] private Image headCapImage;
        // [SerializeField] private Image tailCapImage;
        // [SerializeField] private TMP_Text timerText;
        // [SerializeField] private float totalTime;
        //
        // private const float TIMER_MAX = 10f;  
        // private const float TIMER_MIN = 0f;
        //
        // private Transform _parent;
        //
        // public delegate void OnTimeOutDelegate();
        // public OnTimeOutDelegate onTimeOut;
        //
        // private float _currentTime
        // {
        //     get;
        //     set; // 읽는 것은 가능하지만, 값을 세팅을 개체 내부에서만 가능 
        // }
        // private bool _isPaused = false;
        //
        // private void Awake()
        // {
        //     StartTimer();
        // }
        //
        // private void Update()
        // {
        //     //if (!parent.gameObject.activeInHierarchy) return;
        //     if (!isPaused)
        //     {
        //         currentTime -= Time.deltaTime;
        //         
        //         if (currentTime < TIMER_MIN)
        //         {
        //             headCapImage.gameObject.SetActive(false);
        //             tailCapImage.gameObject.SetActive(false);
        //             isPaused = true;
        //             onTimeOut?.Invoke();
        //         }
        //         else
        //         {
        //             fillImage.fillAmount = currentTime / TIMER_MAX; 
        //             headCapImage.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, fillImage.fillAmount * 360));
        //             Int64 timeTextTime = Convert.ToInt64(currentTime) ;
        //             timerText.text = timeTextTime.ToString("F0");
        //         }
        //     }
        //     else
        //     {
        //         // 
        //         Debug.Log("Timer cancelled");
        //     }
        //     
        // }
        //
        // public void StartTimer()
        // {
        //     currentTime = TIMER_MAX;
        //     isPaused = false;
        //     fillImage.fillAmount = 1;
        //     headCapImage.gameObject.SetActive(true);
        //     tailCapImage.gameObject.SetActive(true);
        // }
        //
        // public void PauseTimer()
        // {
        //     isPaused = !isPaused;
        //     //isPaused = true;
        // }
        //
        // public void ResetTimer()
        // {
        //     currentTime = TIMER_MAX;
        //     fillImage.fillAmount = 1;
        //     Int64 timeTextTime = Convert.ToInt64(currentTime) ;
        //     timerText.text = timeTextTime.ToString();
        //     headCapImage.gameObject.SetActive(true);
        //     tailCapImage.gameObject.SetActive(true);
        //     isPaused = true;
        // }
    }
}