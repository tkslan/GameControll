using Game.GameStates;
using UnityEngine;

namespace Game
{
    public class GameControl : GameState
    {
        void Start()
        { 
            SetGameState(State.NewGame);
        }

    }

}