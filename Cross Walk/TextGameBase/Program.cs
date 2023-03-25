using TextGameBase.Services;
public class Game
{


    public static void Main()
    {

        var service = new TextGameService();
        var exit = false;
        var currentQuestion = service.GetQuestion(1);

		Console.WriteLine("Please insert your name:");
		var name = Console.ReadLine();

		service.Values.Add("<NAME>", name);



        do
        {
            var proceed = false;

            do
            {

                Console.WriteLine(service.TreatValue(currentQuestion?.Text));

                foreach (var response in currentQuestion?.Responses)
                {
                    Console.WriteLine($"{response.Sequence} - {response.Text}");
                }

                var responseText = Console.ReadLine();

                if (int.TryParse(responseText, out var responseSequence) && currentQuestion.Responses.Any(r => r.Sequence == responseSequence))
                {
                   
				    var response = currentQuestion.Responses.FirstOrDefault(r => r.Sequence == responseSequence);
                    if (response != null && response.TargetId != 0)
                    {
                       
					    currentQuestion = service.GetQuestion(response.TargetId);
                        if (currentQuestion == null)
                            exit = true;
    
                    }
                    else
                    {
                        exit = true;
                    }

                    proceed = true;
                }
                else
                    Console.WriteLine("Resposta inválida");
                

            } while (!proceed);
        } while (!exit);

        Console.WriteLine("the End.\nThanks for playing!");

    }


}
