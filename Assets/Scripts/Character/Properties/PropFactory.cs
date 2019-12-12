using System.Collections.Generic;

namespace Character.Properties
{
    public class PropFactory
    {
        private static Dictionary<string, IProperty> _properties;
        
        public static IProperty GetPropByName(string propName)
        {
            _checkPropList();
            
            return _properties[propName];
        }

        private static void _checkPropList()
        {
            if (!ReferenceEquals(_properties, null)) return;
            
            _properties = new Dictionary<string, IProperty>();
            
            var boredom = new Boredom();
            _properties.Add(boredom.GetName(), boredom);
            var fatigue = new Fatigue();
            _properties.Add(fatigue.GetName(), fatigue);
        }
    }
}