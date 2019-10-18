namespace Assets.Scripts.Game.MVC
{
    class GameController
    {
        private GameModel _gameModel;

        public void MakeStep(int chosenIndex)
        {
            _gameModel.Step(chosenIndex);
            _gameModel.SetCanStep(false);
        }

        public void MoveCurrentStateCells(int from, int to)
        {
            _gameModel.MoveCurrentStateCells(from, to);
            _gameModel.SetCanStep(true);
        }

        public void WasWrongStep()
        {
            _gameModel.SetCanStep(true);
        }

        public void SetModel(GameModel gameModel)
        {
            _gameModel = gameModel;
        } 
    }
}
