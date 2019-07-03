using System.Collections.Generic;

namespace BattleShip
{
	public class GameBoard
	{
		public const int BOARD_SIZE = 10;

		//keeps track of which cells on the board have been "hit" or not.
		public bool[] hitSpots = new bool[BOARD_SIZE * BOARD_SIZE];

		private List<Ship> shipPieces = new List<Ship>();
	}
}