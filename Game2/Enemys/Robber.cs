namespace Game2.Enemys
{
    internal class Robber : Enemy
    {
        public Robber() { }
        public Robber(string name, 
                      double level, 
                      double damage, 
                      double bustlevel = 0.4) : base(name, level, damage, bustlevel)
        {
            ResistancePhysical = 6 * level;
        }
    }
}
