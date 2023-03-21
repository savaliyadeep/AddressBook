using AddressBook.Areas.LOC_Country.Models;
using AddressBook.Areas.MST_ContactCategory.Models;
using AddressBook.BAL;
using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook.Areas.MST_ContactCategory.Controllers
{
    [CheckAccess]
    [Area("MST_ContactCategory")]
    [Route("MST_ContactCategory/[controller]/[action]")]

    public class MST_ContactCategoryController : Controller
    {
        CON_DAL dalCON = new CON_DAL();

        public MST_ContactCategoryController()
        {
         
        }

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalCON.dbo_PR_MST_ContactCategory_SelectAll( );
            return View("MST_ContactCategoryList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CategoryID)
        {
            if (Convert.ToBoolean(dalCON.dbo_PR_MST_ContactCategory_DeleteByPK(CategoryID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add/Edit

        public IActionResult Add(int? CategoryID)
        {

            #region Record Select by PK

            if (CategoryID != null)
            {
                DataTable dt = dalCON.dbo_PR_MST_ContactCayegory_SelectByPK(CategoryID);
                MST_ContactCategoryModel model = new MST_ContactCategoryModel();
                foreach (DataRow dr in dt.Rows)
                {
                    model.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    model.CategoryName = dr["CategoryName"].ToString();
                }
                return View("MST_ContactCategoryAddEdit", model);
            }
            #endregion

            return View("MST_ContactCategoryAddEdit");
        }

        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(MST_ContactCategoryModel modelMST_ContactCategory)
        {
            if (ModelState.IsValid)
            {
                if (modelMST_ContactCategory.CategoryID == null)
                {
                    if (Convert.ToBoolean(dalCON.dbo_PR_MST_ContactCategory_Insert(modelMST_ContactCategory)))
                        return RedirectToAction("Index");
                }
                else
                {
                    if (Convert.ToBoolean(dalCON.dbo_PR_MST_ContactCategory_UpdateByPK(modelMST_ContactCategory)))
                        return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Filter
        public IActionResult Filter(string CategoryName)
        {
            DataTable dt = dalCON.dbo_PR_MST_ContactCategory_Filter(CategoryName);
            return View("MST_ContactCategoryList", dt);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region old
        //public IActionResult Add(int? CategoryID)
        //{
        //    if (CategoryID != null)
        //    {
        //        string str = Configuration.GetConnectionString("myConnectionStrings");
        //        DataTable dt = new DataTable();
        //        SqlConnection conn = new SqlConnection(str);
        //        conn.Open();
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "PR_MST_ContactCategory_SelectByPK";
        //        cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        //        SqlDataReader SDR = cmd.ExecuteReader();
        //        dt.Load(SDR);
        //        MST_ContactCategoryModel modelMST_ContactCategory = new MST_ContactCategoryModel();

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            modelMST_ContactCategory.CategoryID = Convert.ToInt32(dr["CategoryID"]);
        //            modelMST_ContactCategory.CategoryName = dr["CategoryName"].ToString();
        //            modelMST_ContactCategory.Created = Convert.ToDateTime(dr["Created"]);
        //            modelMST_ContactCategory.Modified = Convert.ToDateTime(dr["Modified"]);
        //        }

        //        return View("MST_ContactCategoryAddEdit", modelMST_ContactCategory);
        //    }
        //    return View("MST_ContactCategoryAddEdit");
        //}


        //[HttpPost]
        //public IActionResult Save(MST_ContactCategoryModel modelMST_ContactCategory)
        //{
        //    string str = Configuration.GetConnectionString("myConnectionStrings");
        //    SqlConnection conn = new SqlConnection(str);
        //    conn.Open();
        //    SqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if (modelMST_ContactCategory.CategoryID == null)
        //    {
        //        cmd.CommandText = "PR_MST_ContactCategory_Insert";
        //        cmd.Parameters.Add("@Created", SqlDbType.Date).Value = DBNull.Value;
        //    }
        //    else
        //    {
        //        cmd.CommandText = "PR_MST_ContactCategory_UpdateByPK";
        //        cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = modelMST_ContactCategory.CategoryID;
        //    }
        //    cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = modelMST_ContactCategory.CategoryName;
        //    cmd.Parameters.Add("@Modified", SqlDbType.Date).Value = DBNull.Value;
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //    return RedirectToAction("Index");
        //}
        #endregion
    }
}
