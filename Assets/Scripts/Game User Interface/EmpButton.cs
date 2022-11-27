using System;
using Game_Service;
using Game_Service.Services;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Game_User_Interface
{
    public class EmpButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private PlayerEmpAction playerEmpAction;

        private void Start()
        {
            button.onClick.AddListener(DoEmp);
        }

        private void DoEmp()
        {
            playerEmpAction.DoEmp(GameServiceProvider.GetService<IGameState>());
        }
    }
}