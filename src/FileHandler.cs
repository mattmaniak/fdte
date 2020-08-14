using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace fdte
{
	public static class FileHandler
	{
		public static void Save(string basename, List<string> text)
		{
			try
			{
				using (FileStream file = File.Create(basename))
				{
					string contents = "";
					byte[] serializedData;

					for (int l = 0; l < text.Count; l++)
					{
						contents += text[l] + "\r\n";
					}
					serializedData = new UTF8Encoding(true).GetBytes(contents);
					file.Write(serializedData, 0, serializedData.Length);
				}
			}
			catch (Exception) { }
		}
	}
}