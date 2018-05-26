namespace PokeMart.Web.Types
{
    public class Attack
    {
        public Attack(string[] cost, string name, string text, string damage, int convertedEnergyCost)
        {
            Cost = cost;
            Name = name;
            Text = text;
            Damage = damage;
            ConvertedEnergyCost = convertedEnergyCost;
        }

        public string[] Cost { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Damage { get; set; }
        public int ConvertedEnergyCost { get; set; }
    }
}