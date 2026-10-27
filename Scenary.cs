using System.Media;

namespace RPG
{
    //Classe responsável por organizar o decorrer da campanha, como textos, escolhas, interaões e fluxos de ambientes
    internal class Scenary
    {
        public static SoundPlayer menuMusic = new SoundPlayer(@"Audios\mus_menu0.wav");
        public static SoundPlayer battleMusic = new SoundPlayer(@"Audios\mus_battle1.wav");
        static SoundPlayer beginMusic = new SoundPlayer(@"Audios\mus_story.wav");
        static SoundPlayer walkGrass = new SoundPlayer(@"Audios\minecraft-walking-on-grass.wav");
        static SoundPlayer lostWoods = new SoundPlayer(@"Audios\35-Lost-Woods.wav");
        static SoundPlayer jawsTheme = new SoundPlayer(@"Audios\jaws-theme_TDORPKA.wav");
        static SoundPlayer suspense = new SoundPlayer(@"Audios\st069.wav");

        public void letterBegin()
        {
            Console.WriteLine("         " + "Olá meu caro, se encontra essa carta, gostaria de");
            Console.WriteLine("         " + "lhe avisar, que destrui sua moradia e tomei");
            Console.WriteLine("         " + "posse de seu fascinante companheiro felino.");
            Console.WriteLine("         " + "Assinado:");
            Console.WriteLine("         " + "- Lorde Maquiavélico das Trevas");
        }

        public void BeginningScene(Player trueHero) 
        {
            beginMusic.PlayLooping();
            Thread.Sleep(1500);

            UI.TypeWriter("\nDeitado numa clareira, serpenteada");
            UI.TypeWriter("\npor grandes pinheiros salpicados de neve");
            UI.TypeWriter("\nO vento sopra uivosamente... enquanto três aves necrófagas rodopiam no céu nublado...");
            UI.TypeWriter("\nEncarando seu alvo no chão sórdido lá em baixo...");
            Console.Clear();
            UI.TypeWriter($"\nLargado nas folhas, {trueHero.name} abre seus olhos...");
            UI.TypeWriter("\nCom a visão ainda turva e uma dor latejante na nuca");

            UI.TypeWriter("\nEscolha o que deseja fazer:");
            UI.ChoiceTime(trueHero, "\n1.Explorar Ambiente", "2.Caminhar pelo bosque\n");

            string userChoice = Console.ReadLine().ToLower().Trim();

            switch (userChoice)
            {
                case "1":
                    BeginVegetation(trueHero);
                    break;

                case "2":
                    UI.NextScenaryLoad("Caminhando...", beginMusic, walkGrass);
                    IntoTheWoods(trueHero);
                    break;
            }
        }

        public void BeginVegetation(Player trueHero)
        {
            Console.Clear();
            UI.TypeWriter("\nCom a visão parcialmente embaçada, nota-se mais algumas coisas ao redor");
            UI.TypeWriter("\nPorém, ps olhos não enchergam com clareza");
            Console.Clear();
            UI.TypeWriter("Enquanto na distância, entre os picos montanhosos, pequenos telhados criam forma");

            UI.ChoiceTime(trueHero, "\n1.Investigar", "2.Seguir para o local\n");
            string userChoice = Console.ReadLine().ToLower().Trim();

            if (userChoice == "1")
            {
                UI.RollTime("investigar", "Você encontra uma coleira de gato", "Você encontra uma carta", "Voce não acha nada de útil", "Você tropeça num tronco");
                if (UI.roll >= 10)
                {
                    UI.TypeWriter("\nCarta misteriosa:" + "\n");
                    letterBegin();
                }

                Console.WriteLine("\n1.Voltar");
                userChoice = Console.ReadLine().ToLower().Trim();
                if (userChoice == "1")
                {
                    UI.NextScenaryLoad("Caminhando...", beginMusic, walkGrass);
                    IntoTheWoods(trueHero);
                }
            }
            else if (userChoice == "2")
            {
                UI.NextScenaryLoad("Caminhando...", beginMusic, walkGrass);
                IntoTheWoods(trueHero);
            }
        }

        public void IntoTheWoods(Player trueHero)
        {
            lostWoods.PlayLooping();
            Console.Clear();
            UI.TypeWriter("Atordoado e cambaleante");
            UI.TypeWriter("\nVocê começa a caminhar penosamente entre o bosque");
            UI.TypeWriter("\nEm rumo até as construções que se estendem no horizonte...");
            Console.Clear();
            UI.TypeWriter("Após alguns passos incertos");
            UI.TypeWriter("\nVocê se depara com dois caminhos em sua frente...");
            Console.Clear();
            UI.TypeWriter("Em um lado, um grande lago se estende com sua água reluzente");
            UI.TypeWriter("\nJá do outro, onde a luz não alcança,");
            UI.TypeWriter("\num temivel aglomerado de árvores ");
            Console.Clear();
            UI.TypeWriter("cujas silhuetas escuras e decreptas");
            UI.TypeWriter("\nemitem vozes lamuriante em meio as trevas...");
            UI.TypeWriter("\nO que deseja fazer:");

            UI.ChoiceTime(trueHero, "1.Atravessar o lago", "2.Atravessar local extremamente suspeito");

            string userChoice = Console.ReadLine().ToLower().Trim();

            switch(userChoice)
            {
                case "1":
                    UI.NextScenaryLoad("Caminhando...", walkGrass, walkGrass);
                    Lake(trueHero);
                    break;

                case "2":
                    UI.NextScenaryLoad("Caminhando...", walkGrass, walkGrass);
                    ScaryForest(trueHero);
                    break;

                default:
                    Console.WriteLine("\nEscohlha direito tolo(a) desprezível");
                    break;
            }
        }

        public void Lake(Player trueHero)
        {
            lostWoods.PlayLooping();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Thread.Sleep(900);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            UI.TypeWriter("Se aproximando da beira do lago");
            UI.TypeWriter("\nVocê começa a travessia...");
            Console.Clear();
            UI.TypeWriter("No outro canto daquela vasta água, consegue enchergar");
            UI.TypeWriter("\nas construções mais próximas..");
            Console.Clear();
            UI.TypeWriter("\nConforme você vai adentrando mais e mais");
            UI.TypeWriter("\naquela imensidão azulada");
            Console.Clear();
            UI.TypeWriter("\nÉ capaz de ver coisas submersas");
            UI.TypeWriter("\nO que deseja fazer:");

            UI.ChoiceTime(trueHero, "1.Mergulhar", "2.Continuar travessia");

            string userChoice = Console.ReadLine().ToLower().Trim();

            if (userChoice == "1")
            {
                InsideLake(trueHero);
            }

            else if (userChoice == "2")
            {
                Console.Clear();
                UI.TypeWriter("Conforme você continua nadando");
                UI.TypeWriter("\nA água começa se agitar");
                Console.WriteLine("O que fazer: ");
                UI.RollTime("agir", "Ao perceber o tubarão, você consegue acelerar", "Próximo de você... um tubarão se aproxima", "Os peixes ficam agitados, mas você não vê nada mais...", "Você não percebe nada...");
                unfinishedScene(lostWoods);
            }
        }

        public void InsideLake(Player trueHero)
        {
            UI.RollTime("tentar nadar", "\nVocê avista um punhado de moedas de ouro que reluzem sob você ao mergulhar", "\nVocê mergulha e vê um punhado de moedas", "Ainda fraco devido seu despertar recente, você não tem folego", "Você engasga com a água e quase morre...");
            if (UI.roll == 20)
            {
                trueHero.money += 20;
                Console.WriteLine("\n(Você adquire 20 moedas)");

            }
            if (UI.roll >= 10 && UI.roll < 20)
            {
                trueHero.money += 10;
                Console.WriteLine("\n(Você adquire 10 moedas)");
            }

            Thread.Sleep(2000);
            Console.Clear();
            
            jawsTheme.PlayLooping();
            UI.WriteFear("...");
            Thread.Sleep(1800);

            UI.WriteFear("Nadando novamente de volta para superfície...");
            UI.WriteFear("\nVocê sente a água ficando agitada...");
            Thread.Sleep(2000);

            UI.WriteFear("\nNo canto de sua visão periférica...");
            UI.WriteFear("\nAlgo se aproxima");
            Thread.Sleep(3000);

            UI.WriteFear("\nUm tubarão branco se revela...");
            Thread.Sleep(1500);
            Console.Clear();

            unfinishedScene(lostWoods);
        }

        public void ScaryForest(Player trueHero)//TODO: Cenário em desenvolvimento
        {
            UI.TypeWriter("Conforme você se aproxima");
            UI.TypeWriter("\nUm elfo surge da moita!");
            Thread.Sleep(1000);

            Enemy elf = new Enemy();
            elf.name = "Galamarus";
            elf.description = "Um pequeno elfo, portando uma adaga";
            elf.life = 50;
            elf.damage = 10;
            elf.level = 1;

            lostWoods.Stop();

            UI.CombatScene(trueHero, elf);
        }

        public static void unfinishedScene(SoundPlayer music = null)//HACk: Texto provisório para preencher cenas incompletas
        {
            Thread.Sleep(800);
            if (music != null)
            {
                music.Stop();
            }
      
            suspense.PlayLooping();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            UI.TenseMoment("Subitamente... uma fraqueza toma posse do seu corpo", "Você apaga...", "E apenas vê o vazio", 
                "Sente frio, e seu corpo treme...", "o motivo?");

            UI.TypeWriter("Por que esse trecho não foi programado, até mais");
            Thread.Sleep(2000);
        }
    }
}