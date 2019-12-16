namespace Character.Commands
{
    public interface ICommand
    {
        void invokeOn(IControlledCharacter character);

        bool IsCompleted();
    }
}
