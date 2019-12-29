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
using BattleAxe.IO.FileSystem.Txt;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleAxe.IO.FileSystem.Tests.Txt
{
	[TestFixture]
	public class TxtWriterTests
	{
		private readonly string _dataPathBase = @"D:\Documents\Code\C#\Core\BattleAxe.IO\Data\";

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestCase("write.txt")]
		public void AllAsString_Test(string path)
		{
			var content = "testing123";

			var result = TxtWriter.AllAsString(_dataPathBase + path, content);
			Assert.IsTrue(result);
		} // end method

		[Test]
		[TestCase("write.txt")]
		public void AllAsList_Test(string path)
		{
			List<string> content = new List<string>()
			{
				"1",
				"2",
				"3",
				"4",
				"5"
			};

			var result = TxtWriter.AllAsList(_dataPathBase + path, content);
			Assert.IsTrue(result);
		} // end method

		/// <summary>
		/// NEWLINE
		/// </summary>
		[Test]
		[TestCase("write.txt")]
		public void LineByLine_Newline_Test(string path)
		{
			List<string> content = new List<string>()
			{
				"1",
				"2",
				"3",
				"4",
				"5"
			};

			var result = TxtWriter.LineByLine(_dataPathBase + path, content);
			Assert.IsTrue(result);
		} // end method

		/// <summary>
		/// NUMBERED
		/// </summary>
		[Test]
		[TestCase("write.txt", 1)]
		public void LineByLine_Numbered_Test(string path, int baseIndex)
		{
			List<string> content = new List<string>()
			{
				"1",
				"2",
				"3",
				"4",
				"5"
			};

			var result = TxtWriter.LineByLine(_dataPathBase + path, content, baseIndex);
			Assert.IsTrue(result);
		} // end method

		/// <summary>
		/// SPLITTER
		/// </summary>
		[Test]
		[TestCase("writeA.txt", "writeB.txt")]
		public void LineByLine_Splitter_Test(string pathA, string pathB)
		{
			List<string> content = new List<string>()
			{
				"1",
				"2",
				"3",
				"4",
				"5"
			};

			var result = TxtWriter.LineByLine(_dataPathBase + pathA, _dataPathBase + pathB, content);
			Assert.IsTrue(result);
		} // end method

		/// <summary>
		/// FILTER
		/// </summary>
		[Test]
		[TestCase("write.txt", "@")]
		[TestCase("write.txt", "test")]
		public void LineByLine_Filter_Test(string path, string targetValue)
		{
			List<string> content = new List<string>()
			{
				"fds768dfs96dftestfd78097dsf",
				" 2",
				"387sdtest",
				"4 ",
				"test 3343 435 "
			};

			var result = TxtWriter.LineByLine(_dataPathBase + path, content, targetValue);
			Assert.IsTrue(result);
		} // end method
	} // end class
} // end namespace
