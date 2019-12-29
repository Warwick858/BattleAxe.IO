// ******************************************************************************************************************
//  This file is part of BattleAxe.IO.
//
//  BattleAxe.IO - collection of input/output methods for performing filesystem IO via the following formats: .txt, .csv.
//  Copyright(C)  2020  James LoForti
//  Contact Info: jamesloforti@gmail.com
//
//  BattleAxe.IO is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
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
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace BattleAxe.IO.FileSystem.Tests
{
	public class CreateTestData
	{
		/// <summary>
		/// To create a file at the given location which randomly contains the defined characters.
		/// </summary>
		/// <param name="path">Location of newly created test data file</param>
		[Test]
		[TestCase(@"D:\Documents\Code\C#\Core\IO_Core3.0_Example\Data\data.txt")]
		public void GenerateTestData(string path)
		{
			Random random = new Random();
			string charOptions = "AGCT\n";
			int numOfLines = 10000;

			var data = new string(Enumerable.Repeat(charOptions, numOfLines).Select(s => s[random.Next(s.Length)]).ToArray());
			File.WriteAllText(path, data);
		} // end method
	} // end class
} // end namespace
