namespace Character.Commands
{
    public abstract class BaseCommand: ICommand
    {
        public abstract void invokeOn(IControlledCharacter character);

        public abstract bool IsCompleted();
    }
}