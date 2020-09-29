using System.Collections.Generic;
using LiteDB;

namespace ResourceCLI
{
    public class LiteDbRepo : IKnowledgeRepo
    {
        public void ClearAll()
        {
            using var db = new LiteDatabase(@"/home/dan/Items.Db");
            var col = db.GetCollection<Item>("items");
            col.DeleteAll();
        }

        public void DeleteOne(int id)
        {
            using var db = new LiteDatabase(@"/home/dan/Items.Db");
            var col = db.GetCollection<Item>("items");
            var toDelete = col.FindOne(x => x.Id == id);
            
            if (toDelete != null)
                col.Delete(toDelete.Id);
        }

        List<Item> IKnowledgeRepo.GetAll()
        {
            using var db = new LiteDatabase(@"/home/dan/Items.Db");
            var col = db.GetCollection<Item>("items");
            var results = col.Query().ToList();

            return results;
        }

        public void AddItem(Item newItem)
        {
            using var db = new LiteDatabase(@"/home/dan/Items.Db");
            var col = db.GetCollection<Item>("items");

            col.Insert(newItem);
        }
    }
}