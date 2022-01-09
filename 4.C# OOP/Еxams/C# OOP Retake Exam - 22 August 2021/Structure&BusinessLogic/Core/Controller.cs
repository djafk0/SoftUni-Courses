using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronautRepository;
        private readonly IRepository<IPlanet> planetRepository;
        private readonly IMission mission;
        private int exploredPlanets;

        public Controller()
        {
            astronautRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();
            mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            astronautRepository.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronauts = new List<IAstronaut>();
            astronauts.AddRange(astronautRepository.Models.Where(x => x.Oxygen > 60));

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            exploredPlanets++;

            mission.Explore(planetRepository.FindByName(planetName), astronauts);

            return $"Planet: {planetName} was explored! Exploration finished with {astronauts.Where(x => !x.CanBreath).Count()} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astronaut in astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                string items = astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none";
                sb.AppendLine($"Bag items: {items}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            else
            {
                astronautRepository.Remove(astronaut);
                return $"Astronaut {astronautName} was retired!";
            }
        }
    }
}
