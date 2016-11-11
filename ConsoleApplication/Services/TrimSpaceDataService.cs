namespace ConsoleApplication.Services
{
    using Contracts.Services;

    public class TrimSpaceDataService : IDataService
    {
        public string Resolve(string param)
        {
            return param.Trim();
        }
    }
}
