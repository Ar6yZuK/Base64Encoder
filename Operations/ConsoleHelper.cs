namespace Ar6;
internal class ConsoleHelper
{
	public static void SetConsoleInputLength(int length = 100_000)
		=> Console.SetIn(new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, length));
}