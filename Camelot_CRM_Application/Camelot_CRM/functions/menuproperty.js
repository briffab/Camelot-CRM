//Top Nav bar script v2.1- http://www.dynamicdrive.com/dynamicindex1/sm/index.htm

function showToolbar()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("properties", "Property", "Property",  null, null);
	menu.addItem("pcontacts", "Property Contacts", "Property Contacts",  null, null);
	menu.addItem("guardians", "Guardians", "Guardians",  null, null);
	//menu.addItem("Incidents", "Incidents", "Incidents",  null, null);
	//menu.addItem("Companies", "Company", "Company",  null, null);
	//menu.addItem("ccontacts", "Company Contacts", "Company Contacts",  null, null);
	//menu.addItem("Marketing", "Marketing", "Marketing",  null, null);
	
	//menu.addSubItem("Companies", "Company Details", "Company Details",  "company.aspx", "");
	//menu.addSubItem("Companies", "Company Notes", "Company Notes",  "companynotes.aspx", "");
		
	//menu.addSubItem("Marketing", "Email", "Email",  "", "");
	//menu.addSubItem("Marketing", "Newsletter", "Newsletter",  "", "");	
	
	menu.addSubItem("properties", "Property Details", "Property Details",  "property.aspx", "");
	menu.addSubItem("properties", "Facilities", "Facilities",  "property_facilities.aspx", "");
	menu.addSubItem("properties", "Meters", "Meters",  "propertymeters.aspx", "");
	//menu.addSubItem("properties", "Control Check", "Control Check",  "", "");
	//menu.addSubItem("properties", "Photos", "Photos",  "", "");

	menu.addSubItem("pcontacts", "Property Contacts", "Property Contacts",  "propertycontacts.aspx", "");
	menu.addSubItem("pcontacts", "Property Contact History", "Property Contact History",  "propertycontacthistory.aspx", "");
	//menu.addSubItem("pcontacts", "Property Viewing", "Customer Viewing",  "", "");
	//menu.addSubItem("pcontacts", "Change Owner", "Change Owner",  "", "");
	
	menu.addSubItem("guardians", "Existing Guardians", "Existing Guardians",  "propertyguardians.aspx", "");
	menu.addSubItem("guardians", "Previous Guardians", "Previous Guardian",  "propertyguardiansold.aspx", "");
	//menu.addSubItem("guardians", "Guardians waiting", "Guardians waiting",  "", "");
		
	//menu.addSubItem("Incidents", "Open Incidents", "Open Incidents",  "", "");
	//menu.addSubItem("Incidents", "Resolved Incidents", "Resolved Incidents",  "", "");
	
	//menu.addSubItem("ccontacts", "Company Contacts", "Company Contacts",  "companycontacts.aspx", "");
	//menu.addSubItem("ccontacts", "Company Contact History", "Company Contact History",  "companycontacthistory.aspx", "");
	
	
		
	menu.showMenu();
}
