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
            
            foreach (var s in allItems)
            {
                Console.WriteLine();
                Console.WriteLine("_________________");
                Console.WriteLine("Id : " + s.Id);
                Console.WriteLine("Title : " + s.Title);
                Console.WriteLine("Content : " + s.Content);
                Console.WriteLine("_________________");
            }
        }
    }
}