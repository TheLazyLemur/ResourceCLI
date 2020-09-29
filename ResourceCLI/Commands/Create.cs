using System;
using System.Linq;

namespace ResourceCLI.Commands
{
    public class Create : CommandBase
    {
        private readonly IKnowledgeRepo _knowledgeRepo;

        public Create(IKnowledgeRepo knowledgeRepo)
        {
            _knowledgeRepo = knowledgeRepo;
        }

        public override void RunCmd(string[] args)
        {
            var newItem = new Item();

            GetTitle(args, newItem);
            GetContent(args, newItem);

            _knowledgeRepo.AddItem(newItem);
        }

        private void GetTitle(string[] args, Item newItem)
        {
            if (!args.Contains("-title"))
            {
                Console.WriteLine("Please provide Title");
                var title = Console.ReadLine();

                newItem.Title = title;
            }
            else
            {
                var x = Array.IndexOf(args, "-title");
                var result = args[x + 1];
                newItem.Title = result;
            }
        }

        private void GetContent(string[] args, Item newItem)
        {
            if (!args.Contains("-content"))
            {
                Console.WriteLine("Please provide Content");
                var content = Console.ReadLine();
                newItem.Content = content;
            }
            else
            {
                var x = Array.IndexOf(args, "-content");
                var result = args[x + 1];
                newItem.Content = result;
            }
        }
    }
}