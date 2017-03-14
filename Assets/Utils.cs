using System;
using System.ComponentModel;

public static class Utils 
{

	public static string GetDescription(Type type)
	{
		object[] attrs = type.GetCustomAttributes (true);
	
		if (attrs != null && attrs.Length > 0)
			return ((DescriptionAttribute)attrs[0]).Description;
		else
			return null;
	}
}
