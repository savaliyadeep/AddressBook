using AddressBook.Areas.LOC_City.Models;
using AddressBook.Areas.LOC_Country.Models;
using AddressBook.Areas.LOC_State.Models;
using AddressBook.BAL;
using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook.Areas.LOC_City.Controllers
{
    [CheckAccess]
    [Area("LOC_City")]
    [Route("LOC_City/[controller]/[action]")]

    public class LOC_CityController : Controller
    {

        LOC_DAL dalLOC = new LOC_DAL();

        public LOC_CityController()
        {

        }

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalLOC.dbo_PR_LOC_City_SelectAll();


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
            List<LOC_StateDropDownModel> statedropdown1 = new List<LOC_StateDropDownModel>();
            foreach (DataRow dr1 in dt2.Rows)
            {
                LOC_StateDropDownModel dropdown2 = new LOC_StateDropDownModel();
                dropdown2.StateID = (int)dr1["StateID"];
                dropdown2.StateName = (string)dr1["StateName"];
                statedropdown1.Add(dropdown2);
            }
            ViewBag.StateList = statedropdown1;

            return View("LOC_CityList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CityID)
        {
            if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_City_DeleteByPK(CityID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add\Edit

        public IActionResult Add(int? CityID)
        {

            #region ComboBox
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

            List<LOC_StateDropDownModel> statedropdown2 = new List<LOC_StateDropDownModel>();
            ViewBag.StateList = statedropdown2;
            #endregion

            #region Record Select by PK
            if (CityID != null)
            {
                DataTable dt = dalLOC.dbo_PR_LOC_City_SelectByPK(CityID);
                LOC_CityModel model = new LOC_CityModel();
                foreach (DataRow dr in dt.Rows)
                {
                    model.CityID = Convert.ToInt32(dr["CityID"]);
                    model.CityName = dr["CityName"].ToString();
                    model.CityCode = dr["CityCode"].ToString();
                    model.CountryID = Convert.ToInt32(dr["CountryID"]);
                    DataTable dt2 = dalLOC.dbo_PR_LOC_State_SelectForDropDownByCountryID(model.CountryID);

                    List<LOC_StateDropDownModel> statedropdown3 = new List<LOC_StateDropDownModel>();
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        LOC_StateDropDownModel dropdown = new LOC_StateDropDownModel();
                        dropdown.StateID = (int)dr2["StateID"];
                        dropdown.StateName = (string)dr2["StateName"];
                        statedropdown3.Add(dropdown);
                    }
                    ViewBag.StateList = statedropdown3;
                    model.StateID = Convert.ToInt32(dr["StateID"]);
                }
                return View("LOC_CityAddEdit", model);
            }
            #endregion

            return View("LOC_CityAddEdit");
        }

        #endregion

        #region fordropdown

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

        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(LOC_CityModel modelLOC_City)
        {
            if (ModelState.IsValid)
            {
                if (modelLOC_City.CityID == null)
                {
                    if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_City_Insert(modelLOC_City)))
                        return RedirectToAction("Index");
                }
                else
                {
                    if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_City_UpdateByPK(modelLOC_City)))
                        return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Filter
        public IActionResult Filter(int CountryID, int StateID, string CityName, string CityCode)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_City_Filter(CountryID, StateID, CityName, CityCode);

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
            /*end*/

            return View("LOC_CityList", dt);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        #endregion

        #region old

        //public IActionResult Add(int? CityID)
        //{
        //    LOC_CityModel modelLOC_City = new LOC_CityModel();
        //    string str1 = this.Configuration.GetConnectionString("myConnectionStrings");
        //    SqlConnection conn1 = new SqlConnection(str1);
        //    conn1.Open();
        //    SqlCommand cmd1 = conn1.CreateCommand();
        //    cmd1.CommandType = CommandType.StoredProcedure;
        //    cmd1.CommandText = "PR_LOC_Country_SelectForDropDown";
        //    SqlDataReader sdr = cmd1.ExecuteReader();
        //    DataTable dt1 = new DataTable();
        //    dt1.Load(sdr);

        //    List<LOC_CountryDDModel> countrydropdown = new List<LOC_CountryDDModel>();

        //    foreach (DataRow dr in dt1.Rows)
        //    {
        //        LOC_CountryDDModel dropdown = new LOC_CountryDDModel();
        //        dropdown.CountryID = (int)dr["CountryID"];
        //        dropdown.CountryName = (string)dr["CountryName"];
        //        countrydropdown.Add(dropdown);
        //    }
        //    ViewBag.CountryList = countrydropdown;

        //    List<LOC_StateDropDownModel> statedropdown1 = new List<LOC_StateDropDownModel>();
        //    ViewBag.StateList = statedropdown1;

        //    if (CityID != null)
        //    {
        //        string str = this.Configuration.GetConnectionString("myConnectionStrings");
        //        DataTable dt = new DataTable();
        //        SqlConnection conn = new SqlConnection(str);
        //        conn.Open();
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "PR_LOC_City_SelectByPK";
        //        cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
        //        SqlDataReader SDR = cmd.ExecuteReader();
        //        dt.Load(SDR);

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            modelLOC_City.CityID = Convert.ToInt32(dr["CityID"]);
        //            modelLOC_City.CityName = dr["CityName"].ToString();
        //            modelLOC_City.CityCode = dr["CityCode"].ToString();
        //            modelLOC_City.CountryID = Convert.ToInt32(dr["CountryID"]);
        //            modelLOC_City.StateID = Convert.ToInt32(dr["StateID"]);
        //            string str2 = this.Configuration.GetConnectionString("myConnectionStrings");
        //            SqlConnection conn2 = new SqlConnection(str2);
        //            conn2.Open();
        //            SqlCommand cmd2 = conn2.CreateCommand();
        //            cmd2.CommandType = CommandType.StoredProcedure;
        //            cmd2.CommandText = "PR_LOC_State_SelectDropDownByCountryID";
        //            cmd2.Parameters.AddWithValue("CountryID", modelLOC_City.CountryID);
        //            SqlDataReader sdr2 = cmd2.ExecuteReader();
        //            DataTable dt2 = new DataTable();
        //            dt2.Load(sdr2);
        //            conn2.Close();

        //            List<LOC_StateDropDownModel> statedropdown = new List<LOC_StateDropDownModel>();

        //            foreach (DataRow dr1 in dt2.Rows)
        //            {
        //                LOC_StateDropDownModel dropdown1 = new LOC_StateDropDownModel();
        //                dropdown1.StateID = (int)dr1["StateID"];
        //                dropdown1.StateName = (string)dr1["StateName"];
        //                statedropdown.Add(dropdown1);
        //            }
        //            List<LOC_StateDropDownModel> statedropdown2 = new List<LOC_StateDropDownModel>();
        //            ViewBag.StateList = statedropdown;
        //            modelLOC_City.Created = Convert.ToDateTime(dr["Created"]);
        //            modelLOC_City.Modified = Convert.ToDateTime(dr["Modified"]);
        //        }

        //        return View("LOC_CityAddEdit",modelLOC_City);
        //    } 
        //    return View("LOC_CityAddEdit");
        //}




        //[HttpPost]
        //public IActionResult Save(LOC_CityModel modelLOC_City)
        //{
        //    string str = this.Configuration.GetConnectionString("myConnectionStrings");
        //    SqlConnection conn = new SqlConnection(str);
        //    conn.Open();
        //    SqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if(modelLOC_City.CityID == null)
        //    {
        //        cmd.CommandText = "PR_LOC_City_Insert";
        //        cmd.Parameters.Add("@Created", SqlDbType.Date).Value = DBNull.Value;
        //    }
        //    else
        //    {
        //        cmd.CommandText = "PR_LOC_City_UpdateByPK";
        //        cmd.Parameters.Add("@CityID", SqlDbType.Int).Value = modelLOC_City.CityID;
        //    }            
        //    cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = modelLOC_City.CityName;
        //    cmd.Parameters.Add("@CityCode", SqlDbType.NVarChar).Value = modelLOC_City.CityCode;
        //    cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = modelLOC_City.StateID;
        //    cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = modelLOC_City.CountryID;
        //    cmd.Parameters.Add("@Modified", SqlDbType.Date).Value = DBNull.Value;
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //    return RedirectToAction("Index");
        //}

        #endregion
    }
}
