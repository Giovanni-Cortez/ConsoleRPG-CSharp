namespace RPG
{
     internal class Player
    {
        public string name;
        public int life;
        public int magic;
        public int money;

        public List<Itens> inventory = new List<Itens>();
    }
}