namespace GSMCallHistoryTest
{
    using System;
    using System.Text;
    using GSM;

    public class GSMCallHistoryTest
    {
        public static void Main()
        {
            GSM myGSM = new GSM(
                    "Asha 205 ",
                    "Nokia",
                    "Nikolay Kostadinov",
                    120m,
                    "Nokia",
                    200,
                    10,
                    4,
                    65000u);
            
            Random rnd = new Random();
            
            for (int i = 1; i < 50; i++)
            {
                Call call = new Call("+359886630111", (uint)rnd.Next(45, 200));
                myGSM.AddCall(call);
            }

            DisplayCallHistory(myGSM);
            Console.ReadKey();
            DeleteMaxDurationCall(myGSM);
            DisplayCallHistory(myGSM);
        }
  
        private static void DeleteMaxDurationCall(GSM myGSM)
        {
            Call maxCallDuration = myGSM.CallHistory[0];

            foreach (Call call in myGSM.CallHistory)
            {
                if (maxCallDuration.Duration < call.Duration)
                {
                    maxCallDuration = call;
                }
            }

            myGSM.DeleteCall(maxCallDuration);
        }

        private static void DisplayCallHistory(GSM myGSM)
        {
            StringBuilder sb = new StringBuilder(); 
            Console.WriteLine("{0,25}{1,25}{2,20}", "Begin of call", "Dialed Phone Number", "Call Duration /s/");
            Console.WriteLine(new string('_', 70));
            foreach (Call call in myGSM.CallHistory)
            {
                sb.Append(call.ToString() + '\n');                
            }

            Console.WriteLine(sb);
            Console.WriteLine(new string('_', 70));
            Console.WriteLine(
                "{0,25}{1,25}{2,16} min", 
                "Total duration of calls: ", 
                string.Empty, 
                myGSM.CalculateCallsDuration());
            
            Console.WriteLine(
                "{0,25}{1,25}{2,20:C}", 
                "Total price of calls: ", 
                string.Empty, 
                myGSM.CalculateTotalPriceOfCalls(0.37m));
        }
    }
}
