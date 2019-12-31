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
using BattleAxe.IO.FileSystem.Utilities;
using System.Collections.Generic;
using System.IO;

namespace BattleAxe.IO.FileSystem.Csv
{
	public class CsvWriter
	{
		/// <summary>
		/// Writes the given string to the given file path.
		/// </summary>
		/// <returns>bool, true = success & false = failure</returns>
		public static bool All(string path, List<List<string>> data)
		{
			if (Directory.GetParent(path).Exists)
			{
				using var writer = new StreamWriter(path);
				using var csv = new CsvHelper.CsvWriter(writer);
				
				foreach (var l in data)
				{
					foreach (var s in l)
						csv.WriteField(s);

					csv.NextRecord();
				} // end foreach

				return true;
			} // end if

			return false;
		} // end method
	} // end class
} // end namespace
