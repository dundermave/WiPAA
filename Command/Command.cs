using System;
using System.Collections.Generic;

namespace Command
{
    public interface ISantaCommand
    {
        void Execute();
    }

    public class SantaClausFactory
    {
        public void AssembleToy(string toyTitle)
        {
            Console.WriteLine($"[Fabryka] Zrealizowano zamówienie: zabawka \"{toyTitle}\".");
        }

        public void PrepareRod()
        {
            Console.WriteLine("[Fabryka] Przygotowano rózgę (tryb: dyscyplina).");
        }
    }

    public class CreateToyCommand : ISantaCommand
    {
        private readonly SantaClausFactory _receiver;
        private readonly string _toyTitle;

        public CreateToyCommand(SantaClausFactory receiver, string toyTitle)
        {
            _receiver = receiver;
            _toyTitle = toyTitle;
        }

        public void Execute()
        {
            _receiver.AssembleToy(_toyTitle);
        }
    }

    public class CreateRodCommand : ISantaCommand
    {
        private readonly SantaClausFactory _receiver;

        public CreateRodCommand(SantaClausFactory receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.PrepareRod();
        }
    }

    public class SantaHelper
    {
        private readonly Queue<ISantaCommand> _taskQueue = new();

        public void PassCommand(ISantaCommand command)
        {
            _taskQueue.Enqueue(command);
        }

        public void ProcessQueue()
        {
            while (_taskQueue.Count > 0)
            {
                var cmd = _taskQueue.Dequeue();
                cmd.Execute();
            }
        }
    }
}
