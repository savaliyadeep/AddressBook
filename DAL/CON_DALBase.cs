using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using AddressBook.Areas.LOC_Country.Models;
using AddressBook.Areas.CON_Contact.Models;
using AddressBook.Areas.MST_ContactCategory.Models;
using AddressBook.BAL;

namespace AddressBook.DAL
{
    public class CON_DALBase : DALHelper
    {
        #region dbo.PR_CON_Contact_SelectAll
        public DataTable dbo_PR_CON_Contact_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_CON_Contact_SelectAll");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion

        #region dbo.PR_MST_ContactCategory_SelectAll
        public DataTable dbo_PR_MST_ContactCategory_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_MST_ContactCategory_SelectAll");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_CON_Contact_SelectByPK

        public DataTable dbo_PR_CON_Contact_SelectByPK(int? ContactID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_CON_Contact_SelectByPK");
                sqlDB.AddInParameter(cmd, "ContactID", SqlDbType.Int, ContactID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_MST_ContactCayegory_SelectByPK

        public DataTable dbo_PR_MST_ContactCayegory_SelectByPK(int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_MST_ContactCategory_SelectByPK");
                sqlDB.AddInParameter(cmd, "CategoryID", SqlDbType.Int, CategoryID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_CON_Contact_Insert

        public bool? dbo_PR_CON_Contact_Insert(CON_ContactModel modelCON_Contact)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_CON_Contact_Insert");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(cmd, "PhotoPath", SqlDbType.NVarChar, modelCON_Contact.PhotoPath);
                sqlDB.AddInParameter(cmd, "ContactName", SqlDbType.NVarChar, modelCON_Contact.ContactName);
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, modelCON_Contact.CountryID);
                sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, modelCON_Contact.StateID);
                sqlDB.AddInParameter(cmd, "CityID", SqlDbType.Int, modelCON_Contact.CityID);
                sqlDB.AddInParameter(cmd, "CategoryID", SqlDbType.Int, modelCON_Contact.CategoryID);
                sqlDB.AddInParameter(cmd, "Address", SqlDbType.NVarChar, modelCON_Contact.Address);
                sqlDB.AddInParameter(cmd, "PinCode", SqlDbType.NVarChar, modelCON_Contact.PinCode);
                sqlDB.AddInParameter(cmd, "Mobile", SqlDbType.NVarChar, modelCON_Contact.Mobile);
                sqlDB.AddInParameter(cmd, "AContact", SqlDbType.NVarChar, modelCON_Contact.AlternateContact);
                sqlDB.AddInParameter(cmd, "Email", SqlDbType.NVarChar, modelCON_Contact.Email);
                sqlDB.AddInParameter(cmd, "BirthDate", SqlDbType.DateTime, modelCON_Contact.BirthDate);
                sqlDB.AddInParameter(cmd, "LinkedIn", SqlDbType.NVarChar, modelCON_Contact.LinkedIn);
                sqlDB.AddInParameter(cmd, "Twitter", SqlDbType.NVarChar, modelCON_Contact.Twitter);
                sqlDB.AddInParameter(cmd, "Instagram", SqlDbType.NVarChar, modelCON_Contact.Instagram);
                sqlDB.AddInParameter(cmd, "Gender", SqlDbType.NVarChar, modelCON_Contact.Gender);
                sqlDB.AddInParameter(cmd, "Created", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(cmd, "Modified", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_MST_ContactCategory_Insert

        public bool? dbo_PR_MST_ContactCategory_Insert(MST_ContactCategoryModel modelMST_ContactCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_MST_ContactCategory_Insert");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(cmd, "CategoryName", SqlDbType.NVarChar, modelMST_ContactCategory.CategoryName);
                sqlDB.AddInParameter(cmd, "Created", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(cmd, "Modified", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_CON_Contact_UpdateByPK

        public bool? dbo_PR_CON_Contact_UpdateByPK(CON_ContactModel modelCON_Contact)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_CON_Contact_UpdateByPK");
                sqlDB.AddInParameter(cmd, "ContactID", SqlDbType.Int, modelCON_Contact.ContactID);
                sqlDB.AddInParameter(cmd, "PhotoPath", SqlDbType.NVarChar, modelCON_Contact.PhotoPath);
                sqlDB.AddInParameter(cmd, "ContactName", SqlDbType.NVarChar, modelCON_Contact.ContactName);
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, modelCON_Contact.CountryID);
                sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, modelCON_Contact.StateID);
                sqlDB.AddInParameter(cmd, "CityID", SqlDbType.Int, modelCON_Contact.CityID);
                sqlDB.AddInParameter(cmd, "CategoryID", SqlDbType.Int, modelCON_Contact.CategoryID);
                sqlDB.AddInParameter(cmd, "Address", SqlDbType.NVarChar, modelCON_Contact.Address);
                sqlDB.AddInParameter(cmd, "PinCode", SqlDbType.NVarChar, modelCON_Contact.PinCode);
                sqlDB.AddInParameter(cmd, "Mobile", SqlDbType.NVarChar, modelCON_Contact.Mobile);
                sqlDB.AddInParameter(cmd, "AContact", SqlDbType.NVarChar, modelCON_Contact.AlternateContact);
                sqlDB.AddInParameter(cmd, "Email", SqlDbType.NVarChar, modelCON_Contact.Email);
                sqlDB.AddInParameter(cmd, "BirthDate", SqlDbType.DateTime, modelCON_Contact.BirthDate);
                sqlDB.AddInParameter(cmd, "LinkedIn", SqlDbType.NVarChar, modelCON_Contact.LinkedIn);
                sqlDB.AddInParameter(cmd, "Twitter", SqlDbType.NVarChar, modelCON_Contact.Twitter);
                sqlDB.AddInParameter(cmd, "Instagram", SqlDbType.NVarChar, modelCON_Contact.Instagram);
                sqlDB.AddInParameter(cmd, "Gender", SqlDbType.NVarChar, modelCON_Contact.Gender);
                sqlDB.AddInParameter(cmd, "Modified", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_MST_ContactCategory_UpdateByPK

        public bool? dbo_PR_MST_ContactCategory_UpdateByPK(MST_ContactCategoryModel modelMST_ContactCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_MST_ContactCategory_UpdateByPK");
                sqlDB.AddInParameter(cmd, "CategoryID", SqlDbType.Int, modelMST_ContactCategory.CategoryID);
                sqlDB.AddInParameter(cmd, "CategoryName", SqlDbType.NVarChar, modelMST_ContactCategory.CategoryName);
                sqlDB.AddInParameter(cmd, "Modified", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_CON_Contact_DeleteByPK

        public bool? dbo_PR_CON_Contact_DeleteByPK(int? ContactID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_CON_Contact_DeleteByPK");
                sqlDB.AddInParameter(cmd, "ContactID", SqlDbType.Int, ContactID);

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion

        #region Method: dbo_PR_MST_ContactCategory_DeleteByPK

        public bool? dbo_PR_MST_ContactCategory_DeleteByPK(int? CategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_MST_ContactCategory_DeleteByPK");
                sqlDB.AddInParameter(cmd, "CategoryID", SqlDbType.Int, CategoryID);

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_MST_ContactCategory_SelectForDropDown

        public DataTable dbo_PR_MST_ContactCategory_SelectForDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("PR_MST_ContactCategory_SelectForDropDown");
                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_CON_Contcat_Filter

        public DataTable dbo_PR_CON_Contact_Filter(int? CountryID, int? StateID, int? CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_CON_Contact_Filter");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                if (CountryID < 1)
                    sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, CountryID);
                if (StateID < 1)
                    sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, StateID);
                if (CityID < 1)
                    sqlDB.AddInParameter(cmd, "CityID", SqlDbType.Int, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CityID", SqlDbType.Int, CityID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Method: dbo_PR_MST_ContactCategory_Filter

        public DataTable dbo_PR_MST_ContactCategory_Filter(string CategoryName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_MST_ContactCategory_Filter");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                if (CategoryName == null)
                    sqlDB.AddInParameter(cmd, "CategoryName", SqlDbType.NVarChar, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CategoryName", SqlDbType.NVarChar, CategoryName);
                
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
