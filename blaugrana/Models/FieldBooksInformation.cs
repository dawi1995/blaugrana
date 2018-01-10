using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blaugrana.Models
{
    public class FieldBooksInformation
   {
        public int F_Id { get; set; }
        public string F_Name { get; set; }
        public Nullable<System.TimeSpan> BO_MonFrom { get; set; }
        public Nullable<System.TimeSpan> BO_MonTo { get; set; }
        public Nullable<System.TimeSpan> BO_TuesFrom { get; set; }
        public Nullable<System.TimeSpan> BO_TuesTo { get; set; }
        public Nullable<System.TimeSpan> BO_WedFrom { get; set; }
        public Nullable<System.TimeSpan> BO_WedTo { get; set; }
        public Nullable<System.TimeSpan> BO_ThursFrom { get; set; }
        public Nullable<System.TimeSpan> BO_ThursTo { get; set; }
        public Nullable<System.TimeSpan> BO_FriFrom { get; set; }
        public Nullable<System.TimeSpan> BO_FriTo { get; set; }
        public Nullable<System.TimeSpan> BO_SatFrom { get; set; }
        public Nullable<System.TimeSpan> BO_SatTo { get; set; }
        public Nullable<System.TimeSpan> BO_SunFrom { get; set; }
        public Nullable<System.TimeSpan> BO_SunTo { get; set; }
        public Nullable<int> BO_MaxHourBook { get; set; }
        public string FBI_Mon { get; set; }
        public string FBI_Tues { get; set; }
        public string FBI_Wed { get; set; }
        public string FBI_Thurs { get; set; }
        public string FBI_Fri { get; set; }
        public string FBI_Sat { get; set; }
        public string FBI_Sun { get; set; }
        public List<BookInformation> FBI_Books { get; set; }
        
        //Other Informations
        public bool? FBI_IfGoodValidation { get; set; }
        public string FBI_TextValidation { get; set; }
        public bool FBI_NeedValidate { get; set; }

        public FieldBooksInformation()
        {

        }
        public FieldBooksInformation(Field field, BookingOption bookingOption, List<Book> listOfBooks)
        {
            List <BookInformation> listOfBookInformation= new List<BookInformation>();
            for (int i = 0; i < listOfBooks.Count; i++)
            {
                listOfBookInformation.Add(new BookInformation(listOfBooks[i]));
            }
            
            F_Id = field.F_Id;
            F_Name = field.F_Name;
            BO_MonFrom = bookingOption.BO_MonFrom;
            BO_MonTo = bookingOption.BO_MonTo;
            BO_TuesFrom = bookingOption.BO_TuesFrom;
            BO_TuesTo = bookingOption.BO_TuesTo;
            BO_WedFrom = bookingOption.BO_WedFrom;
            BO_WedTo = bookingOption.BO_WedTo;
            BO_ThursFrom = bookingOption.BO_ThursFrom;
            BO_ThursTo = bookingOption.BO_ThursTo;
            BO_FriFrom = bookingOption.BO_FriFrom;
            BO_FriTo = bookingOption.BO_FriTo;
            BO_SatFrom = bookingOption.BO_SatFrom;
            BO_SatTo = bookingOption.BO_SatTo;
            BO_SunFrom = bookingOption.BO_SunFrom;
            BO_SunTo = bookingOption.BO_SunTo;
            BO_MaxHourBook = bookingOption.BO_MaxHourBook;
            FBI_Books = listOfBookInformation;

            FBI_IfGoodValidation = null;
            FBI_TextValidation = "";


            if (!bookingOption.BO_MonFrom.HasValue || !bookingOption.BO_MonTo.HasValue)
                FBI_Mon = "brak możliwości rezerwacji";
            else
            {
                string MonHourFrom = bookingOption.BO_MonFrom.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_MonFrom.Value.Hours.ToString() : bookingOption.BO_MonFrom.Value.Hours.ToString();
                string MonMinFrom = bookingOption.BO_MonFrom.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_MonFrom.Value.Minutes.ToString() : bookingOption.BO_MonFrom.Value.Minutes.ToString();
                string MonHourTo = bookingOption.BO_MonTo.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_MonTo.Value.Hours.ToString() : bookingOption.BO_MonTo.Value.Hours.ToString();
                string MonMinTo = bookingOption.BO_MonTo.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_MonTo.Value.Minutes.ToString() : bookingOption.BO_MonTo.Value.Minutes.ToString();

                FBI_Mon = MonHourFrom + ":" + MonMinFrom + " - " + MonHourTo + ":" + MonMinTo;
            }


            if (!bookingOption.BO_TuesFrom.HasValue || !bookingOption.BO_TuesTo.HasValue)
                FBI_Tues = "brak możliwości rezerwacji";
            else
            {
                string TuesHourFrom = bookingOption.BO_TuesFrom.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_TuesFrom.Value.Hours.ToString() : bookingOption.BO_TuesFrom.Value.Hours.ToString();
                string TuesMinFrom = bookingOption.BO_TuesFrom.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_TuesFrom.Value.Minutes.ToString() : bookingOption.BO_TuesFrom.Value.Minutes.ToString();
                string TuesHourTo = bookingOption.BO_TuesTo.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_TuesTo.Value.Hours.ToString() : bookingOption.BO_TuesTo.Value.Hours.ToString();
                string TuesMinTo = bookingOption.BO_TuesTo.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_TuesTo.Value.Minutes.ToString() : bookingOption.BO_TuesTo.Value.Minutes.ToString();

                FBI_Tues = TuesHourFrom + ":" + TuesMinFrom + " - " + TuesHourTo + ":" + TuesMinTo;
            }

            if (!bookingOption.BO_WedFrom.HasValue || !bookingOption.BO_WedTo.HasValue)
                FBI_Wed = "brak możliwości rezerwacji";
            else
            {
                string WedHourFrom = bookingOption.BO_WedFrom.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_WedFrom.Value.Hours.ToString() : bookingOption.BO_WedFrom.Value.Hours.ToString();
                string WedMinFrom = bookingOption.BO_WedFrom.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_WedFrom.Value.Minutes.ToString() : bookingOption.BO_WedFrom.Value.Minutes.ToString();
                string WedHourTo = bookingOption.BO_WedTo.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_WedTo.Value.Hours.ToString() : bookingOption.BO_WedTo.Value.Hours.ToString();
                string WedMinTo = bookingOption.BO_WedTo.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_WedTo.Value.Minutes.ToString() : bookingOption.BO_WedTo.Value.Minutes.ToString();

                FBI_Wed = WedHourFrom + ":" + WedMinFrom + " - " + WedHourTo + ":" + WedMinTo;
            }

            if (!bookingOption.BO_ThursFrom.HasValue || !bookingOption.BO_ThursTo.HasValue)
                FBI_Thurs = "brak możliwości rezerwacji";
            else
            {
                string ThursHourFrom = bookingOption.BO_ThursFrom.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_ThursFrom.Value.Hours.ToString() : bookingOption.BO_ThursFrom.Value.Hours.ToString();
                string ThursMinFrom = bookingOption.BO_ThursFrom.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_ThursFrom.Value.Minutes.ToString() : bookingOption.BO_ThursFrom.Value.Minutes.ToString();
                string ThursHourTo = bookingOption.BO_ThursTo.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_ThursTo.Value.Hours.ToString() : bookingOption.BO_ThursTo.Value.Hours.ToString();
                string ThursMinTo = bookingOption.BO_ThursTo.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_ThursTo.Value.Minutes.ToString() : bookingOption.BO_ThursTo.Value.Minutes.ToString();

                FBI_Thurs = ThursHourFrom + ":" + ThursMinFrom + " - " + ThursHourTo + ":" + ThursMinTo;
            }


            if (!bookingOption.BO_FriFrom.HasValue || !bookingOption.BO_FriTo.HasValue)
                FBI_Fri = "brak możliwości rezerwacji";
            else
            {
                string FrisHourFrom = bookingOption.BO_FriFrom.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_FriFrom.Value.Hours.ToString() : bookingOption.BO_FriFrom.Value.Hours.ToString();
                string FriMinFrom = bookingOption.BO_FriFrom.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_FriFrom.Value.Minutes.ToString() : bookingOption.BO_FriFrom.Value.Minutes.ToString();
                string FriHourTo = bookingOption.BO_FriTo.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_FriTo.Value.Hours.ToString() : bookingOption.BO_FriTo.Value.Hours.ToString();
                string FriMinTo = bookingOption.BO_FriTo.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_FriTo.Value.Minutes.ToString() : bookingOption.BO_FriTo.Value.Minutes.ToString();

                FBI_Fri = FrisHourFrom + ":" + FriMinFrom + " - " + FriHourTo + ":" + FriMinTo;
            }


            if (!bookingOption.BO_SatFrom.HasValue || !bookingOption.BO_SatTo.HasValue)
                FBI_Sat = "brak możliwości rezerwacji";
            else
            {
                string SatHourFrom = bookingOption.BO_SatFrom.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_SatFrom.Value.Hours.ToString() : bookingOption.BO_SatFrom.Value.Hours.ToString();
                string SatMinFrom = bookingOption.BO_SatFrom.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_SatFrom.Value.Minutes.ToString() : bookingOption.BO_SatFrom.Value.Minutes.ToString();
                string SatHourTo = bookingOption.BO_SatTo.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_SatTo.Value.Hours.ToString() : bookingOption.BO_SatTo.Value.Hours.ToString();
                string SatMinTo = bookingOption.BO_SatTo.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_SatTo.Value.Minutes.ToString() : bookingOption.BO_SatTo.Value.Minutes.ToString();

                FBI_Sat = SatHourFrom + ":" + SatMinFrom + " - " + SatHourTo + ":" + SatMinTo;
            }


            if (!bookingOption.BO_SunFrom.HasValue || !bookingOption.BO_SunTo.HasValue)
                FBI_Sun = "brak możliwości rezerwacji";
            else
            {
                string SunHourFrom = bookingOption.BO_SunFrom.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_SunFrom.Value.Hours.ToString() : bookingOption.BO_SunFrom.Value.Hours.ToString();
                string SunMinFrom = bookingOption.BO_SunFrom.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_SunFrom.Value.Minutes.ToString() : bookingOption.BO_SunFrom.Value.Minutes.ToString();
                string SunHourTo = bookingOption.BO_SunTo.Value.Hours.ToString().Length < 2 ? "0" + bookingOption.BO_SunTo.Value.Hours.ToString() : bookingOption.BO_SunTo.Value.Hours.ToString();
                string SunMinTo = bookingOption.BO_SunTo.Value.Minutes.ToString().Length < 2 ? "0" + bookingOption.BO_SunTo.Value.Minutes.ToString() : bookingOption.BO_SunTo.Value.Minutes.ToString();

                FBI_Sun = SunHourFrom + ":" + SunMinFrom + " - " + SunHourTo + ":" + SunMinTo;
            }

        }
    }
}