using System.Buffers;

namespace Ar6.Base64.Operations;

public class Base64Operations
{
	private Base64EncoderInternal _encoder = null!;
	private Base64DecoderInternal _decoder = null!;

	public string DecodeOrEncode(string textToDecode, bool decode)
	{
		// need to set _decoder or _encoder if null
		IBase64 base64 = decode ? _decoder ??= new() : _encoder ??= new();
		int destinationLength = GetDestinationLength(textToDecode, base64);

		Span<byte> result = stackalloc byte[destinationLength];
		var operationResult = EncodeOrDecode(textToDecode, result, out int bytesWritten, decode);

		if (operationResult is not OperationStatus.Done)
			throw new InvalidOperationResultException(operationResult);

		return base64.Encoding.GetString(result.Slice(0, bytesWritten));

		int GetDestinationLength(string textToDecode, IBase64 base64)
			=> base64.GetDestinationLength(textToDecode.Length);
		OperationStatus EncodeOrDecode(string textToDecode, Span<byte> result, out int bytesWritten, bool decode)
			=> decode ? _decoder.Decode(textToDecode, result, out bytesWritten) : _encoder.Encode(textToDecode, result, out bytesWritten);
	}
}