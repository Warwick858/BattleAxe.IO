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
using System.Collections.Generic;
using System.IO;

namespace BattleAxe.IO.FileSystem.Csv
{
	public static class CsvReader
	{
		/// <summary>
		/// Reads the csv file at the given path.
		/// </summary>
		/// <returns>string, success = the contents of the file & failuire = string.Empty</returns>
		public static string AllAsString(string path)
		{
			if (File.Exists(path))
				ReadData(path);

			return string.Empty;
		} // end method

		/// <summary>
		/// Reads the csv file at the given path.
		/// </summary>
		/// <returns>list of a list of strings, success = the contents of the file & failuire = an empty list</returns>
		public static List<List<string>> AllAsList(string path)
		{
			if (File.Exists(path))
				return ReadData(path);

			return new List<List<string>>();
		} // end method

		public static List<List<string>> ReadData(string file)
		{
			List<List<string>> data = new List<List<string>>();
			List<string> tempData = new List<string>();

			using var reader = new StreamReader(file);
			using var csv = new CsvHelper.CsvReader(reader);

			while (csv.Read())
			{
				tempData = new List<string>();

				foreach (var c in csv.Context.Record)
					tempData.Add(c);

				data.Add(tempData);
			} // end while

			return data;
		} // end method
	} // end class
} // end namespace
