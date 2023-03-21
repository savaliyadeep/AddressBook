using AddressBook.Areas.CON_Contact.Models;
using AddressBook.Areas.LOC_City.Models;
using AddressBook.Areas.LOC_Country.Models;
using AddressBook.Areas.LOC_State.Models;
using AddressBook.Areas.MST_ContactCategory.Models;
using AddressBook.BAL;
using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook.Areas.CON_Contact.Controllers
{
    [CheckAccess]
    [Area("CON_Contact")]
    [Route("CON_Contact/[controller]/[action]")]
    public class CON_ContactController : Controller
    {
        CON_DAL dalCON = new CON_DAL();
        LOC_DAL dalLOC = new LOC_DAL();

        public CON_ContactController()
        {
            
        }

        #region SelectAll

        public IActionResult Index()
        {
            
            DataTable dt = dalCON.dbo_PR_CON_Contact_SelectAll();

            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectForDropDown();
            List<LOC_CountryDDModel> countrydropdown = new List<LOC_CountryDDModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_CountryDDModel dropdown = new LOC_CountryDDModel();
                dropdown.CountryID = (int)dr["CountryID"];
                dropdown.CountryName = (string)dr["CountryName"];
                countrydropdown.Add(dropdown);
            }
            ViewBag.CountryList = countrydropdown;

            DataTable dt2 = dalLOC.dbo_PR_LOC_State_SelectForDropDown();
            List<LOC_StateDropDownModel> statedropdown = new List<LOC_StateDropDownModel>();
            foreach (DataRow dr1 in dt2.Rows)
            {
                LOC_StateDropDownModel dropdown2 = new LOC_StateDropDownModel();
                dropdown2.StateID = (int)dr1["StateID"];
                dropdown2.StateName = (string)dr1["StateName"];
                statedropdown.Add(dropdown2);
            }
            ViewBag.StateList = statedropdown;

            DataTable dt3 = dalLOC.dbo_PR_LOC_City_SelectForDropDown();
            List<LOC_CityDropDownModel> citydropdown = new List<LOC_CityDropDownModel>();
            foreach (DataRow dr2 in dt3.Rows)
            {
                LOC_CityDropDownModel dropdown3 = new LOC_CityDropDownModel();
                dropdown3.CityID = (int)dr2["CityID"];
                dropdown3.CityName = (string)dr2["CityName"];
                citydropdown.Add(dropdown3);
            }
            ViewBag.CityList = citydropdown;

            return View("CON_ContactList", dt);
        }

        #endregion

        #region Delete

        public IActionResult Delete(int ContactID)
        {
            if (Convert.ToBoolean(dalCON.dbo_PR_CON_Contact_DeleteByPK(ContactID)))
                return RedirectToAction("Index");
            return View("Index");
        }

        #endregion

        #region Add/Edit

        public IActionResult Add(int? ContactID)
        {

            CON_ContactModel modelCON_Contact = new CON_ContactModel();
            
            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectForDropDown();
            List<LOC_CountryDDModel> countrydropdown = new List<LOC_CountryDDModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                LOC_CountryDDModel dropdown = new LOC_CountryDDModel();
                dropdown.CountryID = (int)dr["CountryID"];
                dropdown.CountryName = (string)dr["CountryName"];
                countrydropdown.Add(dropdown);
            }
            ViewBag.CountryList = countrydropdown;

            List<LOC_StateDropDownModel> statedropdown1 = new List<LOC_StateDropDownModel>();
            ViewBag.StateList = statedropdown1;

            List<LOC_CityDropDownModel> citydropdown1 = new List<LOC_CityDropDownModel>();
            ViewBag.CityList = citydropdown1;

            DataTable dt4 = dalCON.dbo_PR_MST_ContactCategory_SelectForDropDown();
            List<MST_ContactCategoryDropDownModel> Categorydropdown = new List<MST_ContactCategoryDropDownModel>();

            foreach (DataRow dr in dt4.Rows)
            {
                MST_ContactCategoryDropDownModel dropdown4 = new MST_ContactCategoryDropDownModel();
                dropdown4.CategoryID = (int)dr["CategoryID"];
                dropdown4.CategoryName = (string)dr["CategoryName"];
                Categorydropdown.Add(dropdown4);
            }
            ViewBag.CategoryList = Categorydropdown;

            if (ContactID != null)
            {
                DataTable dt = dalCON.dbo_PR_CON_Contact_SelectByPK(ContactID);

                foreach (DataRow dr in dt.Rows)
                {
                    modelCON_Contact.ContactID = Convert.ToInt32(dr["ContactID"]);
                    modelCON_Contact.PhotoPath = dr["PhotoPath"].ToString();
                    modelCON_Contact.ContactName = dr["ContactName"].ToString();
                    modelCON_Contact.CountryID = Convert.ToInt32(dr["CountryID"]);
                    DataTable dt2 = dalLOC.dbo_PR_LOC_State_SelectForDropDownByCountryID(modelCON_Contact.CountryID);
                  
                    List<LOC_StateDropDownModel> statedropdown = new List<LOC_StateDropDownModel>();

                    foreach (DataRow dr1 in dt2.Rows)
                    {
                        LOC_StateDropDownModel dropdown1 = new LOC_StateDropDownModel();
                        dropdown1.StateID = (int)dr1["StateID"];
                        dropdown1.StateName = (string)dr1["StateName"];
                        statedropdown.Add(dropdown1);
                    }
                    ViewBag.StateList = statedropdown;
                    modelCON_Contact.StateID = Convert.ToInt32(dr["StateID"]);
                    DataTable dt3 = dalLOC.dbo_PR_LOC_City_SelectForDropDownByStateID(modelCON_Contact.StateID);

                    List<LOC_CityDropDownModel> citydropdown = new List<LOC_CityDropDownModel>();

                    foreach (DataRow dr2 in dt3.Rows)
                    {
                        LOC_CityDropDownModel dropdown3 = new LOC_CityDropDownModel();
                        dropdown3.CityID = (int)dr2["CityID"];
                        dropdown3.CityName = (string)dr2["CityName"];
                        citydropdown.Add(dropdown3);
                    }
                    ViewBag.CityList = citydropdown;
                    modelCON_Contact.CityID = Convert.ToInt32(dr["CityID"]);
                    modelCON_Contact.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    modelCON_Contact.Address = dr["Address"].ToString();
                    modelCON_Contact.PinCode = Convert.ToInt32(dr["PinCode"]);
                    modelCON_Contact.Mobile = dr["Mobile"].ToString();
                    modelCON_Contact.AlternateContact = dr["AlternateContact"].ToString();
                    modelCON_Contact.Email = dr["Email"].ToString();
                    modelCON_Contact.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                    modelCON_Contact.LinkedIn = dr["LinkedIn"].ToString();
                    modelCON_Contact.Twitter = dr["Twitter"].ToString();
                    modelCON_Contact.Instagram = dr["Instagram"].ToString();
                    modelCON_Contact.Gender = dr["Gender"].ToString();
                    modelCON_Contact.Created = Convert.ToDateTime(dr["Created"]);
                    modelCON_Contact.Modified = Convert.ToDateTime(dr["Modified"]);
                }

                return View("CON_ContactAddEdit", modelCON_Contact);
            }
            return View("CON_ContactAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(CON_ContactModel modelCON_Contact)
        {
            
            if (ModelState.IsValid)
            {
                if (modelCON_Contact.File != null)
                {
                    string FilePath = "wwwroot\\Upload";
                    string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    string fileNameWithPath = Path.Combine(path, modelCON_Contact.File.FileName);
                    modelCON_Contact.PhotoPath = FilePath.Replace("wwwroot\\", "/") + "/" + modelCON_Contact.File.FileName;

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        modelCON_Contact.File.CopyTo(stream);
                    }
                }
                if (modelCON_Contact.ContactID == null)
                {
                    if (Convert.ToBoolean(dalCON.dbo_PR_CON_Contact_Insert(modelCON_Contact)))
                        return RedirectToAction("Index");
                }
                else
                {
                    if (Convert.ToBoolean(dalCON.dbo_PR_CON_Contact_UpdateByPK(modelCON_Contact)))
                        return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region DropDown
        [HttpPost]
        public IActionResult DropDownByCountry(int CountryID)
        {
            DataTable dt2 = dalLOC.dbo_PR_LOC_State_SelectForDropDownByCountryID(CountryID);

            List<LOC_StateDropDownModel> statedropdown = new List<LOC_StateDropDownModel>();

            foreach (DataRow dr in dt2.Rows)
            {
                LOC_StateDropDownModel dropdown1 = new LOC_StateDropDownModel();
                dropdown1.StateID = (int)dr["StateID"];
                dropdown1.StateName = (string)dr["StateName"];
                statedropdown.Add(dropdown1);
            }

            var vModel = statedropdown;
            return Json(vModel);
        }

        [HttpPost]
        public IActionResult DropDownByState(int StateID)
        {
            DataTable dt3 = dalLOC.dbo_PR_LOC_City_SelectForDropDownByStateID(StateID);
         
            List<LOC_CityDropDownModel> citydropdown = new List<LOC_CityDropDownModel>();

            foreach (DataRow dr in dt3.Rows)
            {
                LOC_CityDropDownModel dropdown3 = new LOC_CityDropDownModel();
                dropdown3.CityID = (int)dr["CityID"];
                dropdown3.CityName = (string)dr["CityName"];
                citydropdown.Add(dropdown3);
            }

            var vModel = citydropdown;
            return Json(vModel);
        }
        #endregion

        #region Filter
        public IActionResult Filter(int CountryID, int StateID, int CityID)
        {
            
            DataTable dt = dalCON.dbo_PR_CON_Contact_Filter(CountryID, StateID, CityID);

            /*To pass Country and State drop down for filter in state list */
            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectForDropDown();
            
            List<LOC_CountryDDModel> countrydropdown1 = new List<LOC_CountryDDModel>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                LOC_CountryDDModel dropdown = new LOC_CountryDDModel();
                dropdown.CountryID = (int)dr1["CountryID"];
                dropdown.CountryName = (string)dr1["CountryName"];
                countrydropdown1.Add(dropdown);
            }
            ViewBag.CountryList = countrydropdown1;


            DataTable dt2 = dalLOC.dbo_PR_LOC_State_SelectForDropDown();
            
            List<LOC_StateDropDownModel> statedropdown1 = new List<LOC_StateDropDownModel>();
            foreach (DataRow dr1 in dt2.Rows)
            {
                LOC_StateDropDownModel dropdown2 = new LOC_StateDropDownModel();
                dropdown2.StateID = (int)dr1["StateID"];
                dropdown2.StateName = (string)dr1["StateName"];
                statedropdown1.Add(dropdown2);
            }
            ViewBag.StateList = statedropdown1;

            DataTable dt3 = dalLOC.dbo_PR_LOC_City_SelectForDropDown();
            
            List<LOC_CityDropDownModel> citydropdown1 = new List<LOC_CityDropDownModel>();
            foreach (DataRow dr2 in dt3.Rows)
            {
                LOC_CityDropDownModel dropdown3 = new LOC_CityDropDownModel();
                dropdown3.CityID = (int)dr2["CityID"];
                dropdown3.CityName = (string)dr2["CityName"];
                citydropdown1.Add(dropdown3);
            }
            ViewBag.CityList = citydropdown1;
            /*end*/

            return View("CON_ContactList", dt);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region old
        //[HttpPost]
        //public IActionResult Save(CON_ContactModel modelCON_Contact)
        //{
        //    string str = Configuration.GetConnectionString("myConnectionStrings");

        //    if (ModelState.IsValid)
        //    {
        //        if (modelCON_Contact.File != null)
        //        {
        //            string FilePath = "wwwroot\\Upload";
        //            string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

        //            if (!Directory.Exists(path))
        //                Directory.CreateDirectory(path);

        //            string fileNameWithPath = Path.Combine(path, modelCON_Contact.File.FileName);
        //            modelCON_Contact.PhotoPath = FilePath.Replace("wwwroot\\", "/") + "/" + modelCON_Contact.File.FileName;

        //            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
        //            {
        //                modelCON_Contact.File.CopyTo(stream);
        //            }
        //        }
        //        if (modelCON_Contact.ContactID == null)
        //        {
        //            if (Convert.ToBoolean(dalCON.dbo_PR_CON_Contact_Insert(str, modelCON_Contact)))
        //                return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            string strmsg = dalCON.dbo_PR_CON_Contact_UpdateByPK(str, modelCON_Contact);
        //                return RedirectToAction("Index");
        //        }
        //    }
        //    return RedirectToAction("Index");

        //    //SqlConnection conn = new SqlConnection(str);
        //    //conn.Open();
        //    //SqlCommand cmd = conn.CreateCommand();
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //if (modelCON_Contact.ContactID == null)
        //    //{
        //    //    cmd.CommandText = "PR_CON_Contact_Insert";
        //    //    cmd.Parameters.Add("@Created", SqlDbType.Date).Value = DBNull.Value;
        //    //}
        //    //else
        //    //{
        //    //    cmd.CommandText = "PR_CON_Contact_UpdateByPK";
        //    //    cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = modelCON_Contact.ContactID;
        //    //}
        //    //if (modelCON_Contact.File != null)
        //    //{
        //    //    string FilePath = "wwwroot\\Upload";
        //    //    string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

        //    //    if (!Directory.Exists(path))
        //    //        Directory.CreateDirectory(path);

        //    //    string fileNameWithPath = Path.Combine(path, modelCON_Contact.File.FileName);
        //    //    modelCON_Contact.PhotoPath = FilePath.Replace("wwwroot\\", "/") + "/" + modelCON_Contact.File.FileName;

        //    //    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
        //    //    {
        //    //        modelCON_Contact.File.CopyTo(stream);
        //    //    }
        //    //}
        //    //cmd.Parameters.Add("@PhotoPath", SqlDbType.NVarChar).Value = modelCON_Contact.PhotoPath;
        //    //cmd.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = modelCON_Contact.ContactName;
        //    //cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = modelCON_Contact.CountryID;
        //    //cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = modelCON_Contact.StateID;
        //    //cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = modelCON_Contact.CityID;
        //    //cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = modelCON_Contact.CategoryID;
        //    //cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = modelCON_Contact.Address;
        //    //cmd.Parameters.Add("@PinCode", SqlDbType.NVarChar).Value = modelCON_Contact.PinCode;
        //    //cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = modelCON_Contact.Mobile;
        //    //cmd.Parameters.Add("@AContact", SqlDbType.NVarChar).Value = modelCON_Contact.AlternateContact;
        //    //cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = modelCON_Contact.Email;
        //    //cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = modelCON_Contact.BirthDate;
        //    //cmd.Parameters.Add("@LinkedIn", SqlDbType.NVarChar).Value = modelCON_Contact.LinkedIn;
        //    //cmd.Parameters.Add("@Twitter", SqlDbType.NVarChar).Value = modelCON_Contact.Twitter;
        //    //cmd.Parameters.Add("@Instagram", SqlDbType.NVarChar).Value = modelCON_Contact.Instagram;
        //    //cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = modelCON_Contact.Gender;
        //    //cmd.Parameters.Add("@Modified", SqlDbType.Date).Value = DBNull.Value;
        //    //cmd.ExecuteNonQuery();
        //    //conn.Close();
        //    //return RedirectToAction("Index"); 
        //}

        #endregion
    }
}
