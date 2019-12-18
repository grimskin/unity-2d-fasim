namespace Character.Commands
{
    public class DoNothing: BaseCommand
    {
        private int _duration;
        private int _ticksLeft;
        
        public void SetDuration(int ticks)
        {
            _duration = ticks;
            _ticksLeft = _duration;
        }
        public override void invokeOn(IControlledCharacter character)
        {
            _ticksLeft--;
        }

        public override bool IsCompleted()
        {
            return _ticksLeft == 0;
        }
    }
}