using System.Buffers;
using System.Text;
using static System.Buffers.Text.Base64;

namespace Ar6.Base64.Operations;
class Base64EncoderInternal : UTF8Base64
{
	public OperationStatus Encode(string input, Span<byte> result, out int bytesWritten)
		=> EncodeToUtf8(Encoding.GetBytes(input), result, out _, bytesWritten: out bytesWritten);
	public override int GetDestinationLength(int length)
		=> GetMaxEncodedToUtf8Length(length);
}