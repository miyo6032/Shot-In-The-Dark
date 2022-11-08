﻿using System;
using Game_Service.Services;
using TMPro;
using UnityEngine;

namespace Timer
{
    public class CountdownTimer : MonoBehaviour, IGameTimer
    {
        [SerializeField] private TextMeshProUGUI text;
        private float passedTime;
        private float secondsTillTime;
        private Action actionWhenTime;
        private Func<float, string> getMessage;
        private bool actionPassed;

        public void SetTimer(float time, Action action, Func<float, string> message)
        {
            actionPassed = false;
            passedTime = 0;
            secondsTillTime = time;
            actionWhenTime = action;
            getMessage = message;
        }

        public void Update()
        {
            passedTime += Time.deltaTime;
            float remainingTime = Mathf.Max(0, secondsTillTime - passedTime);
            text.text = getMessage(remainingTime);
            if (remainingTime == 0 && !actionPassed)
            {
                actionWhenTime();
                actionPassed = true;
            }
        }
    }
}