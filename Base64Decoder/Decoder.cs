using Ar6.Base64.Operations;

Ar6.ConsoleHelper.SetConsoleInputLength();
var base64Operations = new Base64Operations();

while (true)
{
	Console.Write("Write Base64 text to decode: ");
	string? text = Console.ReadLine();
	if (text is null)
		return;

	string result;
	try
	{
		result = base64Operations.DecodeOrEncode(text, decode: true);
	}
	catch (InvalidOperationResultException ex)
	{
		Console.WriteLine(ex);
		continue;
	}

	Console.WriteLine(result);
}