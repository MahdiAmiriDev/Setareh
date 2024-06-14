

using System.Security.Cryptography;
using System.Text;

namespace Setareh.Bussines.Security
{
	public static class PasswordHasher
	{
		public static string EncodePasswordMd5(this string pass)
		{
			Byte[] orginalBytes;
			Byte[] encodedBytes;
			MD5 md5;

			md5 = new MD5CryptoServiceProvider();
			orginalBytes = ASCIIEncoding.Default.GetBytes(pass);
			encodedBytes = md5.ComputeHash(orginalBytes);

			return BitConverter.ToString(encodedBytes);
		}
	}
}
