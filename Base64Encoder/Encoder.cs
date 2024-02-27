using Ar6.Base64.Operations;

Ar6.ConsoleHelper.SetConsoleInputLength();
var base64Operations = new Base64Operations();

while (true)
{
	Console.Write("Write text to encode to Base64: ");
	string? text = Console.ReadLine();
	if (text is null)
		return;

	string result;
	try
	{
		result = base64Operations.DecodeOrEncode(text, decode: false);
	}
	catch (InvalidOperationResultException ex)
	{
		Console.WriteLine(ex);
		continue;
	}

	Console.WriteLine(result);
}