namespace Character.Properties
{
    public abstract class BaseProp: IProperty
    {
        public abstract string GetName();

        public abstract string GetFieldName();

        public abstract bool IsInverted();

        public int GetValue()
        {
            return Value;
        }

        public int GetNormalizedValue()
        {
            return IsInverted() ? (100 - Value) : Value;
        }

        public int Value { get; set; }
    }
}
