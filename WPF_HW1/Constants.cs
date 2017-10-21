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

        public static List<TimeClock> TimeZones = TimeZonesFunc();

        private static List<TimeClock> TimeZonesFunc()
        {
            List<TimeClock> timeZones = new List<TimeClock>();
            timeZones.Add(new TimeClock(-11, "American Samoa, Niue"));
            timeZones.Add(new TimeClock(-10, "United States (Hawaii)"));
            timeZones.Add(new TimeClock(-9, "Gambier Islands"));
            timeZones.Add(new TimeClock(-8, "Los Angeles, Vancouver, Tijuana"));
            timeZones.Add(new TimeClock(-7, "Canada, Mexico, United States (Arizona)"));
            timeZones.Add(new TimeClock(-6, "Canada , Costa Rica, El Salvador, Ecuador"));
            timeZones.Add(new TimeClock(-5, "Colombia, Cuba, Ecuador (continental), Jamaica, Panama, Peru"));
            timeZones.Add(new TimeClock(-4, "Bolivia, Brazil (Amazonas), Chile , Dominican Republic"));
            timeZones.Add(new TimeClock(-3, "Argentina, Paraguay"));
            timeZones.Add(new TimeClock(-2, "Brazil, South Georgia and the South Sandwich Islands"));
            timeZones.Add(new TimeClock(-1, "Cape Verde"));
            timeZones.Add(new TimeClock(0, "Côte d'Ivoire, Faroe Islands, Ghana, Iceland, Senegal"));
            timeZones.Add(new TimeClock(+1, "Algeria, Angola, Benin, Cameroon, Gabon, Niger, Nigeria"));
            timeZones.Add(new TimeClock(+2, "Egypt, Malawi, Mozambique, South Africa, Swaziland, Zambia, Zimbabwe"));
            timeZones.Add(new TimeClock(+3, "Belarus, Djibouti, Eritrea, Ethiopia, Iraq, Kenya, Madagascar, Russia"));
            timeZones.Add(new TimeClock(+4, "Armenia, Azerbaijan, Georgia, Mauritius, Oman, Russia"));
            timeZones.Add(new TimeClock(+5, "Kazakhstan (west), Maldives, Pakistan, Uzbekistan	"));
            timeZones.Add(new TimeClock(+6, "Kazakhstan (most), Bangladesh, Bhutan, Russia"));
            timeZones.Add(new TimeClock(+7, "Western Indonesia, Russia (Novosibirsk Oblast), Thailand, Vietnam, Cambodia"));
            timeZones.Add(new TimeClock(+8, "Hong Kong, Central Indonesia, China, Russia "));
            timeZones.Add(new TimeClock(+9, "Eastern Indonesia, East Timor, Russia (Irkutsk Oblast), Japan, North Korea,"));
            timeZones.Add(new TimeClock(+10, "Russia (Zabaykalsky Krai), Papua New Guinea, Australia (Queensland)"));
            timeZones.Add(new TimeClock(+11, "New Caledonia, Russia (Primorsky Krai), Solomon Islands	"));
            timeZones.Add(new TimeClock(+12, "Kiribati (Gilbert Islands), Fiji, Russia (Kamchatka Krai)"));
            return timeZones;
        }
        
    }
}
