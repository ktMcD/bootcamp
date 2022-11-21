namespace MockAssessment3
{
    public class Farmer : Villager
    {
        public Farmer() { Hunger = 1; }

        public override int Farm()
        {
            return 2;
        }
    }
}