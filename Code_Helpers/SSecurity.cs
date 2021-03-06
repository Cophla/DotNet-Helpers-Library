﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using CodeHelpers.System;

namespace CodeHelpers
{
	public static class SSecurity
	{
		#region Private Fields

		private static readonly byte[] SYMMETRIC_KEY = Encoding.UTF8.GetBytes("b50a8157a7e24a81818a0d78c0ab1abc");

		#endregion Private Fields

		#region Public Methods

		public static string DecryptString(byte[] data)
		{
			using (MemoryStream targetBuffer = new MemoryStream())
			using (SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create())
			{
				algorithm.Key = SYMMETRIC_KEY;
				byte[] IV = new byte[algorithm.IV.Length];
				Array.Copy(data, IV, IV.Length);
				algorithm.IV = IV;
				int readPos = algorithm.IV.Length;
				using (CryptoStream cs = new CryptoStream(
						targetBuffer, algorithm.CreateDecryptor(), CryptoStreamMode.Write))
				{
					cs.Write(data, readPos, data.Length - readPos);
					cs.FlushFinalBlock();
					return Encoding.UTF8.GetString(targetBuffer.ToArray());
				}
			}
		}

		public static byte[] EncryptString(string data)
		{
			using (MemoryStream targetBuffer = new MemoryStream())
			using (SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create())
			{
				algorithm.Key = SYMMETRIC_KEY;
				algorithm.GenerateIV();
				targetBuffer.Write(algorithm.IV, 0, algorithm.IV.Length);

				using (CryptoStream cs = new CryptoStream(
						targetBuffer, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
				{
					byte[] ClearData = Encoding.UTF8.GetBytes(data);
					cs.Write(ClearData, 0, ClearData.Length);
					cs.FlushFinalBlock();
					return targetBuffer.ToArray();
				}
			}
		}

		public static string GetMD5HashPassword(string value)
		{
			using (MD5 algorithm = MD5.Create())
			{
				byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
				StringBuilder password = new StringBuilder(data.Length);
				foreach (byte bData in data)
				{
					password.Append(bData.ToString("x2").ToUpperInvariant());
				}
				string returnValue = password.ToString();
				password.Clear();
				password = null;
				return returnValue;
			}
		}

		public static string Protect(string text, string authenticationPurposeKey)
		{
			if (SObject.IsNoneInList(text, authenticationPurposeKey)) return null;

			byte[] stream = Encoding.UTF8.GetBytes(text);
			byte[] encodedValue = MachineKey.Protect(stream, authenticationPurposeKey);
			return HttpServerUtility.UrlTokenEncode(encodedValue);
		}

		public static string Unprotect(string text, string authenticationPurposeKey)
		{
			if (SObject.IsNoneInList(text, authenticationPurposeKey)) return null;

			byte[] stream = HttpServerUtility.UrlTokenDecode(text);
			byte[] decodedValue = MachineKey.Unprotect(stream, authenticationPurposeKey);
			return Encoding.UTF8.GetString(decodedValue);
		}

		#endregion Public Methods
	}
}