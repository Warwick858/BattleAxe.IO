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
using BattleAxe.IO.FileSystem.Csv;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleAxe.IO.FileSystem.Tests.Csv
{
	[TestFixture]
	public class CsvWriterTests
	{
		private readonly string _dataPathBase = @"D:\Documents\Code\C#\Core\BattleAxe.IO\Data\";

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestCase("write.csv")]
		public void All2D_Test(string path)
		{
			List<List<string>> data = new List<List<string>>()
			{
				new List<string>(){ "1", "2", "3", "4", "5" },
				new List<string>(){ "6", "7", "8", "9", "10" },
				new List<string>(){ "11", "12", "13", "14", "15" },
				new List<string>(){ "16", "17", "18", "19", "20" },
			};

			var result = CsvWriter.All(_dataPathBase + path, data);
			Assert.IsTrue(result);
		} // end method

		[Test]
		[TestCase("write.csv")]
		public void All1D_Test(string path)
		{
			List<string> data = new List<string>()
			{
				"12345",
				"678910",
				"1112131415",
				"1617181920"
			};

			var result = CsvWriter.All(_dataPathBase + path, data);
			Assert.IsTrue(result);
		} // end method
	} // end class
} // end namespace
