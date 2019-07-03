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
				Console.Write("Would you like to add another ship? (Y / N) ");
			} while (Console.ReadLine().ToUpper() == "Y");
		}

		/// <summary>
		/// Queries the player for various details about the ship they wish to add,
		/// then adds it to the player's game board.
		/// </summary>
		private void AddShip()
		{
			Console.WriteLine("Creating new ship...");
			bool validInput = false;

			//get the length of the ship
			do
			{
				Console.Write($"How many spaces long is the ship? ({Ship.MIN_LENGTH} - {Ship.MAX_LENGTH}) ");
				//read user input
				string lengthInput = Console.ReadLine();
				//Catch exceptions if user enters something unexpected.
				try
				{
					int length = int.Parse(lengthInput);
					validInput = Ship.IsValidLength(length);
				}
				catch (FormatException e)
				{
					Console.WriteLine(e.Message);
					validInput = false;
				}
				catch (OverflowException e)
				{
					Console.WriteLine(e.Message);
					validInput = false;
				}

				if (!validInput)
				{
					Console.WriteLine($"Please enter a number between {Ship.MIN_LENGTH} - {Ship.MAX_LENGTH}...");
				}
			} while (!validInput);
		}

		/// <summary>
		/// Begins the "attacking" phase of the game and repeats until game over
		/// </summary>
		public void StartGame()
		{
			Console.WriteLine("Game is starting.");
		}
	}
}