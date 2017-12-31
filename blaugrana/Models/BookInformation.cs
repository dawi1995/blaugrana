using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blaugrana.Models
{
    public class BookInformation
    {
        public int B_Id { get; set; }
        public int B_IdField { get; set; }
        public Nullable<System.DateTime> B_BookDTFrom { get; set; }
        public Nullable<System.DateTime> B_BookDTTo { get; set; }
        public string B_PersonName { get; set; }
        public string B_PersonSurname { get; set; }
        public Nullable<bool> B_ConfirmedByUser { get; set; }
        public Nullable<System.DateTime> B_InsertDT { get; set; }
        public string BI_Time { get; set; }
        public string BI_Confirmed { get; set; }

        public BookInformation()
        {

        }
        public BookInformation(Book book)
        {
            B_Id = book.B_Id;
            B_IdField = book.B_IdField;
            B_BookDTFrom = book.B_BookDTFrom;
            B_BookDTTo = book.B_BookDTTo;
            B_PersonName = book.B_PersonName;
            B_PersonSurname = book.B_PersonSurname;
            B_ConfirmedByUser = book.B_ConfirmedByUser;
            B_InsertDT = book.B_InsertDT;
            if ((bool)B_ConfirmedByUser)
                BI_Confirmed = "Potwierdzona";
            else
                BI_Confirmed = "Niepotwierdzona";


            string HourFrom = book.B_BookDTFrom.Value.Hour.ToString().Length < 2 ? "0" + book.B_BookDTFrom.Value.Hour.ToString() : book.B_BookDTFrom.Value.Hour.ToString();
            string MinFrom = book.B_BookDTFrom.Value.Minute.ToString().Length < 2 ? "0" + book.B_BookDTFrom.Value.Minute.ToString() : book.B_BookDTFrom.Value.Minute.ToString();
            string HourTo = book.B_BookDTTo.Value.Hour.ToString().Length < 2 ? "0" + book.B_BookDTTo.Value.Hour.ToString() : book.B_BookDTTo.Value.Hour.ToString();
            string MinTo = book.B_BookDTTo.Value.Minute.ToString().Length < 2 ? "0" + book.B_BookDTTo.Value.Minute.ToString() : book.B_BookDTTo.Value.Minute.ToString();

            BI_Time = HourFrom + ":" + MinFrom + " - " + HourTo + ":" + MinTo;
            
        }
    }
}