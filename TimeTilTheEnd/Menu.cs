using System;
using System.Collections.Generic;


namespace TimeTilTheEnd
{
    class Menu
    {
        static Logic timer = new Logic();

        public Menu()
        {
            
        }
        
        public void InitialConfig(string option)
        {
            switch (option)
            {
                case "1":
                    ChangingTimeLeft();
                    break;
                case "2":
                    ChangingDaysSurvived();
                    break;
                default:
                    DefaultSetting();
                    break;
            }
        }
        
        private void ChangingTimeLeft()
        {
            string b = "13:00:00";
            
            try
            {
                DateTime.Parse(b);

                
                Console.WriteLine(a.MondayToThusday);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private void ChangingDaysSurvived()
        {

        }

        public void DefaultSetting()
        {
            //a.MondayToThusday = "16:00:00";
            //a.Friday = "13:00:00";
        }
    }
}
