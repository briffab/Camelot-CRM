//Top Nav bar script v2.1- http://www.dynamicdrive.com/dynamicindex1/sm/index.htm

function showToolbar()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("properties", "Property", "Property",  null, null);
	menu.addItem("contacts", "Contacts", "Contacts",  null, null);
	menu.addItem("guardians", "Guardians", "Guardians",  null, null);
	menu.addItem("Incidents", "Incidents", "Incidents",  null, null);	
	
	menu.addSubItem("properties", "Property Details", "Property Details",  "property.aspx", "");
	menu.addSubItem("properties", "Facilities", "Facilities",  "property_facilities.aspx", "");
	menu.addSubItem("properties", "Meters", "Meters",  "propertymeters.aspx", "");
	menu.addSubItem("properties", "Control Check", "Control Check",  "", "");
	menu.addSubItem("properties", "Photos", "Photos",  "", "");
	menu.addSubItem("properties", "Gifts", "Gifts",  "", "");

	menu.addSubItem("contacts", "Customer Contacts", "Customer Contacts",  "", "");
	menu.addSubItem("contacts", "Customer Contact History", "Customer Contact History",  "", "");
	menu.addSubItem("contacts", "Customer Viewing", "Customer Viewing",  "", "");
	menu.addSubItem("contacts", "Change Owner", "Change Owner",  "", "");
	
	menu.addSubItem("guardians", "Existing Guardians", "Existing Guardians",  "", "");
	menu.addSubItem("guardians", "Previous Guardians", "Previous Guardian",  "", "");
	menu.addSubItem("guardians", "Guardians waiting", "Guardians waiting",  "", "");
		
	menu.addSubItem("Incidents", "Open Incidents", "Open Incidents",  "", "");
	menu.addSubItem("Incidents", "Resolved Incidents", "Resolved Incidents",  "", "");
		
	menu.showMenu();
}