namespace MockAssessment3
{
    public class Town
    {
        public List<Villager> Villagers { get; set; }

        public Town() {
            Villagers = new List<Villager>() { new Farmer(), new Slacker(), new Slacker(), new Slacker() };
        }

        public int Harvest()
        {
            return Villagers.Sum(x => x.Farm());
        }

        public int CalculateFoodConsumption()
        {
            return Villagers.Sum(x => x.Hunger);
        }

        public bool SurviveTheWinter()
        {
            return CalculateFoodConsumption() <= Harvest();
        }
    }
}