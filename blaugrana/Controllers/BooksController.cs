using blaugrana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blaugrana.Controllers
{
    public class BooksController : Controller
    {
        List<Field> listOfFields = new List<Field>();
        public ActionResult Fields()
        {

            using (var db = new footcamEntities())
            {
                listOfFields = db.Fields.Where(a=> a.F_BookingPossibility == true).ToList();
            }

            return View(listOfFields);
        }

        public ActionResult FieldBooksExtension(int? id, bool needValidate = false, string dateTime = null, string longBook=null, string email=null, string name=null, string surname=null)
        {
            

            if (needValidate == true)
            {
                
                FieldBooksInformation fieldBooksInformation = GetFieldBooksInformation(id);
                fieldBooksInformation = Validation(fieldBooksInformation, dateTime, longBook, email, name, surname);
                //w walidacji dodac tekst do walidacji   fieldBooksInformationToValidate.FBI_TextValidation
                return View(fieldBooksInformation);
            }
            else
            {
                FieldBooksInformation fieldBooksInformation = GetFieldBooksInformation(id);
                return View(fieldBooksInformation);
            }

            
        }

        public FieldBooksInformation GetFieldBooksInformation(int? id)
        {
            Field field;
            BookingOption bookingOption;
            List<Book> listOfBooks;
            FieldBooksInformation fieldBooksInformation;
            using (var db = new footcamEntities())
            {
                field = db.Fields.Where(f => f.F_Id == id).ToList().FirstOrDefault();
                bookingOption = db.BookingOptions.Where(bo => bo.BO_IdField == id).ToList().FirstOrDefault();
                listOfBooks = db.Books.Where(b => b.B_IdField == id).ToList();
                if (listOfBooks.Count < 1)
                {
                    fieldBooksInformation = new FieldBooksInformation();
                }
                else
                {
                    fieldBooksInformation = new FieldBooksInformation(field, bookingOption, listOfBooks);
                }
            }
            return fieldBooksInformation;
        }
        public FieldBooksInformation Validation(FieldBooksInformation fieldBooksInformationToValidate, string dateTime, string longBook, string email, string name, string surname)
        {
            #region FillValidate
            if (String.IsNullOrWhiteSpace(dateTime) || String.IsNullOrWhiteSpace(longBook) || String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(surname))
            {
                fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                fieldBooksInformationToValidate.FBI_TextValidation = "Wszystkie pola muszą być uzupełnione";
                return fieldBooksInformationToValidate;
            }
            else
            {
                fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
            }
                
            #endregion
            #region DateValidate
            Double longBooking;
            try
            {
                longBooking = Convert.ToDouble(longBook);
                if (longBooking > fieldBooksInformationToValidate.BO_MaxHourBook)
                {
                    fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                    fieldBooksInformationToValidate.FBI_TextValidation = "Czas rezerwacji nie może być dłuższy niż " + fieldBooksInformationToValidate.BO_MaxHourBook + "h";
                    return fieldBooksInformationToValidate;
                }
            }
            catch (Exception)
            {
                fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                fieldBooksInformationToValidate.FBI_TextValidation = "Podaj poprawną wartość dotycząca długości rezerwacji";
                return fieldBooksInformationToValidate;
            }
            try
            {
                DateTime dateTimeStart = Convert.ToDateTime(dateTime);
                string dayOfWeek = dateTimeStart.DayOfWeek.ToString();
                switch (dayOfWeek)
                {
                    case "Monday":
                        if ((dateTimeStart.Hour >= fieldBooksInformationToValidate.BO_MonFrom.Value.Hours && dateTimeStart.Hour <= fieldBooksInformationToValidate.BO_MonTo.Value.Hours) &&
                            (dateTimeStart.AddHours(longBooking).Hour >= fieldBooksInformationToValidate.BO_MonFrom.Value.Hours && dateTimeStart.AddHours(longBooking).Hour <= fieldBooksInformationToValidate.BO_MonTo.Value.Hours))
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
                            //fieldBooksInformationToValidate.FBI_TextValidation = "Zły format daty rozpoczęcia rezerwacji";
                            //return fieldBooksInformationToValidate;
                        }
                        else
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                            fieldBooksInformationToValidate.FBI_TextValidation = "Nie można zarezerwować tego boiska w tych godzinach";
                            return fieldBooksInformationToValidate;
                        }
                        break;
                    case "Tuesday":
                        if ((dateTimeStart.Hour >= fieldBooksInformationToValidate.BO_TuesFrom.Value.Hours && dateTimeStart.Hour <= fieldBooksInformationToValidate.BO_TuesTo.Value.Hours) &&
                            (dateTimeStart.AddHours(longBooking).Hour >= fieldBooksInformationToValidate.BO_TuesFrom.Value.Hours && dateTimeStart.AddHours(longBooking).Hour <= fieldBooksInformationToValidate.BO_TuesTo.Value.Hours))
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
                            //fieldBooksInformationToValidate.FBI_TextValidation = "Zły format daty rozpoczęcia rezerwacji";
                            //return fieldBooksInformationToValidate;
                        }
                        else
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                            fieldBooksInformationToValidate.FBI_TextValidation = "Nie można zarezerwować tego boiska w tych godzinach";
                            return fieldBooksInformationToValidate;
                        }
                        break;
                    case "Wednesday":
                        if ((dateTimeStart.Hour >= fieldBooksInformationToValidate.BO_WedFrom.Value.Hours && dateTimeStart.Hour <= fieldBooksInformationToValidate.BO_WedTo.Value.Hours) &&
                            (dateTimeStart.AddHours(longBooking).Hour >= fieldBooksInformationToValidate.BO_WedFrom.Value.Hours && dateTimeStart.AddHours(longBooking).Hour <= fieldBooksInformationToValidate.BO_WedTo.Value.Hours))
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
                            //fieldBooksInformationToValidate.FBI_TextValidation = "Zły format daty rozpoczęcia rezerwacji";
                            //return fieldBooksInformationToValidate;
                        }
                        else
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                            fieldBooksInformationToValidate.FBI_TextValidation = "Nie można zarezerwować tego boiska w tych godzinach";
                            return fieldBooksInformationToValidate;
                        }
                        break;
                    case "Thursday":
                        if ((dateTimeStart.Hour >= fieldBooksInformationToValidate.BO_ThursFrom.Value.Hours && dateTimeStart.Hour <= fieldBooksInformationToValidate.BO_ThursTo.Value.Hours) &&
                            (dateTimeStart.AddHours(longBooking).Hour >= fieldBooksInformationToValidate.BO_ThursFrom.Value.Hours && dateTimeStart.AddHours(longBooking).Hour <= fieldBooksInformationToValidate.BO_ThursTo.Value.Hours))
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
                            //fieldBooksInformationToValidate.FBI_TextValidation = "Zły format daty rozpoczęcia rezerwacji";
                            //return fieldBooksInformationToValidate;
                        }
                        else
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                            fieldBooksInformationToValidate.FBI_TextValidation = "Nie można zarezerwować tego boiska w tych godzinach";
                            return fieldBooksInformationToValidate;
                        }
                        break;
                    case "Friday":
                        if ((dateTimeStart.Hour >= fieldBooksInformationToValidate.BO_FriFrom.Value.Hours && dateTimeStart.Hour <= fieldBooksInformationToValidate.BO_FriTo.Value.Hours) &&
                            (dateTimeStart.AddHours(longBooking).Hour >= fieldBooksInformationToValidate.BO_FriFrom.Value.Hours && dateTimeStart.AddHours(longBooking).Hour <= fieldBooksInformationToValidate.BO_FriTo.Value.Hours))
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
                            //fieldBooksInformationToValidate.FBI_TextValidation = "Zły format daty rozpoczęcia rezerwacji";
                            //return fieldBooksInformationToValidate;
                        }
                        else
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                            fieldBooksInformationToValidate.FBI_TextValidation = "Nie można zarezerwować tego boiska w tych godzinach";
                            return fieldBooksInformationToValidate;
                        }
                        break;
                    case "Saturday":
                        if ((dateTimeStart.Hour >= fieldBooksInformationToValidate.BO_SatFrom.Value.Hours && dateTimeStart.Hour <= fieldBooksInformationToValidate.BO_SatTo.Value.Hours) &&
                            (dateTimeStart.AddHours(longBooking).Hour >= fieldBooksInformationToValidate.BO_SatFrom.Value.Hours && dateTimeStart.AddHours(longBooking).Hour <= fieldBooksInformationToValidate.BO_SatTo.Value.Hours))
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
                            //fieldBooksInformationToValidate.FBI_TextValidation = "Zły format daty rozpoczęcia rezerwacji";
                            //return fieldBooksInformationToValidate;
                        }
                        else
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                            fieldBooksInformationToValidate.FBI_TextValidation = "Nie można zarezerwować tego boiska w tych godzinach";
                            return fieldBooksInformationToValidate;
                        }
                        break;
                    case "Sunday":
                        if ((dateTimeStart.Hour >= fieldBooksInformationToValidate.BO_SunFrom.Value.Hours && dateTimeStart.Hour <= fieldBooksInformationToValidate.BO_SunTo.Value.Hours) &&
                            (dateTimeStart.AddHours(longBooking).Hour >= fieldBooksInformationToValidate.BO_SunFrom.Value.Hours && dateTimeStart.AddHours(longBooking).Hour <= fieldBooksInformationToValidate.BO_SunTo.Value.Hours))
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
                            //fieldBooksInformationToValidate.FBI_TextValidation = "Zły format daty rozpoczęcia rezerwacji";
                            //return fieldBooksInformationToValidate;
                        }
                        else
                        {
                            fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                            fieldBooksInformationToValidate.FBI_TextValidation = "Nie można zarezerwować tego boiska w tych godzinach";
                            return fieldBooksInformationToValidate;
                        }
                        break;
                }
                for (int i = 0; i < fieldBooksInformationToValidate.FBI_Books.Count; i++)
                {
                    if ((dateTimeStart >= fieldBooksInformationToValidate.FBI_Books[i].B_BookDTFrom && dateTimeStart <= fieldBooksInformationToValidate.FBI_Books[i].B_BookDTTo && ((bool)fieldBooksInformationToValidate.FBI_Books[i].B_ConfirmedByUser || (TimeSpan)(DateTime.Now - fieldBooksInformationToValidate.FBI_Books[i].B_InsertDT) < new TimeSpan(0, 5, 0)) || ((dateTimeStart.AddHours(longBooking) >= fieldBooksInformationToValidate.FBI_Books[i].B_BookDTFrom && dateTimeStart.AddHours(longBooking) <= fieldBooksInformationToValidate.FBI_Books[i].B_BookDTTo)) && ((bool)fieldBooksInformationToValidate.FBI_Books[i].B_ConfirmedByUser || (TimeSpan)(DateTime.Now - fieldBooksInformationToValidate.FBI_Books[i].B_InsertDT) < new TimeSpan(0, 5, 0))))
                    {
                        fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                        fieldBooksInformationToValidate.FBI_TextValidation = "Ktoś inny ma rezerwację w tym czasie";
                        return fieldBooksInformationToValidate;
                    }
                    else
                    {
                        fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
                        fieldBooksInformationToValidate.FBI_TextValidation = "Wszystko Okej";
                    }
                }
            }
            catch (Exception)
            {
                fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                fieldBooksInformationToValidate.FBI_TextValidation = "Zły format daty rozpoczęcia rezerwacji";
                return fieldBooksInformationToValidate;
            }

            return fieldBooksInformationToValidate;
            #endregion
            #region EmailValidate
            if(!email.Contains('@'))
            {
                fieldBooksInformationToValidate.FBI_IfGoodValidation = false;
                fieldBooksInformationToValidate.FBI_TextValidation = "Wpisz poprawnie adres e-mail";
                return fieldBooksInformationToValidate;
            }
            else
            {
                fieldBooksInformationToValidate.FBI_IfGoodValidation = true;
            }
            #endregion
        }

        public bool Validate(int a)
        {
            if (a == 1)
                return true;
            else
                return false;
        }
    }
}