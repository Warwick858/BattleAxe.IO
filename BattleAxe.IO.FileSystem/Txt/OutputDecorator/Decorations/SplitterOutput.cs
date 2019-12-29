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
using System.IO;

namespace BattleAxe.IO.FileSystem.Txt.OutputDecorator.Decorations
{
	/// <summary>
	/// Concrete decorator class which writes to two streams at a time; the one it wraps, 
	/// plus one it receives as a constructor argument
	/// </summary>
	public class SplitterOutput : OutputDecor
	{
		private readonly StreamWriter _streamWriter;
		private readonly IOutput _output;

		public SplitterOutput(IOutput output, StreamWriter streamWriter)
		{
			_output = output;
			_streamWriter = streamWriter;
		}

		public override void Write(object obj)
		{
			if (obj != null)
			{
				_streamWriter.Write(obj.ToString() + "\n");
				_output.Write(obj.ToString() + "\n");
			}
		} // end method
	} // end class
} // end namespace
