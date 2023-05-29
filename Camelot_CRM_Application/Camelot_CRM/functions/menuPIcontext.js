//Top Nav bar script v2.1- http://www.dynamicdrive.com/dynamicindex1/sm/index.htm

function showToolbar()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Routes", "Routes", "Routes",  null, null);
	menu.addItem("Reports", "Reports", "Reports",  null, null);
	
	menu.addSubItem("Routes", "Route List", "Route List",  "", "");
	
	menu.addSubItem("Reports", "Reports for checking", "Reports for checking",  "", "");
	
	menu.showMenu();
}

