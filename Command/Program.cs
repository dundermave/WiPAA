using Command;

namespace Command
{
    internal class Program
    {
        static void Main()
        {
            SantaClausFactory factory = new SantaClausFactory();
            SantaHelper helper = new SantaHelper();

            helper.PassCommand(new CreateToyCommand(factory, "Robot strażnik"));
            helper.PassCommand(new CreateToyCommand(factory, "Pociąg elektryczny"));
            helper.PassCommand(new CreateToyCommand(factory, "Gra planszowa"));
            helper.PassCommand(new CreateRodCommand(factory));

            helper.ProcessQueue();
        }
    }
}
