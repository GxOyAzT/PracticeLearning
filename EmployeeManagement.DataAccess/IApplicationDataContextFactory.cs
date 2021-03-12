namespace EmployeeManagement.DataAccess
{
    public interface IApplicationDataContextFactory
    {
        public ApplicationDataContext Build();
    }
}
