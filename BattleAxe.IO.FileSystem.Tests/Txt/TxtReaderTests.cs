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

namespace BattleAxe.IO.FileSystem.Tests.Txt
{
	[TestFixture]
	public class TxtReaderTests
	{
		private readonly string _dataPathBase = @"D:\Documents\Code\C#\Core\BattleAxe.IO\Data\";

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestCase("read.txt")]
		public void AllAsString_Test(string path)
		{
			var result = TxtReader.AllAsString(_dataPathBase + path);
			Assert.IsNotEmpty(result);
		} // end method

		[Test]
		[TestCase("read.txt")]
		public void AllAsList_Test(string path)
		{
			var result = TxtReader.AllAsList(_dataPathBase + path);
			Assert.NotZero(result.Count);
		} // end method

		[Test]
		[TestCase("read.txt")]
		public void LineByLine_Test(string path)
		{
			var result = TxtReader.LineByLine(_dataPathBase + path);
			Assert.IsNotEmpty(result);
		} // end method

		[Test]
		[TestCase("read.txt", true)]
		[TestCase("", true)]
		public void AllFilesAsList_Test(string path, bool isRecursive)
		{
			var result = TxtReader.AllFilesAsList(_dataPathBase + path, isRecursive);
			Assert.IsNotEmpty(result);
		} // end method
	} // end class
} // end namespace