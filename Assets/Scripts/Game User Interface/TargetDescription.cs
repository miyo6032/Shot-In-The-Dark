using System;
using Game_Service;
using Game_Service.Services;
using TMPro;
using UnityEngine;

namespace Game_User_Interface
{
    public class TargetDescription : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI descriptionText;

        private void Start()
        {
            descriptionText.text = "Wearing " +  FrontEndServiceProvider.GetService<IColorService>().GetTargetColorDescription() + " shirt.";
        }
    }
}