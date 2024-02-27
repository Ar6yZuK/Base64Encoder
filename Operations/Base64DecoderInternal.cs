using System.Buffers;
using System.Text;
using static System.Buffers.Text.Base64;

namespace Ar6.Base64.Operations;
class Base64DecoderInternal : UTF8Base64
{
	public OperationStatus Decode(string input, Span<byte> result, out int bytesWritten)
		=> DecodeFromUtf8(Encoding.GetBytes(input), result, out _, bytesWritten: out bytesWritten);
	public override int GetDestinationLength(int length)
		=> GetMaxDecodedFromUtf8Length(length);
}