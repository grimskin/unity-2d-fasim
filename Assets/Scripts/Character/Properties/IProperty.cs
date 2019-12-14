namespace Character.Properties
{
    public interface IProperty
    {
        string GetName();

        string GetFieldName();

        int GetValue();

        int GetNormalizedValue();

        /**
         * Inverted means that big value equals to big need, like, for example, with hunger
         */
        bool IsInverted();
    }
}