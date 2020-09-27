using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Helpers
{
    public class Constants
    {
        public static double[] Level_fractions = { 0.05, 0.04, 0.03, 0.02, 0.01, 0.005, 0.0025};
        public static int[] Level_Contributors = { 3, 9, 27, 81, 243, 729, 2187 };
        public static int[] Level_Contributors2 = { 3, 12, 39, 120, 363, 1092, 3279 };
        public static int[] Entitlement_Pishon = { 1500, 3500, 7500, 10400, 15000, 25000, 50000};
        public static List<string> Streams = new List<string>
        {
            "PISHON STREAM",
            "GIHON STREAM",
            "HIDDEKEL STREAM",
            "EUPHRATES STREAM",
            "LAND OF SILVER AND GOLD STREAM"
        };

        public static List<int> LevelCounts = new List<int>{7, 8, 9, 10, 11};

        public static double[] Level_fractions_GIHON = { 0.04, 0.03, 0.02, 0.01, 0.005, 0.0025, 0.00125, 0.0006 };
        public static double[] Level_Contributors_GIHON = { 3, 9, 27, 81, 243, 729, 2187, 6561 };

        public static double CompanyFractionShare = 0.7725;
        public static double UpLinersFractionShare = 0.1575;
        public static double LogisticsFractionShare = 0.02;
        public static double SoftDevTechFractionShare = 0.05;
        public static double ContibutionAmount = 10000;
        public static double RegistrationAmount = 2000;
        public static string PaymentSuccessful = "success";
        public static string PaymentFailed = "failed";
        public static int nPishon = 3280;
        public static int nGihon = 9841;
        public static string REFUGEE_CENTER = "REFUGEE CENTER";
        public static string PISHON = "PISHON STREAM";
        public static string PISHON_REFUGEE_CENTER = "PISHON REFUGEE CENTER";
        public static string GIHON = "GIHON STREAM";
        public static string paystackkey = "pk_live_5bd6919a85c60cc0d682061c08fd987fff5dc963";
        
        //Test Keys
        //sk_test_f36d437f174c2de153f5f94ddfdc1b628038b3c8
        //pk_test_6a4ff4675a6210e463f5ca124a3b15aaac493e60,

        //Live Keys
        //pk_live_5bd6919a85c60cc0d682061c08fd987fff5dc963
        //sk_live_fa837444b2209924e80c861e6d52757ef6be6b36
    }
}
