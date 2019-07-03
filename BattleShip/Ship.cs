using System;

namespace BattleShip
{
	public struct Ship
	{
		public const int MIN_LENGTH = 1, MAX_LENGTH = GameBoard.BOARD_SIZE;

		public int length;
		public bool vertical;
		public int xPosition, yPosition;

		public Ship(int length, bool vertical, int xPosition, int yPosition)
		{
			this.length = length;
			this.vertical = vertical;
			this.xPosition = xPosition;
			this.yPosition = yPosition;
		}

		public static bool IsValidLength(int length) => length >= MIN_LENGTH && length <= MAX_LENGTH;
	}
}