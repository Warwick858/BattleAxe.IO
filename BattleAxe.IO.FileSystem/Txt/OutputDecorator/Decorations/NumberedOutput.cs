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

namespace BattleAxe.IO.FileSystem.Txt.OutputDecorator.Decorations
{
	/// <summary>
	/// Concrete decorator class which adds newlines, and precedes each write with the current line
	/// number(given base index) right-justified in a field of width 5, followed by a colon and a space.
	/// </summary>
	public class NumberedOutput : OutputDecor
	{
		private readonly IOutput _output;
		private int _count;

		public NumberedOutput(IOutput output, int baseIndex)
		{
			_output = output;
			_count = baseIndex;
		}

		public override void Write(object obj)
		{
			_output.Write(string.Format("{0}: ", _count) + obj.ToString() + "\n");
			_count++;
		} // end method 
	} // end class
} // end namespace
