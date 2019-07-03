using System;

namespace BattleShip
{
	class Program
	{
		static void Main(string[] args)
		{
			//create a player and opponent to play against each other
			Player player = new Player();
			Player opponent = new Player();
			player.SetOpponent(opponent);
			opponent.SetOpponent(player);

			//player starts the game first
			player.StartGame();

			Console.ReadLine();
		}
	}
}
