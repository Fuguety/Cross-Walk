using LiteDB;
using TextGameBase.Entities;

namespace TextGameBase.Repository
{
    internal class QuestionsRepository
    {
        private LiteDatabase db;
        private ILiteCollection<Question> collection;

        public QuestionsRepository(string databaseName)
        {
            db = new LiteDatabase(databaseName);
            collection = db.GetCollection<Question>();
        }

        public Question GetById(int id)
        {
            return collection.FindById(id);
        }

        public List<Question> GetAll()
        {
            return collection.FindAll().ToList();
        }

        public void DeleteAll()
        {
            collection.DeleteAll();
        }

        public void AddQuestion(Question question)
        {
            collection.Insert(question);
        }

        public void AddQuestions(List<Question> questions)
        {
            collection.InsertBulk(questions);
        }
    }
}