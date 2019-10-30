namespace SeleniumTest
{
    public class MultiUserCreationTest
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 20; i++)
            {
                //create a new user                
                AddNewUserTest test1 = new AddNewUserTest();
                test1.startBimTrack();
            }
        }

    }
}