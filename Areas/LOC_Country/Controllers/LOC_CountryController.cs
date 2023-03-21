using AddressBook.Areas.LOC_Country.Models;
using AddressBook.BAL;
using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook.Areas.LOC_Country.Controllers
{
    [CheckAccess]
    [Area("LOC_Country")]
    [Route("LOC_Country/[controller]/[action]")]

    public class LOC_CountryController : Controller
    {

        LOC_DAL dalLOC = new LOC_DAL();

        
        public LOC_CountryController()
        {
            
        }


        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectAll();
            return View("LOC_CountryList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CountryID)
        {
            if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_Country_DeleteByPK(CountryID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add/Edit

        public IActionResult Add(int? CountryID)
        {

            #region Record Select by PK

            if (CountryID != null)
            {
                DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectByPK(CountryID);
                LOC_CountryModel model = new LOC_CountryModel();
                foreach (DataRow dr in dt.Rows)
                {
                    model.CountryID = Convert.ToInt32(dr["CountryID"]);
                    model.CountryName = dr["CountryName"].ToString();
                    model.CountryCode = dr["CountryCode"].ToString();
                }
                return View("LOC_CountryAddEdit", model);
            }
            #endregion

            return View("LOC_CountryAddEdit");
        }

        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(LOC_CountryModel modelLOC_Country)
        {
            if (ModelState.IsValid)
            {
                if (modelLOC_Country.CountryID == null)
                {
                    if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_Country_Insert(modelLOC_Country)))
                        return RedirectToAction("Index");
                }
                else
                {
                    if (Convert.ToBoolean(dalLOC.dbo_PR_LOC_Country_UpdateByPK(modelLOC_Country)))
                        return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Filter
        public IActionResult Filter(string CountryName, string CountryCode)
        {
            DataTable dt = dalLOC.dbo_PR_LOC_Country_Filter(CountryName, CountryCode);
            return View("LOC_CountryList", dt);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        #endregion

        #region old
        //public IActionResult Add(int? CountryID)
        //{
        //    if(CountryID != null)
        //    {
        //        string str = this.Configuration.GetConnectionString("myConnectionStrings");
        //        DataTable dt = new DataTable();
        //        SqlConnection conn = new SqlConnection(str);
        //        conn.Open();
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "PR_LOC_Country_SelectByPK";
        //        cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
        //        SqlDataReader SDR = cmd.ExecuteReader();
        //        dt.Load(SDR);
        //        LOC_CountryModel modelLOC_Country = new LOC_CountryModel();

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            modelLOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
        //            modelLOC_Country.CountryName = dr["CountryName"].ToString();
        //            modelLOC_Country.CountryCode = dr["CountryCode"].ToString();
        //        }

        //        return View("LOC_CountryAddEdit",modelLOC_Country);
        //    }
        //    return View("LOC_CountryAddEdit");
        //}


        //[HttpPost]
        //public IActionResult Save(LOC_CountryModel modelLOC_Country)
        //{
        //        string str = this.Configuration.GetConnectionString("myConnectionStrings");
        //        SqlConnection conn = new SqlConnection(str);
        //        conn.Open();
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        if (modelLOC_Country.CountryID == null)
        //        {
        //            cmd.CommandText = "PR_LOC_Country_Insert";
        //            cmd.Parameters.Add("@Created", SqlDbType.Date).Value = DBNull.Value;
        //        }
        //        else
        //        {
        //            cmd.CommandText = "PR_LOC_Country_UpdateByPK";
        //            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = modelLOC_Country.CountryID;
        //        }
        //        cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = modelLOC_Country.CountryName;
        //        cmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar).Value = modelLOC_Country.CountryCode;
        //        cmd.Parameters.Add("@Modified", SqlDbType.Date).Value = DBNull.Value;
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //        return RedirectToAction("Index");
        //}
        #endregion

    }
}
