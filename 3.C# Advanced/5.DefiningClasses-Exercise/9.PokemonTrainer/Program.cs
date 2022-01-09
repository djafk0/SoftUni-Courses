using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> pokemonTrainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] inputData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = inputData[0];
                string pokemonName = inputData[1];
                string pokemonElement = inputData[2];
                int pokemonHealth = int.Parse(inputData[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new Trainer(trainerName);

                if (!pokemonTrainers.Exists(t => t.Name == trainerName))
                {
                    pokemonTrainers.Add(trainer);
                }
                pokemonTrainers.First(t => t.Name == trainerName).Pokemons.Add(pokemon);
                
                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in pokemonTrainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, pokemonTrainers.OrderByDescending(t => t.Badges)));
        }
    }
}
