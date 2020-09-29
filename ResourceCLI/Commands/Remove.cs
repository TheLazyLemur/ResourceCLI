namespace ResourceCLI.Commands
{
    public class Remove : CommandBase
    {
        private readonly IKnowledgeRepo _knowledgeRepo;

        public Remove(IKnowledgeRepo knowledgeRepo)
        {
            _knowledgeRepo = knowledgeRepo;
        }
        
        public override void RunCmd(string[] args)
        {
            _knowledgeRepo.ClearAll();    
        }
    }
}