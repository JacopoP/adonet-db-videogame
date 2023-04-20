namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, int> softwareHouses = new Dictionary<string, int>();
            softwareHouses["Nintendo"] = 1;
            softwareHouses["Rockstar Games"] = 2;
            softwareHouses["Valve Corporation"] = 3;
            softwareHouses["Electronic Arts"] = 4;
            softwareHouses["Ubisoft"] = 5;
            softwareHouses["Konami"] = 6;
            int controller;
            do
            {
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("Digita 1 per inserire un nuovo videogioco");
                Console.WriteLine("Digita 2 per cercare un videogioco tramite id");
                Console.WriteLine("Digita 3 per ricercare un videogioco in base al nome");
                Console.WriteLine("Digita 4 per cancellare un videogioco");
                Console.WriteLine("Digita qualcos'altro per chiudere il programma\n");
                if(!Int32.TryParse(Console.ReadLine(), out controller))
                    controller = 0;
                switch (controller)
                {
                    case 1: 
                        {
                            string? nome;
                            string? descrizione;
                            DateTime dataUscita;
                            int softwareHouse = 0;

                            do
                            {
                                Console.WriteLine("Come si chiama il videogioco?");
                                nome = Console.ReadLine();
                            } while (nome == null);
                            do
                            {
                                Console.WriteLine("Scrivi una breve descrizione del gioco");
                                descrizione = Console.ReadLine();
                            } while (descrizione == null);
                            do
                            {
                                Console.WriteLine("Quando è uscito? (gg/mm/yyyy)");
                            } while (!DateTime.TryParse(Console.ReadLine(), out dataUscita));
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Qual è la software house che l'ha rilascaito?");
                                    softwareHouse = softwareHouses[Console.ReadLine()];
                                }
                                catch
                                {
                                    Console.WriteLine("Software house non trovata");
                                }
                            }while (softwareHouse == 0);
                            Console.WriteLine(VideogameManager.InserisciVideogame(nome, descrizione, dataUscita, softwareHouse));
                        }
                    break;
                    case 2: 
                        {
                            int id;
                            do
                            {
                                Console.WriteLine("Qual è l'id del videogioco che vuoi cercare?");
                            } while (!Int32.TryParse(Console.ReadLine(), out id));
                        }
                    break;
                    case 3: 
                        {
                            string? filtro;
                            do
                            {
                                Console.WriteLine("Qual è il nome del videogioco che vuoi cercare?");
                                filtro = Console.ReadLine();
                            } while (filtro == null);
                        }
                    break;
                    case 4: 
                        {
                            int id;
                            do
                            {
                                Console.WriteLine("Qual è l'id del videogioco che vuoi cancellare?");
                            } while (!Int32.TryParse(Console.ReadLine(), out id));
                        }
                    break;
                    default: 
                        {
                            controller = 0;
                            Console.WriteLine("Grazie per aver usato il servizio!");
                        }
                    break;
                }
                Console.WriteLine();
            }while(controller != 0);
        }
    }
}