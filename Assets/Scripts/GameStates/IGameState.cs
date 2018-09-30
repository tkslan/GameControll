namespace Game.GameStates
{
    interface IGameState
    {
        void SetGameState(State gameState);
        void OnGameStateUpdate();
        void OnGameStateNewGame();
        void OnGameStateMenu();
        void OnGameStatePause();
        void OnGameStateGameOver();
        void OnGameStateError();
    }
}
