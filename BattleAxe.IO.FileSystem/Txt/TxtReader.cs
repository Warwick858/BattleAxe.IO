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
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleAxe.IO.FileSystem.Txt
{
	public static class TxtReader
	{
		/// <summary>
		/// Reads the text file at the given path.
		/// </summary>
		/// <returns>string, success = the contents of the file & failuire = string.Empty</returns>
		public static string AllAsString(string path)
		{
			if (File.Exists(path))
				return File.ReadAllText(path);

			return string.Empty;
		} // end method

		/// <summary>
		/// Reads the text file at the given path.
		/// </summary>
		/// <returns>list of strings, success = the contents of the file & failuire = an empty list</returns>
		public static List<string> AllAsList(string path)
		{
			if (File.Exists(path))
				return new List<string>(File.ReadAllLines(path));

			return new List<string>();
		} // end method

		/// <summary>
		/// Reads the text file at the given path, line by line.
		/// </summary>
		/// <returns>list of strings, success = the contents of the file & failuire = an empty list</returns>
		public static List<string> LineByLine(string path)
		{
			int count = 0;
			string? line = string.Empty;
			List<string> data = new List<string>();

			try
			{
				if (File.Exists(path))
				{
					using StreamReader sr = new StreamReader(path);
					while ((line = sr.ReadLine()) != null)
					{
						data.Add(line);
						count++;
					}
				}
			} // end try
			catch
			{
				//do nothing
			}

			return data;
		} // end method

		/// <summary>
		/// Reads all the files in the given directory.
		/// IsRecursive determines whether files in nested directories are also read.
		/// </summary>
		/// <returns>list of List'string', success = the contents of the directory(s) & failuire = an empty list of List'string'</returns>
		public static List<List<string>> AllFilesAsList(string path, bool isRecursive)
		{
			List<string> files = new List<string>();
			List<string> directories = new List<string>();
			List<List<string>> data = new List<List<string>>();

			GetFilePaths_Recursively(path, isRecursive, ref files, ref directories);

			foreach (var f in files)
				if (File.Exists(f))
					data.Add( new List<string>(File.ReadAllLines(f)));

			return data;
		} // end method

		private static void GetFilePaths_Recursively(string path, bool isRecursive, ref List<string> files, ref List<string> directories)
		{
			//If path is to a file, gets the path to first parent
			path = GetDirectoryPath(path);

			files = files.Concat(new List<string>(Directory.GetFiles(path))).ToList();
			directories = new List<string>(Directory.GetDirectories(path));

			//Find file extensions in the directory - unused for now
			//var extensions = (from file in Files select Path.GetExtension(file)).Distinct();

			//Recursively search subdirectories
			foreach (var sub in directories)
				GetFilePaths_Recursively(sub, isRecursive, ref files, ref directories);
		} // end method

		private static string GetDirectoryPath(string path)
		{
			string endOfPath = string.Empty;
			int lastBckSlash = -1;
			int lastFwdSlash = path.LastIndexOf('/');

			if (lastFwdSlash == -1)
				lastBckSlash = path.LastIndexOf('\\');

			endOfPath = path.Substring((lastFwdSlash != -1) ? lastFwdSlash : lastBckSlash);

			if (endOfPath.Contains('.'))
				return Directory.GetParent(path).ToString();

			return path;
		} // end method
	} // end class
} // end namespace
