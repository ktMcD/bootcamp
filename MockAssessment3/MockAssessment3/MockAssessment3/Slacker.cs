namespace MockAssessment3
{
    public class Slacker : Villager
    {
        public Slacker() { Hunger = 3; }

        public override int Farm()
        {
            return 0;
        }
    }
}