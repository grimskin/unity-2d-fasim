using Character.Properties;

namespace Character
{
    public class CharState
    {
        public const string StateIdle = "STATE_IDLE";
        public const string StateMoving = "STATE_MOVING";
        
        private int _hunger;

        public CharState()
        {
            Boredom = new Boredom();
            Fatigue = new Fatigue();
        }

        public Boredom Boredom { get; }
        public Fatigue Fatigue { get; }

        public void SetBoredom(int value)
        {
            Boredom.Value = value;
        }

        public void SetFatigue(int value)
        {
            Fatigue.Value = value;
        }

        public int Hunger
        {
            get => _hunger;
            set => _hunger = value;
        }
    }
}