namespace Character
{
    public class CharState
    {
        private int _boredom;
        private int _hunger;
        private int _fatigue;

        public int Boredom
        {
            get => _boredom;
            set => _boredom = value;
        }

        public int Hunger
        {
            get => _hunger;
            set => _hunger = value;
        }

        public int Fatigue
        {
            get => _fatigue;
            set => _fatigue = value;
        }
    }
}