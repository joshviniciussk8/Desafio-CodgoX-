using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
       
        int NumeroDeTasks = 10;
        List<Task> tasks = new List<Task>();
        Random random = new Random();
        for (int i = 1; i <= NumeroDeTasks; i++)
        {
            int taskId = i;
            tasks.Add(Task.Run(async () =>            { 
                int delay = random.Next(1000, 5000);
                await Task.Delay(delay);
                Console.WriteLine($"Tarefa {taskId} concluída em {delay / 1000.0} segundos.");
            }));
        }
        await Task.WhenAll(tasks);

        Console.WriteLine("Todas as tarefas foram processadas.");
        Console.ReadLine();
    }
}
