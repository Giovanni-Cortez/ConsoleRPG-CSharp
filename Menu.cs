using System;
using System.Media;
namespace RPG
{
    //Repositório do menu inicial, comportando a configuração do Player, opções e o fechamento do sistema
    internal class Menu
    {
        public static ConsoleColor screenColor = ConsoleColor.Black;
        public static ConsoleColor letterColor = ConsoleColor.Yellow;

        public void MenuScreen()
        {
            Scenary.menuMusic.PlayLooping();

            bool isMenu = true;

            while (isMenu)
            {
                Console.WriteLine("\n----------DUNGEONS&DRAGONS----------");
                Console.WriteLine("1.Jogar");
                Console.WriteLine("2.Opções");
                Console.WriteLine("3.Sair");
                Console.WriteLine("Digite o que deseja (1..2..):");
                string MenuChoice = Console.ReadLine().ToLower().Trim();

                switch (MenuChoice)
                {
                    case "1":
                    case "jogar":
                        isMenu = false;
                        Console.Clear();
                        MenuPlayer();
                        break;

                    case "2":
                    case "opções":
                        Console.Clear();
                        Options();
                        break;

                    case "3":
                    case "sair":
                        isMenu = false;
                        break;

                    default:
                        Console.WriteLine("Botão errado verme insolente. Tente novamente...");
                        break;
                }
            }
        }

        public void Options()
        {
            bool isColor = true;

            while (isColor)
            {
                Console.WriteLine("OPÇÕES");
                Console.WriteLine("\nCor do menu:");
                Console.WriteLine("1.Verde");
                Console.WriteLine("2.Azul");
                Console.WriteLine("3.Amarelo");
                Console.WriteLine("Digite a opção que deseja: ");

                string option = Console.ReadLine().ToLower().Trim();

                if (option == "verde" || option == "1")
                {
                    UI.ColorChange(ConsoleColor.Gray, 300, ConsoleColor.DarkGray, 400, ConsoleColor.Green, 1500, "Só um momento...");

                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;

                    screenColor = Console.BackgroundColor;
                    letterColor = Console.ForegroundColor;
                    Console.Clear();

                    isColor = false;

                    Console.WriteLine("Cor do menu alterada para Verde...");
                }

                else if (option == "azul" || option == "2")
                {
                    UI.ColorChange(ConsoleColor.Black, 300, ConsoleColor.Magenta, 400, ConsoleColor.Blue, 1500, "Quase-lá...");

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Black;

                    screenColor = Console.BackgroundColor;
                    letterColor = Console.ForegroundColor;
                    Console.Clear();

                    isColor = false;

                    Console.WriteLine("Cor do menu alterada para Azul...");
                }

                else if (option == "amarelo" || option == "3")
                {
                    UI.ColorChange(ConsoleColor.White, 300, ConsoleColor.Red, 400, ConsoleColor.Yellow, 1500, "Um segundo...");

                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    screenColor = Console.BackgroundColor;
                    letterColor = Console.ForegroundColor;
                    Console.Clear();

                    isColor = false;

                    Console.WriteLine("Cor do menu alterada para Amarelo...");
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente");
                }
            }
        }

        public void MenuPlayer()
        {
            bool isPlayer = true;

            Player player = new Player(); //Inicio do trueHero

            Scenary scenary = new Scenary();

            Console.WriteLine("Digite seu nome: ");
            player.name = Console.ReadLine();

            while (isPlayer)
            {
                UI.TypeWriter($"Escolha seu artefato inicial {player.name}:");
                Console.WriteLine("\n1.-ESPADA DE PRATA - \nQuando empunhada nas mãos corretas, devem ceifar até os maiores dragões");
                Console.WriteLine("\n2.-CAJADO MAGICO- \nArtefato de poder almejado pelos magos");
                Console.WriteLine("\n3.-ALÁUDE- \nInstrumento cuja sinfonia encanta até o mais melancólicos");

                string userclass = Console.ReadLine().ToLower().Trim();

                if (userclass == "espada" || userclass == "1")
                {
                    Console.Clear();
                    isPlayer = false;

                    Itens SilverSword = new Itens("Espada de Prata", "Quando empunhada nas mãos corretas, devem ceifar até os maiores dragões", 10);
                    player.inventory.Add(SilverSword);

                    player.life = 100;
                    player.magic = 20;
                    SilverSword.damage = 80;
                }

                else if (userclass == "cajado" || userclass == "2")
                {
                    Console.Clear();
                    isPlayer = false;

                    Itens MagicStaf = new Itens("Cajado Mágico", "Artefato de poder almejado pelos magos", 8);
                    player.inventory.Add(MagicStaf);

                    player.life = 100;
                    player.magic = 80;
                    MagicStaf.damage = 50;
                }

                else if (userclass == "aláude" || userclass == "3")
                {
                    Console.Clear();
                    isPlayer = false;

                    Itens Lute = new Itens("Aláude", "Instrumento cuja sinfonia encanta até o mais melancólico dos homens", 5);
                    player.inventory.Add(Lute);

                    player.life = 100;
                    player.magic = 50;
                    Lute.damage = 20;
                }

                else
                {
                    Console.WriteLine("\nEscolha direito seu tolo!");
                }
            }

            UI.NextScenaryLoad($"Boa sorte {player.name}, que você encontre seu valor no mundo desperto...", Scenary.menuMusic);

            UI.Awaken();
            scenary.BeginningScene(player);
        }
    }
}
