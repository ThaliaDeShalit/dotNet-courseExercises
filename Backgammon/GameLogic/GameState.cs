using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class GameState
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Player m_CurrentPlayer; 
      //  private bool m_GameAgainstComputer; 
        private eBoardLocation[,] m_GameBoard;
        //private sMatrixCoordinate? m_LastMove; 
        private string m_NameOfPlayerThatPlayedLastMove;
    }
}
