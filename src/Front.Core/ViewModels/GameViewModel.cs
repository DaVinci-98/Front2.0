using System;
using System.Collections.Generic;
using System.Text;
using Front.Core.Models;

namespace Front.Core.ViewModels
{
    class GameViewModel : BaseViewModel<GameModel>
    {
        #region init

        private GameModel _game;

        public override void Prepare(GameModel game)
        {
            _game = game;
        }

        #endregion
    }
}
