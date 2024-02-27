using System.Buffers;

namespace Ar6.Base64.Operations;
[Serializable]
public class InvalidOperationResultException(OperationStatus operationResult) : Exception(operationResult.ToString())
{
	public OperationStatus OperationResult { get; } = operationResult;
}