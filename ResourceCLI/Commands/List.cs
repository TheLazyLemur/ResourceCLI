using System;

namespace ResourceCLI.Commands
{
    public class List : CommandBase
    {
        private readonly IKnowledgeRepo _knowledgeRepo;

        public List(IKnowledgeRepo knowledgeRepo)
        {
            _knowledgeRepo = knowledgeRepo;
        }
        
        public override void RunCmd(string[] args)
        {
            var allItems = _knowledgeRepo.GetAll();
            
            foreach (var item in allItems)
            {
                Console.WriteLine();
                Console.WriteLine("_________________");
                Console.WriteLine("Id : " + item.Id);
                Console.WriteLine("Title : " + item.Title);
                Console.WriteLine("Content : " + item.Content);
                Console.WriteLine("_________________");
                Console.WriteLine();
            }
        }
    }
}