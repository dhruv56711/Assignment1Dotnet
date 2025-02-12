using System;
using System.Collections.Generic;
using System.Linq;

namespace A1DhruvYadav
{
    class Program
    {
        static List<Player> players = new List<Player>();

        static void Main(string[] args)
        {
            PopulateSampleData();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sports Player Stats Management ===");
                Console.WriteLine("1 - Add Player");
                Console.WriteLine("2 - Edit Player");
                Console.WriteLine("3 - Delete Player");
                Console.WriteLine("4 - View Players");
                Console.WriteLine("5 - Search Player");
                Console.WriteLine("6 - Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddPlayerMenu(); break;
                    case "2": EditPlayer(); break;
                    case "3": DeletePlayer(); break;
                    case "4": ViewPlayers(); break;
                    case "5": SearchPlayer(); break;
                    case "6": return;
                    default: Console.WriteLine("Invalid choice. Try again!"); break;
                }
            }
        }

        static void PopulateSampleData()
        {
    players.Add(new HockeyPlayer("Baskaran S", "India National Team", 45, 35, 20)); 
    players.Add(new BasketballPlayer("Satnam Singh", "Texas Legends", 40, 180, 50)); 
    players.Add(new BaseballPlayer("Russell Martin", "Toronto Blue Jays", 120, 80, 15)); 
        }

        static void AddPlayerMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Add Hockey Player");
            Console.WriteLine("2 - Add Basketball Player");
            Console.WriteLine("3 - Add Baseball Player");
            Console.WriteLine("4 - Back to Main Menu");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            if (choice == "4") return;

            Console.Write("Enter Player Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Team Name: ");
            string team = Console.ReadLine();

            Console.Write("Enter Games Played: ");
            if (!int.TryParse(Console.ReadLine(), out int games)) return;

            if (choice == "1") // Hockey
            {
                Console.Write("Enter Assists: ");
                if (!int.TryParse(Console.ReadLine(), out int assists)) return;
                Console.Write("Enter Goals: ");
                if (!int.TryParse(Console.ReadLine(), out int goals)) return;

                players.Add(new HockeyPlayer(name, team, games, assists, goals));
            }
            else if (choice == "2") // Basketball
            {
                Console.Write("Enter Field Goals: ");
                if (!int.TryParse(Console.ReadLine(), out int fieldGoals)) return;
                Console.Write("Enter Three Pointers: ");
                if (!int.TryParse(Console.ReadLine(), out int threePointers)) return;

                players.Add(new BasketballPlayer(name, team, games, fieldGoals, threePointers));
            }
            else if (choice == "3") // Baseball
            {
                Console.Write("Enter Runs: ");
                if (!int.TryParse(Console.ReadLine(), out int runs)) return;
                Console.Write("Enter Home Runs: ");
                if (!int.TryParse(Console.ReadLine(), out int homeRuns)) return;

                players.Add(new BaseballPlayer(name, team, games, runs, homeRuns));
            }

            Console.WriteLine("Player added successfully!");
            ViewPlayers();
            Console.ReadKey();
        }
        static void EditPlayer()
        {
            Console.Clear();
            ViewPlayers();

            Console.Write("\nEnter the Player ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int playerId))
            {
                Console.WriteLine("Invalid input! Press any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            Player player = players.FirstOrDefault(p => p.PlayerId == playerId);
            if (player == null)
            {
                Console.WriteLine("Player not found! Press any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter New Player Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter New Team Name: ");
            string newTeam = Console.ReadLine();

            Console.Write("Enter New Games Played: ");
            if (!int.TryParse(Console.ReadLine(), out int newGames))
            {
                Console.WriteLine("Invalid input! Press any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            // Update common properties
            player.PlayerName = newName;
            player.TeamName = newTeam;
            player.GamesPlayed = newGames;

            if (player is HockeyPlayer hockeyPlayer)
            {
                Console.Write("Enter New Assists: ");
                if (!int.TryParse(Console.ReadLine(), out int newAssists)) return;
                Console.Write("Enter New Goals: ");
                if (!int.TryParse(Console.ReadLine(), out int newGoals)) return;

                hockeyPlayer.Assists = newAssists;
                hockeyPlayer.Goals = newGoals;
            }
            else if (player is BasketballPlayer basketballPlayer)
            {
                Console.Write("Enter New Field Goals: ");
                if (!int.TryParse(Console.ReadLine(), out int newFieldGoals)) return;
                Console.Write("Enter New Three Pointers: ");
                if (!int.TryParse(Console.ReadLine(), out int newThreePointers)) return;

                basketballPlayer.FieldGoals = newFieldGoals;
                basketballPlayer.ThreePointers = newThreePointers;
            }
            else if (player is BaseballPlayer baseballPlayer)
            {
                Console.Write("Enter New Runs: ");
                if (!int.TryParse(Console.ReadLine(), out int newRuns)) return;
                Console.Write("Enter New Home Runs: ");
                if (!int.TryParse(Console.ReadLine(), out int newHomeRuns)) return;

                baseballPlayer.Runs = newRuns;
                baseballPlayer.HomeRuns = newHomeRuns;
            }

            Console.WriteLine("Player information updated successfully!");
            ViewPlayers();
            Console.ReadKey();
        }
        static void DeletePlayer()
        {
            Console.Clear();
            ViewPlayers();

            Console.Write("\nEnter the Player ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int playerId))
            {
                Console.WriteLine("Invalid input! Press any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            Player playerToDelete = players.FirstOrDefault(p => p.PlayerId == playerId);
            if (playerToDelete == null)
            {
                Console.WriteLine("Player not found! Press any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            players.Remove(playerToDelete);
            Console.WriteLine("Player deleted successfully!");
            ViewPlayers();
            Console.ReadKey();
        }



        static void ViewPlayers()
        {
            Console.Clear();
            Console.WriteLine("ID   Name            Team            Games Points");
            Console.WriteLine("-------------------------------------------------");

            foreach (var player in players)
            {
                Console.WriteLine(player);
            }

            Console.ReadKey();
        }

        static void SearchPlayer()
        {
            Console.Write("Enter Player Name to Search: ");
            string search = Console.ReadLine().ToLower();

            var found = players.Where(p => p.PlayerName.ToLower().Contains(search)).ToList();

            if (found.Any())
            {
                Console.WriteLine("Players Found:");
                foreach (var player in found)
                    Console.WriteLine(player);
            }
            else
            {
                Console.WriteLine("No players found.");
            }
            Console.ReadKey();
        }
    }
}
