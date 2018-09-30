using System;
using Game.GameStates;
using UnityEngine;

namespace Game
{
    public class SoundControl : GameState
    {

        public override void OnGameStateGameOver()
        {
            Debug.Log("GAME OVER");
            UnsubscribeState(StateUpdate);
        }
    }
}