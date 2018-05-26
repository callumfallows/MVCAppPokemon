namespace PokeMart.Web.Types
{
    public class Ability
    {
        public Ability(string name, string text, string type)
        {
            Name = name;
            Text = text;
            Type = type;
        }

        public string Name { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }
}