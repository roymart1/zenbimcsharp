namespace SeleniumTest.PageObjects.ScreenDecorator
{
    public class MainWindowDecorator
    {
        private SideBarMenu sidebar = null;

        public SideBarMenu GetSidebarMenu()
        {
            return sidebar = new SideBarMenu();
        }
    }
}