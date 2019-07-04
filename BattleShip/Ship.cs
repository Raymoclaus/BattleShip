namespace BattleShip
{
	/// <summary>
	/// Stores data about a ship piece; length, orientation and position.
	/// </summary>
	public struct Ship
	{
		public const int MIN_LENGTH = 1, MAX_LENGTH = GameBoard.BOARD_SIZE;

		public int length;
		public bool vertical;
		public int xPosition, yPosition;

		public static bool IsValidLength(int length) => length >= MIN_LENGTH && length <= MAX_LENGTH;
	}
}