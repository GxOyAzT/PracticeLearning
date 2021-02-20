namespace EmployeeManagement.DataModel
{
    public class ErrorMessageDTO
    {
        public ErrorMessageDTO(string errorMessage, int internalErrorCode)
        {
            ErrorMessage = errorMessage;
            InternalErrorCode = internalErrorCode;
        }

        public ErrorMessageDTO() { }

        public string ErrorMessage { get; private set; }
        public int InternalErrorCode { get; private set; }
    }
}
