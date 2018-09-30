using Game.GameStates;
using UnityEngine;
namespace Game
{
    public class UiControl : GameState
    {
        public void SetGameStateUI(int state)
        {
            SetGameState((State)state);
        }
    }
}