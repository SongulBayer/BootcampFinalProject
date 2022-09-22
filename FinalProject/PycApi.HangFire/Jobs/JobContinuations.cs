using System;

namespace PycApi.HangFire
{
    public static class JobContinuations
    {
        public static string Run()
        {
            Console.WriteLine("JobContinuations");
            return "JobContinuations";
        }
    }
}
