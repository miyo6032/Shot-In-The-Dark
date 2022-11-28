using System;
using AK.Wwise;
using Game_Service.Services;
using TMPro;
using UnityEngine;
using Event = AK.Wwise.Event;

namespace Timer
{
    public class CountdownTimer : MonoBehaviour, IGameTimer
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Event lowTimeSoundEvent;
        [SerializeField] private Switch timerSwitch;
        private float passedTime;
        private float secondsTillTime;
        private Action actionWhenTime;
        private Func<float, string> getMessage;
        private bool actionPassed;
        private bool timerStopped;

        public void SetTimer(float time, Action action, Func<float, string> message)
        {
            actionPassed = false;
            passedTime = 0;
            secondsTillTime = time;
            actionWhenTime = action;
            getMessage = message;
            timerStopped = false;
        }

        public void StopTimer()
        {
            timerStopped = true;
        }

        public void Update()
        {
            if (timerStopped) return;
            
            if ((int)passedTime != (int)(passedTime + Time.deltaTime))
            {
                lowTimeSoundEvent.Post(gameObject);
            }
            
            passedTime += Time.deltaTime;
            float remainingTime = Mathf.Max(0, secondsTillTime - passedTime);
            
            if (remainingTime < 6)
            {
                timerSwitch.SetValue(gameObject);
            }
            
            text.text = getMessage(remainingTime);
            if (remainingTime == 0 && !actionPassed)
            {
                actionWhenTime();
                actionPassed = true;
            }
        }
    }
}
