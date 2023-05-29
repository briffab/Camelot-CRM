//Top Nav bar script v2.1- http://www.dynamicdrive.com/dynamicindex1/sm/index.htm

function showToolbar()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Companies", "Company", "Company",  null, null);
	menu.addItem("contacts", "Contacts", "Contacts",  null, null);
	menu.addItem("Properties", "Properties", "Properties",  null, null);
	menu.addItem("Marketing", "Marketing", "Marketing",  null, null);
	
	menu.addSubItem("Companies", "Company Details", "Company Details",  "", "");
	menu.addSubItem("Companies", "Company Notes", "Company Notes",  "", "");
	
	menu.addSubItem("Properties", "Properties Under Management", "Properties Under Management",  "", "");
	menu.addSubItem("Properties", "Prospective Properties", "Prospective Properties",  "", "");
	menu.addSubItem("Properties", "Past Properties", "Past Properties",  "", "");

	menu.addSubItem("contacts", "Customer Contacts", "Customer Contacts",  "", "");
	menu.addSubItem("contacts", "Customer Contact History", "Customer Contact History",  "", "");
	menu.addSubItem("contacts", "Customer Viewing", "Customer Viewing",  "", "");
	
	menu.addSubItem("Marketing", "Email", "Email",  "", "");
	menu.addSubItem("Marketing", "Newsletter", "Newsletter",  "", "");
	
	
	menu.showMenu();
}
