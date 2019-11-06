using System;

namespace SeleniumTest
{
    public class MultiUserCreationTest
    {
        
        public static void ADD_MULTIPLE(string[] args)
        {
            Console.Out.WriteLine("START ---> " + DateTime.Now.ToString("MMdd_hhmmss"));
            for (int i = 0; i < 39; i++)
            {
                //create a new user                
                AddNewUserTest test1 = new AddNewUserTest();
                test1.startBimTrack();
            }
            Console.Out.WriteLine("END ---> " + DateTime.Now.ToString("MMdd_hhmmss"));
        }

        public static void DELETE_ALL(string[] args)
        {
            var removeAll = new RemoveAllUsersTest();
            removeAll.RemoveAllUsers();
        }

        public static void Main(string[] args)
        {
            MultiUserCreationTest.ADD_MULTIPLE(args);
        }

    }
}