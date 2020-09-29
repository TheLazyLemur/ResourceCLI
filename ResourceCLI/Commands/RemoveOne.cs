using System;

namespace ResourceCLI.Commands
{
    public class RemoveOne : CommandBase
    {
        private readonly IKnowledgeRepo _knowledgeRepo;

        public RemoveOne(IKnowledgeRepo knowledgeRepo)
        {
            _knowledgeRepo = knowledgeRepo;
        }

        public override void RunCmd(string[] args)
        {
            var x = Array.IndexOf(args, "--delete-one");
            var result = args[x + 1];

            _knowledgeRepo.DeleteOne(int.Parse(result));
        }
    }
}