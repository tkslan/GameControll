using Game.GameStates;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameState : MonoBehaviour, IGameState
    {
        public delegate void StateDelegate(State gameState, EndGameReason reason, int execOrder = -1);

        private static List<StateDelegate> StateDelegatesList;
        private static State currentState;

        void Awake()
        {
            SubscribeState(StateUpdate);
        }

        public void SubscribeState(StateDelegate stateDelegate)
        {
            if (StateDelegatesList == null)
                StateDelegatesList = new List<StateDelegate>();

            if (!StateDelegatesList.Contains(stateDelegate))
                StateDelegatesList.Add(stateDelegate);
            else
                Debug.Log("Already subscribed: " + stateDelegate.ToString());
        }

        public void UnsubscribeState(StateDelegate stateDelegate)
        {
            if (StateDelegatesList == null)
                Debug.Log("Nothing subscribed yet, subscribe first!");

            if (StateDelegatesList.Contains(stateDelegate))
                StateDelegatesList.Remove(stateDelegate);
            else
                Debug.Log("Already removed: " + stateDelegate.ToString());
        }

        public virtual void SetGameState(State gameState)
        {
            currentState = gameState;
            OnGameStateUpdate();
        }

        protected virtual void StateUpdate(State gameState, EndGameReason reason, int execOrder)
        {
            RaiseEvent(currentState);
            PrintState(execOrder);
        }

        private void RaiseEvent(State state)
        {
            switch (currentState)
            {
                case State.None: break;
                case State.GameOver: OnGameStateGameOver(); break;
                case State.Menu: OnGameStateMenu(); break;
                case State.NewGame: OnGameStateNewGame(); break;
                case State.Pause: OnGameStatePause(); break;
                case State.Error: OnGameStateError(); break;
            }
        }

        public void OnGameStateUpdate()
        {
            for (int i = 0; i < StateDelegatesList.Count; i++)
            {
                StateDelegatesList[i](currentState, EndGameReason.Victory, i);
            }
        }

        protected void PrintState(int execOrder = -1)
        {

            Debug.Log($"Order: {execOrder} - {this.ToString()} : {currentState.ToString()}");
        }

        public virtual void OnGameStateNewGame() { }

        public virtual void OnGameStateMenu() { }

        public virtual void OnGameStatePause() { }

        public virtual void OnGameStateGameOver() { }

        public virtual void OnGameStateError() { }
    }
}
