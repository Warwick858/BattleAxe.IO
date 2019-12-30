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
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleAxe.IO.FileSystem.Tests.Utilities
{
	[TestFixture]
	public class ListOfStrings2DExtensionsTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void To1DByRow_Test()
		{
			List<List<string>> data = new List<List<string>>()
			{
				new List<string>(){ "1", "2", "3", "4", "5" },
				new List<string>(){ "6", "7", "8", "9", "10" },
				new List<string>(){ "11", "12", "13", "14", "15" },
				new List<string>(){ "16", "17", "18", "19", "20" },
			};

			var result = data.To1DByRow();
			Assert.IsNotEmpty(result);
		} // end method

		[Test]
		public void ToStringByRow_Test()
		{
			List<List<string>> data = new List<List<string>>()
			{
				new List<string>(){ "1", "2", "3", "4", "5" },
				new List<string>(){ "6", "7", "8", "9", "10" },
				new List<string>(){ "11", "12", "13", "14", "15" },
				new List<string>(){ "16", "17", "18", "19", "20" },
			};

			var result = data.ToStringByRow();
			Assert.IsNotEmpty(result);
		} // end method
	} // end class
} // end namespace
