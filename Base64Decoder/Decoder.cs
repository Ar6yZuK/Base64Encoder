using System.Buffers;
using System.Buffers.Text;
using System.Text;

Console.SetIn(new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 100_000));

while (true)
{
    Console.Write("Write Base64 text to decode: ");
    string? text = Console.ReadLine();
	if (text is null)
		return;

	string result = Decode(text);

	Console.WriteLine(result);
}

static string Decode(string textToDecode)
{
	int destinationLength = Base64.GetMaxDecodedFromUtf8Length(textToDecode.Length);
	Span<byte> result = stackalloc byte[destinationLength];

	OperationStatus operationResult = Base64.DecodeFromUtf8(Encoding.UTF8.GetBytes(textToDecode), result, out int byteConsumed, out int bytesWritten);
	if (operationResult is not OperationStatus.Done)
		throw new Exception(operationResult.ToString());

	return Encoding.UTF8.GetString(result.Slice(0, bytesWritten));
}