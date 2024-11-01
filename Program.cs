using ContactApp.Models;
using ContactApp.Presentation;


namespace ContactApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactStore contactStore = new ContactStore();
            contactStore.Start();
        }
    }
}
