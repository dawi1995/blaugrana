using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blaugrana.Models
{
    public class FieldInformation
    {
        public int F_Id { get; set; }
        public string F_Name { get; set; }
        public Nullable<int> F_IdAddress { get; set; }
        public string F_Light { get; set; }
        public string F_Rental { get; set; }
        public string F_BookingPossibility { get; set; }
        public string F_PhotoPath { get; set; }
        public string A_City { get; set; }
        public string A_District { get; set; }
        public string A_Street { get; set; }
        public Nullable<int> A_Number { get; set; }
        public string A_ZipCode { get; set; }
        public string FI_Mon { get; set; }
        public string FI_Tues { get; set; }
        public string FI_Wed { get; set; }
        public string FI_Thurs { get; set; }
        public string FI_Fri { get; set; }
        public string FI_Sat { get; set; }
        public string FI_Sun { get; set; }
        public string FI_OpenDays { get; set; }

        public FieldInformation()
        {

        }
        public FieldInformation(Field field, Address address, OpenDaysHour openDaysHour)
        {
            F_Id = field.F_Id;
            F_Name = field.F_Name;
            F_IdAddress = field.F_IdAddress;
            F_PhotoPath = field.F_PhotoPath == null ? "../../Resources/Images/noCamera.jpg" : field.F_PhotoPath;

            if (field.F_Light.Value)
                F_Light = "TAK";
            else
                F_Light = "NIE";

            if (field.F_Rental.Value)
                F_Rental = "TAK";
            else
                F_Rental = "NIE";

            if (field.F_BookingPossibility.Value)
                F_BookingPossibility = "TAK";
            else
                F_BookingPossibility = "NIE";

            A_City = address.A_City;
            A_District = address.A_District;
            A_Street = address.A_Street;
            A_Number = address.A_Number;
            A_ZipCode = address.A_ZipCode;
            if (!openDaysHour.ODH_MonFrom.HasValue || !openDaysHour.ODH_MonTo.HasValue)
                FI_Mon = "nieczynne";
            else
            {
                string MonHourFrom = openDaysHour.ODH_MonFrom.Value.Hours.ToString().Length<2?"0"+ openDaysHour.ODH_MonFrom.Value.Hours.ToString(): openDaysHour.ODH_MonFrom.Value.Hours.ToString();
                string MonMinFrom = openDaysHour.ODH_MonFrom.Value.Minutes.ToString().Length<2?"0"+ openDaysHour.ODH_MonFrom.Value.Minutes.ToString(): openDaysHour.ODH_MonFrom.Value.Minutes.ToString();
                string MonHourTo = openDaysHour.ODH_MonTo.Value.Hours.ToString().Length<2?"0"+ openDaysHour.ODH_MonTo.Value.Hours.ToString(): openDaysHour.ODH_MonTo.Value.Hours.ToString();
                string MonMinTo = openDaysHour.ODH_MonTo.Value.Minutes.ToString().Length<2?"0"+ openDaysHour.ODH_MonTo.Value.Minutes.ToString(): openDaysHour.ODH_MonTo.Value.Minutes.ToString();

                FI_Mon = MonHourFrom + ":" + MonMinFrom + " - " + MonHourTo + ":" + MonMinTo;
            }
                

            if (!openDaysHour.ODH_TuesFrom.HasValue || !openDaysHour.ODH_TuesTo.HasValue)
                FI_Tues = "nieczynne";
            else
            {
                string TuesHourFrom = openDaysHour.ODH_TuesFrom.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_TuesFrom.Value.Hours.ToString() : openDaysHour.ODH_TuesFrom.Value.Hours.ToString();
                string TuesMinFrom = openDaysHour.ODH_TuesFrom.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_TuesFrom.Value.Minutes.ToString() : openDaysHour.ODH_TuesFrom.Value.Minutes.ToString();
                string TuesHourTo = openDaysHour.ODH_TuesTo.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_TuesTo.Value.Hours.ToString() : openDaysHour.ODH_TuesTo.Value.Hours.ToString();
                string TuesMinTo = openDaysHour.ODH_TuesTo.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_TuesTo.Value.Minutes.ToString() : openDaysHour.ODH_TuesTo.Value.Minutes.ToString();

                FI_Tues = TuesHourFrom + ":" + TuesMinFrom + " - " + TuesHourTo + ":" + TuesMinTo;
            }

            if (!openDaysHour.ODH_WedFrom.HasValue || !openDaysHour.ODH_WedTo.HasValue)
                FI_Wed = "nieczynne";
            else
            {
                string WedHourFrom = openDaysHour.ODH_WedFrom.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_WedFrom.Value.Hours.ToString() : openDaysHour.ODH_WedFrom.Value.Hours.ToString();
                string WedMinFrom = openDaysHour.ODH_WedFrom.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_WedFrom.Value.Minutes.ToString() : openDaysHour.ODH_WedFrom.Value.Minutes.ToString();
                string WedHourTo = openDaysHour.ODH_WedTo.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_WedTo.Value.Hours.ToString() : openDaysHour.ODH_WedTo.Value.Hours.ToString();
                string WedMinTo = openDaysHour.ODH_WedTo.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_WedTo.Value.Minutes.ToString() : openDaysHour.ODH_WedTo.Value.Minutes.ToString();

                FI_Wed = WedHourFrom + ":" + WedMinFrom + " - " + WedHourTo + ":" + WedMinTo;
            }               

            if (!openDaysHour.ODH_ThursFrom.HasValue || !openDaysHour.ODH_ThursTo.HasValue)
                FI_Thurs = "nieczynne";
            else
            {
                string ThursHourFrom = openDaysHour.ODH_ThursFrom.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_ThursFrom.Value.Hours.ToString() : openDaysHour.ODH_ThursFrom.Value.Hours.ToString();
                string ThursMinFrom = openDaysHour.ODH_ThursFrom.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_ThursFrom.Value.Minutes.ToString() : openDaysHour.ODH_ThursFrom.Value.Minutes.ToString();
                string ThursHourTo = openDaysHour.ODH_ThursTo.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_ThursTo.Value.Hours.ToString() : openDaysHour.ODH_ThursTo.Value.Hours.ToString();
                string ThursMinTo = openDaysHour.ODH_ThursTo.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_ThursTo.Value.Minutes.ToString() : openDaysHour.ODH_ThursTo.Value.Minutes.ToString();

                FI_Thurs = ThursHourFrom + ":" + ThursMinFrom + " - " + ThursHourTo + ":" + ThursMinTo;
            }
               

            if (!openDaysHour.ODH_FriFrom.HasValue || !openDaysHour.ODH_FriTo.HasValue)
                FI_Fri = "nieczynne";
            else
            {
                string FrisHourFrom = openDaysHour.ODH_FriFrom.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_FriFrom.Value.Hours.ToString() : openDaysHour.ODH_FriFrom.Value.Hours.ToString();
                string FriMinFrom = openDaysHour.ODH_FriFrom.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_FriFrom.Value.Minutes.ToString() : openDaysHour.ODH_FriFrom.Value.Minutes.ToString();
                string FriHourTo = openDaysHour.ODH_FriTo.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_FriTo.Value.Hours.ToString() : openDaysHour.ODH_FriTo.Value.Hours.ToString();
                string FriMinTo = openDaysHour.ODH_FriTo.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_FriTo.Value.Minutes.ToString() : openDaysHour.ODH_FriTo.Value.Minutes.ToString();

                FI_Fri = FrisHourFrom + ":" + FriMinFrom + " - " + FriHourTo + ":" + FriMinTo;
            }
                

            if (!openDaysHour.ODH_SatFrom.HasValue || !openDaysHour.ODH_SatTo.HasValue)
                FI_Sat = "nieczynne";
            else
            {
                string SatHourFrom = openDaysHour.ODH_SatFrom.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_SatFrom.Value.Hours.ToString() : openDaysHour.ODH_SatFrom.Value.Hours.ToString();
                string SatMinFrom = openDaysHour.ODH_SatFrom.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_SatFrom.Value.Minutes.ToString() : openDaysHour.ODH_SatFrom.Value.Minutes.ToString();
                string SatHourTo = openDaysHour.ODH_SatTo.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_SatTo.Value.Hours.ToString() : openDaysHour.ODH_SatTo.Value.Hours.ToString();
                string SatMinTo = openDaysHour.ODH_SatTo.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_SatTo.Value.Minutes.ToString() : openDaysHour.ODH_SatTo.Value.Minutes.ToString();

                FI_Sat = SatHourFrom + ":" + SatMinFrom + " - " + SatHourTo + ":" + SatMinTo;
            }
                

            if (!openDaysHour.ODH_SunFrom.HasValue || !openDaysHour.ODH_SunTo.HasValue)
                FI_Sun = "nieczynne";
            else
            {
                string SunHourFrom = openDaysHour.ODH_SunFrom.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_SunFrom.Value.Hours.ToString() : openDaysHour.ODH_SunFrom.Value.Hours.ToString();
                string SunMinFrom = openDaysHour.ODH_SunFrom.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_SunFrom.Value.Minutes.ToString() : openDaysHour.ODH_SunFrom.Value.Minutes.ToString();
                string SunHourTo = openDaysHour.ODH_SunTo.Value.Hours.ToString().Length < 2 ? "0" + openDaysHour.ODH_SunTo.Value.Hours.ToString() : openDaysHour.ODH_SunTo.Value.Hours.ToString();
                string SunMinTo = openDaysHour.ODH_SunTo.Value.Minutes.ToString().Length < 2 ? "0" + openDaysHour.ODH_SunTo.Value.Minutes.ToString() : openDaysHour.ODH_SunTo.Value.Minutes.ToString();

                FI_Sun = SunHourFrom + ":" + SunMinFrom + " - " + SunHourTo + ":" + SunMinTo;
            }
                


            //Open days
            if (FI_Mon != "nieczynne")
            {
                FI_OpenDays += "Pn ";
            }
            if (FI_Tues != "nieczynne")
            {
                FI_OpenDays += "Wt ";
            }
            if (FI_Wed != "nieczynne")
            {
                FI_OpenDays += "Śr ";
            }
            if (FI_Thurs != "nieczynne")
            {
                FI_OpenDays += "Czw ";
            }
            if (FI_Fri != "nieczynne")
            {
                FI_OpenDays += "Pt ";
            }
            if (FI_Sat != "nieczynne")
            {
                FI_OpenDays += "Sb ";
            }
            if (FI_Sun != "nieczynne")
            {
                FI_OpenDays += "Nd ";
            }
        }
    }
}