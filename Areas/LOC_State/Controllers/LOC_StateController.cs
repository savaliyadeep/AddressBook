using AddressBook.Areas.LOC_Country.Models;
using AddressBook.Areas.LOC_State.Models;
using AddressBook.BAL;
using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook.Areas.LOC_State.Controllers
{
    [CheckAccess]
    [Area("LOC_State")]
    [Route("LOC_State/[controller]/[action]")]

    public class LOC_StateController : Controller
    {

        LOC_DAL dalLOC = new LOC_DAL();

        public LOC_StateController()
        {
            
        }

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalLOC.dbo_PR_LOC_State_SelectAll();

            /*To pass country drop down for filter in state list */
            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectForDropDown();
            //dt1.Load(sdr);
            List<LOC_CountryDDModel> countrydropdown1 = new List<LOC_CountryDDModel>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                LOC_CountryDDModel dropdown = new LOC_CountryDDModel();
                dropdown.CountryID = (int)dr1["CountryID"];
                dropdown.CountryName = (string)dr1["CountryName"];
                countrydropdown1.Add(dropdown);
            }
            ViewBag.CountryList = countrydropdown1;
            /*end*/

            return View("LOC_StateList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int StateID)
        {
            if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_State_DeleteByPK(StateID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add/Edit
        public IActionResult Add(int? StateID)
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
            #endregion

            #region Record Select by PK
            if (StateID != null)
            {
                DataTable dt = dalLOC.dbo_PR_LOC_State_SelectByPK(StateID);
                LOC_StateModel model = new LOC_StateModel();
                foreach (DataRow dr in dt.Rows)
                {
                    model.StateID = Convert.ToInt32(dr["StateID"]);
                    model.StateName = dr["StateName"].ToString();
                    model.StateCode = dr["StateCode"].ToString();
                    model.CountryID = Convert.ToInt32(dr["CountryID"]);
                }
                return View("LOC_StateAddEdit", model);
            }
            #endregion

            return View("LOC_StateAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(LOC_StateModel modelLOC_State)
        {
            if (ModelState.IsValid)
            {
                if (modelLOC_State.StateID == null)
                {
                    if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_State_Insert(modelLOC_State)))
                        return RedirectToAction("Index");
                }
                else
                {
                    if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_State_UpdateByPK(modelLOC_State)))
                        return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Filter
        public IActionResult Filter(int CountryID, string StateName, string StateCode)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_State_Filter(CountryID, StateName, StateCode);

            /*To pass country drop down for filter in state list */
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
            /*end*/

            return View("LOC_StateList", dt);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        #endregion

        #region old
        //public IActionResult Add(int? StateID)
        //{
        //    LOC_StateModel modelLOC_State = new LOC_StateModel();
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

        //    if (StateID != null)
        //    {
        //        string str = this.Configuration.GetConnectionString("myConnectionStrings");
        //        DataTable dt = new DataTable();
        //        SqlConnection conn = new SqlConnection(str);
        //        conn.Open();
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "PR_LOC_State_SelectByPK";
        //        cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
        //        SqlDataReader SDR = cmd.ExecuteReader();
        //        dt.Load(SDR);

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            modelLOC_State.StateID = Convert.ToInt32(dr["StateID"]);
        //            modelLOC_State.StateName = dr["StateName"].ToString();
        //            modelLOC_State.StateCode = dr["StateCode"].ToString();
        //            modelLOC_State.CountryID = Convert.ToInt32(dr["CountryID"]);
        //            modelLOC_State.Created = Convert.ToDateTime(dr["Created"]);
        //            modelLOC_State.Modified = Convert.ToDateTime(dr["Modified"]);
        //        }

        //        return View("LOC_StateAddEdit",modelLOC_State);
        //    }

        //    return View("LOC_StateAddEdit",modelLOC_State);
        //}


        //[HttpPost]
        //public IActionResult Save(LOC_StateModel modelLOC_State)
        //{
        //    string str = this.Configuration.GetConnectionString("myConnectionStrings");
        //    SqlConnection conn = new SqlConnection(str);
        //    conn.Open();
        //    SqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if(modelLOC_State.StateID == null)
        //    {
        //        cmd.CommandText = "PR_LOC_State_Insert";
        //        cmd.Parameters.Add("@Created", SqlDbType.Date).Value = DBNull.Value;
        //    }
        //    else
        //    {
        //        cmd.CommandText = "PR_LOC_State_UpdateByPK";
        //        cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = modelLOC_State.StateID;
        //    }            
        //    cmd.Parameters.Add("@StateName", SqlDbType.NVarChar).Value = modelLOC_State.StateName;
        //    cmd.Parameters.Add("@StateCode", SqlDbType.NVarChar).Value = modelLOC_State.StateCode;
        //    cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = modelLOC_State.CountryID;
        //    cmd.Parameters.Add("@Modified", SqlDbType.Date).Value = DBNull.Value;
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //    return RedirectToAction("Index");
        //}
        #endregion

    }
}
