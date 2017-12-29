using blaugrana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blaugrana.Controllers
{
    public class FieldsController : Controller
    {
        List<FieldInformation> _listOfFieldInformation = new List<FieldInformation>();
        //FieldInformation _fieldInformation;
        // GET: Fields
        public ActionResult Fields()
        {
            using (var db = new footcamEntities())
            {
                List<Field> listOfFields = db.Fields.ToList();
                for (int i = 0; i < listOfFields.Count; i++)
                {
                    int idFields = listOfFields[i].F_Id;
                    Address address = db.Addresses.Where(a => a.A_FieldId == idFields).FirstOrDefault<Address>();
                    OpenDaysHour openDaysHour = db.OpenDaysHours.Where(odh => odh.ODH_IdField == idFields).FirstOrDefault();
                    _listOfFieldInformation.Add(new FieldInformation(listOfFields[i], address, openDaysHour));
                }
            }
            return View(_listOfFieldInformation);
        }
        public ActionResult FieldExtension(FieldInformation fieldInformation)
        {
            //_fieldInformation = fieldInformation;
            //string photo = "../../Resources/Images/orlikPhoto.jpg";
            //string photo = "../../Resources/Images/orlikPhoto.jpg";
            return View(fieldInformation);
        }
    }
}