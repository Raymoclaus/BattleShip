using System.Collections.Generic;

namespace BattleShip
{
	public class GameBoard
	{
		public const int BOARD_SIZE = 10;

		//keeps track of which cells on the board have been "hit" or not.
		public bool[] hitSpots = new bool[BOARD_SIZE * BOARD_SIZE];

		//keeps track of which tiles are occupied by a ship
		private List<int> shipTiles = new List<int>();

		public static bool IsValidColumn(int column) => column >= 1 && column <= BOARD_SIZE;

		public static bool IsValidRow(int row) => row >= 1 && row <= BOARD_SIZE;

		/// <summary>
		/// Appends to the list of coordinates that ship pieces occupy.
		/// If a ship doesn't fit on the board, the length is cut short,
		/// but still placed on the board in the same position and orientation.
		/// </summary>
		/// <param name="newShip"></param>
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

		/// <summary>
		/// Updates the array to indicate the new location has been hit.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void TakeHit(int x, int y)
		{
			int index = (y - 1) * BOARD_SIZE + (x - 1);
			hitSpots[index] = true;
		}

		/// <summary>
		/// Checks if all tiles occupied by all ships have been hit.
		/// </summary>
		/// <returns></returns>
		public bool AreAllShipsSunk()
		{
			for (int i = 0; i < shipTiles.Count; i++)
			{
				if (!hitSpots[shipTiles[i]]) return false;
			}
			return true;
		}

		/// <summary>
		/// Checks if a specific coordinate is occupied by a ship piece.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
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