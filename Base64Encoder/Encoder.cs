using System.Buffers;
using System.Buffers.Text;
using System.Text;

// from private Property in Base64Encoder = 1610612733
const int MaximumEncodeLength = int.MaxValue / 4 * 3;

Console.SetIn(new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, MaximumEncodeLength));

while (true)
{
	Console.Write("Write text to encode to Base64: ");
	string? text = Console.ReadLine();
	if (text is null)
		return;

	string result = Encode(text);

	Console.WriteLine(result);
}

static string Encode(string textToEncode)
{
	int destinationLength = Base64.GetMaxEncodedToUtf8Length(textToEncode.Length);
	Span<byte> result = stackalloc byte[destinationLength];

	OperationStatus operationResult = Base64.EncodeToUtf8(Encoding.UTF8.GetBytes(textToEncode), result, out int bytesConsumed, out int bytesWritten);
	if (operationResult is not OperationStatus.Done)
		throw new Exception(operationResult.ToString());

	return Encoding.UTF8.GetString(result.Slice(0, bytesWritten));
}