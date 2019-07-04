using System;

namespace BattleShip
{
	public class Player
	{
		private GameBoard board = new GameBoard();
		private Player opponent;
		private string playerName = "defaultName";

		public Player()
		{
			Console.WriteLine("Adding new player to the game.");
			GetName();
			PlaceShips();
		}

		private void GetName()
		{
			Console.Write("What is this new player's name? ");
			playerName = Console.ReadLine();
		}

		public void SetOpponent(Player opponent) => this.opponent = opponent;

		/// <summary>
		/// Starts a sequence to choose location and orientation of game board pieces.
		/// </summary>
		private void PlaceShips()
		{
			do
			{
				AddShip();
			} while (UserInput.GetBoolean("Would you like to add another ship? (Y / N) ", 'Y'));
		}

		/// <summary>
		/// Queries the player for various details about the ship they wish to add,
		/// then adds it to the player's game board.
		/// </summary>
		private void AddShip()
		{
			Console.WriteLine("Creating new ship...");
			Ship newShip;
			newShip.length = UserInput.GetInt("How many spaces long is the ship?", Ship.MIN_LENGTH, Ship.MAX_LENGTH);
			newShip.xPosition = UserInput.GetInt("Which column should the front of the ship be placed in?", 1, GameBoard.BOARD_SIZE);
			newShip.yPosition = UserInput.GetInt("Which row should the front of the ship be placed in?", 1, GameBoard.BOARD_SIZE);
			newShip.vertical = UserInput.GetBoolean("What orientation would you like to place your ship?\n" +
				"If horizontal is chosen, the ship will extend to the right from your chosen position.\n" +
				"If vertical is chosen, the ship will extend downwards from your chosen position.\n(V for vertical) ", 'V');
			board.AddShip(newShip);
		}

		/// <summary>
		/// Begins the "attacking" phase of the game and repeats until game over
		/// </summary>
		public void StartGame()
		{
			Console.WriteLine($"Game is starting. {playerName} will go first.");
			Attack();
		}

		private void Attack()
		{
			Console.WriteLine($"{playerName}'s Turn.");
			int x = UserInput.GetInt($"{playerName}, Which x-coordinate do you plan to attack?", 1, GameBoard.BOARD_SIZE);
			int y = UserInput.GetInt($"{playerName}, Which y-coordinate do you plan to attack?", 1, GameBoard.BOARD_SIZE);
			opponent.TakeHit(x, y);
		}

		private void TakeHit(int x, int y)
		{
			board.TakeHit(x, y);

			if (board.ShipExistsOnTile(x, y))
			{
				Console.WriteLine("Hit!");
			}
			else
			{
				Console.WriteLine("Miss!");
			}

			if (board.AreAllShipsSunk())
			{
				Console.WriteLine($"Game Over. {opponent.playerName} wins!");
			}
			else
			{
				Attack();
			}
		}
	}
}