namespace RPG
{
    internal class Itens
    {
        public string name;
        public string description;
        public int? damage;
        
        public static List<Itens> itenList = new List<Itens>();

        public Itens (string Name, string Description, int? Damage = null)
        {
            this.name = Name;
            this.description = Description;
            this.damage = Damage;
        }
    }
}
