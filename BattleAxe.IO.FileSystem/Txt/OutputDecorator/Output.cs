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
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace BattleAxe.IO.FileSystem.Txt.OutputDecorator
{
	/// <summary>
	/// Component class for output stream
	/// </summary>
	public class Output : IOutput
	{
		private StreamWriter _stream;

		public Output(StreamWriter stream)
		{
			_stream = stream;
		}

		public void Write(object obj)
		{
			try
			{
				_stream.Write(obj.ToString());
				_stream.Flush();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"\n\n{JsonConvert.SerializeObject(ex)}", "****IO_Library");
			}
		} // end method
	} // end class
} // end namespace
