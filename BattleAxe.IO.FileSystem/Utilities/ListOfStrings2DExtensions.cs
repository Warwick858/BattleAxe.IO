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
using System.Text;

namespace BattleAxe.IO.FileSystem.Utilities
{
	public static class ListOfStrings2DExtensions
	{
		/// <summary>
		/// Converts a 2D List of strings to a 1D list of strings.
		/// Concatenates each row into comma separated strings.
		/// </summary>
		/// <returns></returns>
		public static List<string> To1DByRow(this List<List<string>> list2D)
		{
			List<string> temp = new List<string>();
			StringBuilder sb = new StringBuilder();

			foreach (var s in list2D)
			{
				foreach (var n in s)
				{
					sb.Append(n + " ");
				}

				temp.Add(sb.ToString());
				sb.Clear();
			} // end foreach

			return temp;
		} // end method

		/// <summary>
		/// Converts a 2D List of strings to one comma separated string.
		/// Appends row-to-row.
		/// </summary>
		/// <returns>The given list as a comma separated string, sliced by row</returns>
		public static string ToStringByRow(this List<List<string>> list2D)
		{
			List<string> temp = new List<string>();
			StringBuilder sb = new StringBuilder();

			temp = list2D.To1DByRow();

			foreach (var s in temp)
			{
				sb.Append(s);
			} // end foreach

			return sb.ToString();
		} // end method
	} // end class
} // end namespace
