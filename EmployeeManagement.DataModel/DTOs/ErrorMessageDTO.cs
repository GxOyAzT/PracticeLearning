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

        public string ErrorMessage { get; set; }
        public int InternalErrorCode { get; set; }
    }
}
