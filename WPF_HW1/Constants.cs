using System;
using System.Collections.Generic;
using System.IO;
using WPF_HW1.Model;

namespace WPF_HW1
{
    static class Constants
    {
        // Folders, pathes
        private static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        internal static readonly string ClientDirPath = Path.Combine(AppData, "Clock");
        internal static readonly string ClientLogDirPath = Path.Combine(ClientDirPath, "Logs");
        internal static readonly string ClientDataDirPath = Path.Combine(ClientDirPath, "Data");

        //Log messages
        public static string NoItemSelected = "Tried to delete with no timeclock selected";
        public static string AddedNewTimeClock = "Added new time clock";
        public static string RemovedTimeClock = "Removed time clock";
        public static string EmptyRegister = "Tried to register with some fields left empty";
        public static string EmptyLogin = "Tried to login with some fields left empty";

        //Formats
        public static string DateTimeFormat = "yyyy_MM_dd HH_mm_ss";
        public static string TimeFormat = "HH:mm:ss";
        public static string DateFormat = "yyyy_MM_dd";


        public static List<string> TimeZonesNames = TimesZonesNamesFunc();
        private static List<string> TimesZonesNamesFunc()
        {
            List<string> names = new List<string>();
            names.Add("(UTC-11) American Samoa, Niue"); //- 11
            names.Add("(UTC-10) United States (Hawaii)");
            names.Add("(UTC-9) Gambier Islands");
            names.Add("(UTC-8) Los Angeles, Vancouver, Tijuana");
            names.Add("(UTC-7) Canada, Mexico, United States (Arizona)");
            names.Add("(UTC-6) Canada , Costa Rica, El Salvador, Ecuador");
            names.Add("(UTC-5) Colombia, Cuba, Ecuador (continental), Jamaica, Panama, Peru");
            names.Add("(UTC-4) Bolivia, Brazil (Amazonas), Chile , Dominican Republic");
            names.Add("(UTC-3) Argentina, Paraguay");
            names.Add("(UTC-2) Brazil, South Georgia and the South Sandwich Islands");
            names.Add("(UTC-1) Cape Verde");
            names.Add("(UTC+0) Côte d'Ivoire, Faroe Islands, Ghana, Iceland, Senegal");
            names.Add("(UTC+1) Algeria, Angola, Benin, Cameroon, Gabon, Niger, Nigeria");
            names.Add("(UTC+2) Egypt, Malawi, Mozambique, South Africa, Swaziland, Zambia, Zimbabwe");
            names.Add("(UTC+3) Belarus, Djibouti, Eritrea, Ethiopia, Iraq, Kenya, Madagascar, Russia");
            names.Add("(UTC+4) Armenia, Azerbaijan, Georgia, Mauritius, Oman, Russia");
            names.Add("(UTC+5) Kazakhstan (west), Maldives, Pakistan, Uzbekistan");
            names.Add("(UTC+6) Kazakhstan (most), Bangladesh, Bhutan, Russia");
            names.Add("(UTC+7) Western Indonesia, Russia (Novosibirsk Oblast), Thailand, Vietnam, Cambodia");
            names.Add("(UTC+8) Hong Kong, Central Indonesia, China, Russia");
            names.Add("(UTC+9) Eastern Indonesia, East Timor, Russia (Irkutsk Oblast), Japan, North Korea,");
            names.Add("(UTC+10) Russia (Zabaykalsky Krai), Papua New Guinea, Australia (Queensland)");
            names.Add("(UTC+11) New Caledonia, Russia (Primorsky Krai), Solomon Islands");
            names.Add("(UTC+12) Kiribati (Gilbert Islands), Fiji, Russia (Kamchatka Krai)"); //+12
            return names;
        }

       
        
    }
}
