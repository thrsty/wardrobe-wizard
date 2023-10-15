using System;
namespace wardrobe_wizard.Models
{
	public class clothingItemProperty
	{
        public string nameOfProperty { get; set; }
		public string propertyValue { get; set; }

        public clothingItemProperty(string _name, string _property)
		{
			nameOfProperty = _name;
			propertyValue = _property;
		}
	}
}