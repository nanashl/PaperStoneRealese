using System.Collections;
using System.Collections.Generic;
using Commands;
using Managers;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class GameRewardCloseInput : MonoBehaviour
    {
        public GameCmdFactory gameCmdFactory;
        
        public void OnClick()
        {
            Managers.GameManagerRoulet.Instance.LoadScene("Game");
            Managers.GameManagerRoulet.Instance.ToggleGame();
        }
    }
}
