namespace Character.Properties
{
    public interface IProperty
    {
        string GetName();

        string GetFieldName();

        int GetValue();

        /**
         * Inverted means that big value equals to big need, like, for example, with hunger
         */
        bool IsInverted();
    }
}