using System.Media;

namespace RPG
{
    //Repositório das mecânicas, funcionalidades e ferramentas do sistema
    internal static class UI
    {
        public static int roll;

        private static Random random = new Random();

        public static int RollDice()
        {
            roll = random.Next(1, 21);
            return roll;
        }

        //RollTime exibe uma consequência diferente de acordo com o valor obtido na rolagem
        public static void RollTime(string text, string effect, string effect2, string effect3, string effect4)
        {
            Console.WriteLine($"Role o dado (4) para {text}");

            ConsoleKeyInfo keyTouch = Console.ReadKey(true);
            if (keyTouch.Key == ConsoleKey.D4 || keyTouch.Key == ConsoleKey.NumPad4)
            {
                RollDice();
                Console.WriteLine("Rolagem do dado: " + roll);
                RollConsequence(roll);

                if (roll == 20)
                {
                    Console.WriteLine(effect);
                }
                else if (roll >= 10)
                {
                    Console.WriteLine(effect2);
                }
                else if (roll < 10 && roll > 1)
                {
                    Console.WriteLine(effect3);
                }
                else if (roll == 1)
                {
                    Console.WriteLine(effect4);
                }
            }
        }

        public static void HUD(Player trueHero)
        {
            Console.WriteLine(trueHero.name);
            Console.WriteLine($"Vida: {trueHero.life}/ Mana: {trueHero.magic}/ Itens: {trueHero.inventory.Count}");
        }

        public static void ChoiceTime(Player trueHero, string text = null, string text2 = null)
        {
            Console.WriteLine("\nEscolha sua ação:");
            if (text != null)
            {
                Console.WriteLine(text);
            }
            if (text2 != null)
            {
                Console.WriteLine(text2);
            }
            HUD(trueHero);
        }

        public static void TypeWriter(string text)
        {
            foreach (char letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(40);
            }
        }

        ///WriteFear escreve letra por letra no console, com um pequeno atraso, para atmosfera
        public static void WriteFear(string text)
        {
            foreach (char letter in text)
            {
                Console.Write(letter);

                int FearTool = random.Next(10, 200);
                Thread.Sleep(FearTool);
            }
        }

        public static void RollConsequence(int roll)
        {
            if (roll == 20)
            {
                Console.WriteLine("Crítico");
            }
            else if (roll >= 10)
            {
                Console.WriteLine("Sucesso!");
            }
            else if (roll < 10 && roll > 1)
            {
                Console.WriteLine("Falha");
            }
            else if (roll == 1)
            {
                Console.WriteLine("Fracasso...");
            }
        }

        //HACK: Simula um carregamento enquanto altera o som/música
        public static void NextScenaryLoad(string text, SoundPlayer music = null, SoundPlayer music2 = null) 
        { 
            if (music != null)
            {
                music.Stop();
            }

            Console.Clear();

            if (music2 != null)
            {
                music2.PlayLooping();
            }

            UI.TypeWriter(text);
            Thread.Sleep(2000);
            
            if (music2 != null)
            {
                music2.Stop();
            }
        
            Console.Clear();
        }

        public static void Awaken() 
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Thread.Sleep(200);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Thread.Sleep(300);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Thread.Sleep(400);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Thread.Sleep(300);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Thread.Sleep(200);
            Console.Clear();

            Console.BackgroundColor = Menu.screenColor;
            Console.ForegroundColor = Menu.letterColor;
            Console.Clear();
        }

        //HACK: Altera a cor do console gradualmente
        public static void ColorChange(ConsoleColor color, int msec, ConsoleColor color2, int msec2, ConsoleColor color3, int msec3, string text = null)
        {
            Console.BackgroundColor = color;
            Console.Clear();
            Thread.Sleep(msec);

            Console.BackgroundColor = color2;
            Console.Clear();
            Thread.Sleep(msec2);

            Console.BackgroundColor = color3;
            Console.Clear();
            if (text != null)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                TypeWriter(text);
            }
            Thread.Sleep(msec3);
        }

        public static void TenseMoment(string text, params string[] text2)
        {
            Thread.Sleep(1000);

            Console.Clear();
            WriteFear(text);
            Console.Clear();

            foreach (string phrase in text2)
            {
                WriteFear(phrase);
                Thread.Sleep(1500);
                Console.Clear();
            }
            Thread.Sleep(2000);
        }

        //TODO: Sistema de combate ainda em desenvolvimento
        public static void CombatScene(Player trueHero, Enemy enemy, Enemy enemy2 = null, Enemy enemy3 = null)
        {
            Scenary.battleMusic.PlayLooping();
            ColorChange(ConsoleColor.DarkMagenta, 328, ConsoleColor.Red, 328, ConsoleColor.DarkRed, 328);
            Console.Clear();
            TypeWriter("O combate se inicia!");
            Thread.Sleep(800);
            Console.Clear();

            Scenary.unfinishedScene();
        }
    }
}
