//Top Nav bar script v2.1- http://www.dynamicdrive.com/dynamicindex1/sm/index.htm

function showToolbar()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Invoices", "Invoices", "Invoices",  null, null);
	menu.addItem("Guardians", "Guardians", "Guardians",  null, null);
	
	menu.addSubItem("Invoices", "Outstanding Invoices", "Outstanding Invoices",  "", "");
	menu.addSubItem("Invoices", "Paid Invoices", "Paid Invoices",  "", "");
	
	menu.addSubItem("Guardians", "Guradians Payments", "Guardians Payments",  "", "");
	menu.addSubItem("Guardians", "Import DD file", "Import DD File",  "", "");
	menu.addSubItem("Guardians", "Export DD File", "Export DD File",  "", "");

	menu.showMenu();
}

