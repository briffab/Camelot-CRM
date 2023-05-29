using System;

namespace Camelot.classes
{
	/// <summary>
	/// Summary description for Employees.
	/// </summary>
	public class Employees : System.Collections.CollectionBase
	{
		
		public void Add(Employee emp)
		{
			List.Add(emp);
		}

		public Employee Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (Employee) List[Index];
		}

	}
}
