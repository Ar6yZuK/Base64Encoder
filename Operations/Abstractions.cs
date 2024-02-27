using System.Text;

namespace Ar6.Base64.Operations;
interface IBase64
{
	Encoding Encoding { get; }
	int GetDestinationLength(int length);
}
abstract class UTF8Base64 : IBase64
{
	public Encoding Encoding => Encoding.UTF8;
	public abstract int GetDestinationLength(int length);
}
