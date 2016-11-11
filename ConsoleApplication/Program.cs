namespace ConsoleApplication
{
    using System;
    using Contracts.Services;
    using Ninject;
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var kernel = new StandardKernel(new NinjectBindings()))
            {
                var service = kernel.Get<IDataService>();

                string line;
                do
                {
                    line = Console.ReadLine();

                    Console.WriteLine(service.Resolve(line));

                } while (!string.IsNullOrEmpty(line));
            }
        }
    }
}
