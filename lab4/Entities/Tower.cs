namespace TowerDefense.Entities
{
    public class Tower
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }

        public Tower(string name, int damage, int range)
        {
            Name = name;
            Damage = damage;
            Range = range;
        }
    }
}