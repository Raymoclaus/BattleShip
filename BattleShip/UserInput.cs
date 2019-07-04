using System;

namespace BattleShip
{
	/// <summary>
	/// This is a library of functions used to obtain input from the user with certain parameters.
	/// </summary>
	/// <remarks>
	/// This class can take integer and boolean input from the user via the console.
	/// </remarks>
	public static class UserInput
	{
		/// <summary>
		/// Queries the user for an integer value repeatedly until a valid answer is given.
		/// </summary>
		/// <param name="question">
		/// The question to be asked of the user.
		/// </param>
		/// <param name="minValue">
		/// Inputs lower than the minimum value are ignored.
		/// </param>
		/// <param name="maxValue">
		/// Inputs higher than the maximum value are ignored.
		/// </param>
		/// <returns>
		/// Returns a value between the given minimum and maximum limits of the user's choosing.
		/// </returns>
		public static int GetInt(string question, int minValue, int maxValue)
		{
			Console.Write($"{question} ({minValue} - {maxValue}) ");
			string input = Console.ReadLine();
			//get input from user
			try
			{
				int value = int.Parse(input);
				if (GameBoard.IsValidColumn(value)) return value;
			}
			//catch the error if the user does not enter a number
			catch (FormatException e)
			{
				Console.WriteLine(e.Message);
			}
			//catch the error if the user enters a number that is too large or small (for Int32 limitations)
			catch (OverflowException e)
			{
				Console.WriteLine(e.Message);
			}

			Console.WriteLine($"Please enter a number between {minValue} - {maxValue}...");
			//if the input was invalid, ask the question again
			return GetInt(question, minValue, maxValue);
		}

		/// <summary>
		/// Queries the user for a single character input.
		/// </summary>
		/// <param name="question">
		/// The question to be asked of the user.
		/// </param>
		/// <param name="trueResponse">
		/// Used to check if the user has entered a "true" response to the question.
		/// </param>
		/// <returns>
		/// True if the first character of the user input matches the "true response".
		/// All following characters are ignored. Returns false if the first character does not match the "true response".
		/// </returns>
		public static bool GetBoolean(string question, char trueResponse)
		{
			Console.Write(question);
			//get input from user
			try
			{
				return Console.ReadLine().ToUpper()[0] == trueResponse;
			}
			//catch the error if user enters no input
			catch (IndexOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Please enter at least 1 character of input.");
			}
			//if the input was invalid, ask the question again
			return GetBoolean(question, trueResponse);
		}
	}
}
