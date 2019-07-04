using System.Collections.Generic;

namespace BattleShip
{
	public class GameBoard
	{
		public const int BOARD_SIZE = 10;

		//keeps track of which cells on the board have been "hit" or not.
		public bool[] hitSpots = new bool[BOARD_SIZE * BOARD_SIZE];

		private List<int> shipTiles = new List<int>();

		public static bool IsValidColumn(int column) => column >= 1 && column <= BOARD_SIZE;

		public static bool IsValidRow(int row) => row >= 1 && row <= BOARD_SIZE;

		public void AddShip(Ship newShip)
		{
			for (int i = 0; i < newShip.length; i++)
			{
				int x = newShip.xPosition;
				int y = newShip.yPosition;

				if (newShip.vertical)
				{
					y += i;
				}
				else
				{
					x += i;
				}

				if (!IsValidColumn(x) || !IsValidRow(y)) return;

				int index = (y - 1) * BOARD_SIZE + (x - 1);
				shipTiles.Add(index);
			}
		}

		public void TakeHit(int x, int y)
		{
			int index = (y - 1) * BOARD_SIZE + (x - 1);
			hitSpots[index] = true;
		}

		public bool AreAllShipsSunk()
		{
			for (int i = 0; i < shipTiles.Count; i++)
			{
				if (!hitSpots[shipTiles[i]]) return false;
			}
			return true;
		}

		public bool ShipExistsOnTile(int x, int y)
		{
			int index = (y - 1) * BOARD_SIZE + (x - 1);
			for (int i = 0; i < shipTiles.Count; i++)
			{
				if (shipTiles[i] == index) return true;
			}
			return false;
		}
	}
}