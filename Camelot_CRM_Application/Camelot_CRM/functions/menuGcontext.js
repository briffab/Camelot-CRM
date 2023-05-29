//Top Nav bar script v2.1- http://www.dynamicdrive.com/dynamicindex1/sm/index.htm

function showToolbar()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("guardians", "Guardians", "Guardians",  null, null);
	menu.addItem("Marketing", "Marketing", "Marketing",  null, null);	
	
	menu.addSubItem("guardians", "Guardian Details", "Guardian Details",  "", "");
	menu.addSubItem("guardians", "Contact History", "Customer Contact History",  "", "");
	menu.addSubItem("guardians", "Properties", "Properties",  "", "");
	menu.addSubItem("guardians", "Facilities", "Facilities",  "", "");
	
	menu.addSubItem("Marketing", "Email", "Email",  "", "");
	menu.addSubItem("Marketing", "Newsletter", "Newsletter",  "", "");
	
	menu.showMenu();
}