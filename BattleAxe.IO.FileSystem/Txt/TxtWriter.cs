// ******************************************************************************************************************
//  This file is part of BattleAxe.IO.
//
//  BattleAxe.IO - collection of input/output methods for performing filesystem IO via the following formats: .txt, .csv.
//  Copyright(C)  2020  James LoForti
//  Contact Info: jamesloforti@gmail.com
//
//  BattleAxe.IO is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
//									     ____.           .____             _____  _______   
//									    |    |           |    |    ____   /  |  | \   _  \  
//									    |    |   ______  |    |   /  _ \ /   |  |_/  /_\  \ 
//									/\__|    |  /_____/  |    |__(  <_> )    ^   /\  \_/   \
//									\________|           |_______ \____/\____   |  \_____  /
//									                             \/          |__|        \/ 
//
// ******************************************************************************************************************
//
using BattleAxe.IO.FileSystem.Txt.OutputDecorator;
using BattleAxe.IO.FileSystem.Txt.OutputDecorator.Decorations;
using System.Collections.Generic;
using System.IO;

namespace BattleAxe.IO.FileSystem.Txt
{
	public static class TxtWriter
	{
		/// <summary>
		/// Writes the given string to the given file path.
		/// </summary>
		/// <returns>bool, true = success & false = failure</returns>
		public static bool AllAsString(string path, string content)
		{
			if (Directory.GetParent(path).Exists)
				File.WriteAllText(path, content); // overwrites existing
			else
				return false;

			return true;
		} // end method

		/// <summary>
		/// Writes the given string to the given file path.
		/// </summary>
		/// <returns>bool, true = success & false = failure</returns>
		public static bool AllAsList(string path, List<string> content)
		{
			if (Directory.GetParent(path).Exists)
				File.WriteAllLines(path, content); // overwrites existing file
			else
				return false;

			return true;
		} // end method

		/// <summary>
		/// Writes the given list of strings to the given file path,
		/// and appends a newline to each string.
		/// </summary>
		/// <returns>bool, true = success & false = failure</returns>
		public static bool LineByLine(string path, List<string> content)
		{
			IOutput outputStream;
			string? line = string.Empty;
			List<string> data = new List<string>();

			try
			{
				using StreamWriter sw = new StreamWriter(path);
				outputStream = new Output(sw);
				outputStream = new NewlineOutput(outputStream);

				if (Directory.GetParent(path).Exists)
					foreach (var s in content)
						outputStream.Write(s);
				else
					return false;
			} // end try
			catch
			{
				return false;
			}

			return true;
		} // end method

		/// <summary>
		/// Writes the given list of strings to the given file path. 
		/// Using the given baseIndex, each line is prepended with the next incremental number.
		/// </summary>
		/// <returns>bool, true = success & false = failure</returns>
		public static bool LineByLine(string path, List<string> content, int baseIndex = 1)
		{
			IOutput outputStream;
			string? line = string.Empty;
			List<string> data = new List<string>();

			try
			{
				using StreamWriter sw = new StreamWriter(path);
				outputStream = new Output(sw);
				outputStream = new NumberedOutput(outputStream, baseIndex);

				if (Directory.GetParent(path).Exists)
					foreach (var s in content)
						outputStream.Write(s);
				else
					return false;
			} // end try
			catch
			{
				return false;
			}

			return true;
		} // end method

		/// <summary>
		/// Writes the given list of strings to the two given file paths.
		/// </summary>
		/// <returns>bool, true = success & false = failure</returns>
		public static bool LineByLine(string pathA, string pathB, List<string> content)
		{
			IOutput outputStream;
			string? line = string.Empty;
			List<string> data = new List<string>();

			try
			{
				using StreamWriter sw = new StreamWriter(pathA);
				using StreamWriter branchedStream = new StreamWriter(pathB);
				outputStream = new Output(sw);
				outputStream = new SplitterOutput(outputStream, branchedStream);

				if (Directory.GetParent(pathA).Exists && Directory.GetParent(pathB).Exists)
					foreach (var s in content)
						outputStream.Write(s);
				else
					return false;
			} // end try
			catch
			{
				return false;
			}

			return true;
		} // end method

		/// <summary>
		/// Writes those strings from the given list, which contain the given targetValue, to the given file path.
		/// </summary>
		/// <returns>bool, true = success & false = failure</returns>
		public static bool LineByLine(string path, List<string> content, string targetValue)
		{
			IOutput outputStream;
			string? line = string.Empty;
			List<string> data = new List<string>();

			try
			{
				using StreamWriter sw = new StreamWriter(path);
				outputStream = new Output(sw);
				outputStream = new FilterOutput(outputStream, targetValue);

				if (Directory.GetParent(path).Exists)
					foreach (var s in content)
						outputStream.Write(s);
				else
					return false;
			} // end try
			catch
			{
				return false;
			}

			return true;
		} // end method
	} // end class
} // end namespace
