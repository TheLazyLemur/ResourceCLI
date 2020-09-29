using System.Collections.Generic;

namespace ResourceCLI
{
    public interface IKnowledgeRepo
    {
        public List<Item> GetAll();
        public void AddItem(Item newItem);
        public void ClearAll();
        public void DeleteOne(int id);
    }
}