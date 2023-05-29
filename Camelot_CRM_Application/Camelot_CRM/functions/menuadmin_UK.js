//Top Nav bar script v2.1- http://www.dynamicdrive.com/dynamicindex1/sm/index.htm

function showToolbar()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("properties", "Property", "Property",  null, null);
	menu.addItem("Inspections", "Inspections", "Inspections",  null, null);
	menu.addItem("pcontacts", "Property Contacts", "Property Contacts",  null, null);
	menu.addItem("guardians", "Guardians", "Guardians",  null, null);
	menu.addItem("applications", "Applications", "Applications",  null, null);
	menu.addItem("Incidents", "Incidents", "Incidents",  null, null);
	menu.addItem("Companies", "Company", "Company",  null, null);
	menu.addItem("ccontacts", "Company Contacts", "Company Contacts",  null, null);	
	menu.addItem("Correspondence", "Correspondence", "Correspondence",  "correspondence.aspx", "correspondence.aspx");	
	menu.addItem("reports", "Reports", "Reports",  null, null);
	menu.addItem("administration", "Administration", "Administration",  null, null);
	//menu.addItem("finance", "Finance", "Finance",  null, null);
	menu.addItem("databases", "Databases", "Databases",  "../database.aspx", null);
	//menu.addItem("Marketing", "Marketing", "Marketing",  null, null);
		
	//menu.addSubItem("finance", "Outstanding Invoices", "Outstanding Invoices",  "outstandinginvoices.aspx", "");
	//menu.addSubItem("finance", "Paid Invoices", "Paid Invoices",  "paidinvoices.aspx", "");
	
	menu.addSubItem("Companies", "Company Details", "Company Details",  "company.aspx", "");
	menu.addSubItem("Companies", "Company Notes", "Company Notes",  "companynotes.aspx", "");
		
	//menu.addSubItem("Marketing", "Email", "Email",  "", "");
	//menu.addSubItem("Marketing", "Newsletter", "Newsletter",  "", "");	
	
	menu.addSubItem("properties", "Property Details", "Property Details",  "property.aspx", "");
	menu.addSubItem("properties", "Facilities", "Facilities",  "property_facilities.aspx", "");
	menu.addSubItem("properties", "Securities", "Securities",  "property_securities.aspx", "");
	menu.addSubItem("properties", "Meters", "Meters",  "propertymeters.aspx", "");
	menu.addSubItem("properties", "Property Notes", "Property Notes",  "propertynotes.aspx", "");
	menu.addSubItem("properties", "Inspections", "Inspections",  "inspections.aspx", "");
	
	menu.addSubItem("Inspections", "Bulk Inspections", "Inspections",  "bulk_inspections.aspx", "");
	menu.addSubItem("Inspections", "Current Routes", "Inspections",  "activeroutes.aspx", "");
	menu.addSubItem("Inspections", "Old Routes", "Inspections",  "oldroutes.aspx", "");

	menu.addSubItem("pcontacts", "Property Contacts", "Property Contacts",  "propertycontacts.aspx", "");
	menu.addSubItem("pcontacts", "Property Contact History", "Property Contact History",  "propertycontacthistory.aspx", "");
	//menu.addSubItem("pcontacts", "Property Viewing", "Customer Viewing",  "", "");
	//menu.addSubItem("pcontacts", "Change Owner", "Change Owner",  "changeowner.aspx", "_blank");
	
	menu.addSubItem("guardians", "Pending Guardians", "Pending Guardians",  "propertyguardianspending.aspx", "");
	menu.addSubItem("guardians", "Existing Guardians", "Existing Guardians",  "propertyguardians.aspx", "");
	menu.addSubItem("guardians", "Previous Guardians", "Previous Guardian",  "propertyguardiansold.aspx", "");
	//menu.addSubItem("guardians", "Guardian Contact History", "Guardian Contact History",  "guardiancontacthistory.aspx", "");
	
	menu.addSubItem("applications", "Guardian Applications", "Guardian Applications",  "applications_UK.aspx", "");
	menu.addSubItem("applications", "Held Applications", "Held Applications",  "applicants_held_UK.aspx", "");
	menu.addSubItem("applications", "Placed Applications", "Placed Guardian Applications",  "placed_applicants_UK.aspx", "");
		
	menu.addSubItem("Incidents", "Open Property Incidents", "Open Property Incidents",  "property_incidents.aspx", "");
	menu.addSubItem("Incidents", "Resolved Property Incidents", "Resolved Property Incidents",  "property_rincidents.aspx", "");
	menu.addSubItem("Incidents", "All Open Incidents", "All Open Incidents",  "all_incidents.aspx", "");
	menu.addSubItem("Incidents", "All Resolved Incidents", "All Resolved Incidents",  "resolvedincidents.aspx", "");
	
	menu.addSubItem("ccontacts", "Company Contacts", "Company Contacts",  "companycontacts.aspx", "");
	menu.addSubItem("ccontacts", "Company Contact History", "Company Contact History",  "companycontacthistory.aspx", "");
	
	menu.addSubItem("reports", "Management Reports", "Management Reports", "reports.aspx", "")
	//menu.addSubItem("reports", "Outstanding Inspection Reports", "Outstanding Inspection Reports", "outinspreports.aspx", "")
	//menu.addSubItem("reports", "Completed Inspection Reports", "Completed Inspection Reports", "sentinspreports.aspx", "")
	
	menu.addSubItem("administration", "Merge Documents", "Merge Documents", "documents.aspx", "")
	menu.addSubItem("administration", "Employees", "Employees", "employees.aspx", "")
	
		
	menu.showMenu();
}
