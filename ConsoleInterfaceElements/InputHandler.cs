using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterfaceElements
{
	static public class InputHandler
	{
		static public bool SetIfCompatibleTypes<T>(ref T field, object value)
		{
			object newValue = null;
			try
			{
				newValue = (T)Convert.ChangeType(value, typeof(T));
			}
			catch
			{
				ThrowUncompatibleFieldTypeException();
			}

			if (newValue != null)
			{
				field = (T)newValue;
				return true;
			}
			else
			{
				return false;
			}
		}
		static public void ThrowUncompatibleFieldTypeException()
		{
			throw new Exception("Wprowadzono dane ktore nie moga byc zapisane w polu tego typu.");
		}
	}
}
