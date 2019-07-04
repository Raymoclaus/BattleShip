using System;

namespace BattleShip
{
	public static class UserInput
	{

		/// <summary>
		/// Queries the user for an integer value repeatedly until a valid answer is given.
		/// </summary>
		/// <param name="question">The question to be asked of the user.</param>
		/// <param name="minValue">Inputs lower than the minimum value are ignored.</param>
		/// <param name="maxValue">Inputs higher than the maximum value are ignored.</param>
		/// <returns>Returns a value between the given minimum and maximum limits of the user's choosing.</returns>
		public static int GetInt(string question, int minValue, int maxValue)
		{
			bool validInput = false;
			int value = -1;

			do
			{
				Console.Write($"{question} ({minValue} - {maxValue}) ");
				//read user input
				string input = Console.ReadLine();
				//Catch exceptions if user enters something unexpected.
				try
				{
					value = int.Parse(input);
					validInput = GameBoard.IsValidColumn(value);
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
					Console.WriteLine($"Please enter a number between {minValue} - {maxValue}...");
				}
			} while (!validInput);

			return value;
		}

		/// <summary>
		/// Queries the user for a single character input.
		/// </summary>
		/// <param name="question">The question to be asked of the user.</param>
		/// <param name="trueResponse">Used to check if the user has entered a "true" response to the question.</param>
		/// <returns>True if the first character of the user input matches the "true response".
		/// All following characters are ignored. Returns false if the first character does not match the "true response".</returns>
		public static bool GetBoolean(string question, char trueResponse)
		{
			Console.Write(question);
			try
			{
				return Console.ReadLine().ToUpper()[0] == trueResponse;
			}
			catch (IndexOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Please enter at least 1 character of input.");
			}
			return GetBoolean(question, trueResponse);
		}
	}
}
