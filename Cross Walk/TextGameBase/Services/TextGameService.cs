using System.Text.Json;
using TextGameBase.Entities;
using TextGameBase.Repository;

namespace TextGameBase.Services
{
    internal class TextGameService
    {
        private QuestionsRepository questionsRepository;

        public Dictionary<string, string> Values {get; set;} = new Dictionary<string, string>();

        public List<Item> Invetory { get; set; } = new List<Item>();

        public TextGameService()
        {
            questionsRepository = new QuestionsRepository("TextGame.db");
            LoadQuestions();
        }

        public string TreatValue(string value)
        {
            foreach(var key in Values.Keys)
            {
                value = value.Replace(key, Values[key]);
            }
            return value;
        }



        public Question GetQuestion(int id)
        {
            return questionsRepository.GetById(id);
        }

        private void LoadQuestions()
        {
            try
            {
                if (File.Exists("Questions.json"))
                {
                    var questions = JsonSerializer.Deserialize<List<Question>>(File.ReadAllText("Questions.json"));
                    questionsRepository.DeleteAll();
                    if (questions != null)
                    {
                        questionsRepository.AddQuestions(questions);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on loading file: ", e.Message);
            }

            var currentQuestions = questionsRepository.GetAll();

            if (!currentQuestions.Any())
            {
                var defaultQuestion = new Question
                {
                    Id = 1,
                    Text = "Bem vindo!",
                    Responses = new List<Response>
                    {
                        new Response { Sequence = 1, Text = "Iniciar Jogo", TargetId = 2 },
                        new Response { Sequence = 2, Text = "Sair", TargetId = 0 }
                    }
                };
                questionsRepository.AddQuestion(defaultQuestion);
            }
        }
    }
}