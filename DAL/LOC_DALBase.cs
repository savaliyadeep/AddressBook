using AddressBook.Areas.LOC_City.Models;
using AddressBook.Areas.LOC_Country.Models;
using AddressBook.Areas.LOC_State.Models;
using AddressBook.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace AddressBook.DAL
{
    public class LOC_DALBase : DALHelper
    {
        #region SelectAll

        #region Method: dbo.PR_LOC_Country_SelectAll
        public DataTable dbo_PR_LOC_Country_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_SelectAll");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                DataTable dt = new DataTable();

                using(IDataReader dr = sqlDB.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;

            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: dbo.PR_LOC_State_SelectAll
        public DataTable dbo_PR_LOC_State_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectAll");
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

        #region Method: dbo.PR_LOC_City_SelectAll
        public DataTable dbo_PR_LOC_City_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_SelectAll");
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

        #endregion

        #region DropDown

        #region Method: dbo_PR_LOC_Country_SelectForDropDown
        public DataTable dbo_PR_LOC_Country_SelectForDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("PR_LOC_Country_SelectForDropDown");
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

        #region Method: dbo_PR_LOC_State_SelectForDropDown
        public DataTable dbo_PR_LOC_State_SelectForDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectForDropDown");
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

        #region Method: dbo_PR_LOC_State_SelectForDropDownByCountryID
        public DataTable dbo_PR_LOC_State_SelectForDropDownByCountryID(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString); 
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectDropDownByCountryID");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, CountryID);
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

        #region Method: dbo_PR_LOC_City_SelectForDropDown
        public DataTable dbo_PR_LOC_City_SelectForDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_SelectForDropDown");
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

        #region Method: dbo_PR_LOC_City_SelectForDropDownByStateID
        public DataTable dbo_PR_LOC_City_SelectForDropDownByStateID(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_SelectDropDownByStateID");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, StateID);
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

        #endregion

        #region Delete

        #region Method: dbo_PR_LOC_Country_DeleteByPK
        public bool? dbo_PR_LOC_Country_DeleteByPK(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_DeleteByPK");
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, CountryID);

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_LOC_State_DeleteByPK
        public bool? dbo_PR_LOC_State_DeleteByPK(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_DeleteByPK");
                sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, StateID);

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_LOC_City_DeleteByPK
        public bool? dbo_PR_LOC_City_DeleteByPK(int? CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_DeleteByPK");
                sqlDB.AddInParameter(cmd, "CityID", SqlDbType.Int, CityID);

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region Insert

        #region Method: dbo_PR_LOC_Country_Insert
        public bool? dbo_PR_LOC_Country_Insert(LOC_CountryModel modelLOC_Country)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_Insert");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(cmd, "CountryName", SqlDbType.NVarChar, modelLOC_Country.CountryName);
                sqlDB.AddInParameter(cmd, "CountryCode", SqlDbType.NVarChar, modelLOC_Country.CountryCode);
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

        #region Method: dbo_PR_LOC_State_Insert
        public bool? dbo_PR_LOC_State_Insert(LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_Insert");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(cmd, "StateName", SqlDbType.NVarChar, modelLOC_State.StateName);
                sqlDB.AddInParameter(cmd, "StateCode", SqlDbType.NVarChar, modelLOC_State.StateCode);
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, modelLOC_State.CountryID);
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

        #region Method: dbo_PR_LOC_City_Insert
        public bool? dbo_PR_LOC_City_Insert(LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_Insert");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(cmd, "CityName", SqlDbType.NVarChar, modelLOC_City.CityName);
                sqlDB.AddInParameter(cmd, "CityCode", SqlDbType.NVarChar, modelLOC_City.CityCode);
                sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, modelLOC_City.StateID);
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, modelLOC_City.CountryID);
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

        #endregion

        #region SelectByPK

        #region Method: dbo_PR_LOC_Country_SelectByPK
        public DataTable dbo_PR_LOC_Country_SelectByPK(int? CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_SelectByPK");
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, CountryID);

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

        #region Method: dbo_PR_LOC_State_SelectByPK
        public DataTable dbo_PR_LOC_State_SelectByPK(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_SelectByPK");
                sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, StateID);

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

        #region Method: dbo_PR_LOC_City_SelectByPK
        public DataTable dbo_PR_LOC_City_SelectByPK(int? CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_SelectByPK");
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

        #endregion

        #region Update

        #region Method: dbo_PR_LOC_Country_UpdateByPK
        public bool? dbo_PR_LOC_Country_UpdateByPK(LOC_CountryModel modelLOC_Country)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_UpdateByPK");
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, modelLOC_Country.CountryID);
                sqlDB.AddInParameter(cmd, "CountryName", SqlDbType.NVarChar, modelLOC_Country.CountryName);
                sqlDB.AddInParameter(cmd, "CountryCode", SqlDbType.NVarChar, modelLOC_Country.CountryCode);
                sqlDB.AddInParameter(cmd, "Modified", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int,CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(cmd);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_LOC_State_UpdateByPK
        public bool? dbo_PR_LOC_State_UpdateByPK(LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_UpdateByPK");
                sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, modelLOC_State.StateID);
                sqlDB.AddInParameter(cmd, "StateName", SqlDbType.NVarChar, modelLOC_State.StateName);
                sqlDB.AddInParameter(cmd, "StateCode", SqlDbType.NVarChar, modelLOC_State.StateCode);
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, modelLOC_State.CountryID);
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

        #region Method: dbo_PR_LOC_City_UpdateByPK
        public bool? dbo_PR_LOC_City_UpdateByPK(LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_UpdateByPK");
                sqlDB.AddInParameter(cmd, "CityID", SqlDbType.Int, modelLOC_City.CityID);
                sqlDB.AddInParameter(cmd, "CityName", SqlDbType.NVarChar, modelLOC_City.CityName);
                sqlDB.AddInParameter(cmd, "CityCode", SqlDbType.NVarChar, modelLOC_City.CityCode);
                sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, modelLOC_City.StateID);
                sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, modelLOC_City.CountryID);
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

        #endregion

        #region Filter

        #region Method: dbo_PR_LOC_Country_Filter

        public DataTable dbo_PR_LOC_Country_Filter(string CountryName, string CountryCode)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_Country_Filter");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                if (CountryName == null)
                    sqlDB.AddInParameter(cmd, "CountryName", SqlDbType.NVarChar, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CountryName", SqlDbType.NVarChar, CountryName);
                if (CountryCode == null)
                    sqlDB.AddInParameter(cmd, "CountryCode", SqlDbType.NVarChar, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CountryCode", SqlDbType.NVarChar, CountryCode);

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

        #region Method: dbo_PR_LOC_State_Filter

        public DataTable dbo_PR_LOC_State_Filter(int? CountryID, string StateName, string StateCode)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_State_Filter");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                if (CountryID < 1)
                    sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, CountryID);
                if (StateName == null)
                    sqlDB.AddInParameter(cmd, "StateName", SqlDbType.NVarChar, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "StateName", SqlDbType.NVarChar, StateName);
                if (StateCode == null)
                    sqlDB.AddInParameter(cmd, "StateCode", SqlDbType.NVarChar, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "StateCode", SqlDbType.NVarChar, StateCode);

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

        #region Method: dbo_PR_LOC_City_Filter

        public DataTable dbo_PR_LOC_City_Filter(int? CountryID, int? StateID, string CityName, string CityCode)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand cmd = sqlDB.GetStoredProcCommand("dbo.PR_LOC_City_Filter");
                sqlDB.AddInParameter(cmd, "UserID", SqlDbType.Int, CV.UserID());
                if (CountryID < 1)
                    sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CountryID", SqlDbType.Int, CountryID);
                if (StateID < 1)
                    sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "StateID", SqlDbType.Int, StateID);
                if (CityName == null)
                    sqlDB.AddInParameter(cmd, "CityName", SqlDbType.NVarChar, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CityName", SqlDbType.NVarChar, CityName);
                if (CityCode == null)
                    sqlDB.AddInParameter(cmd, "CityCode", SqlDbType.NVarChar, DBNull.Value);
                else
                    sqlDB.AddInParameter(cmd, "CityCode", SqlDbType.NVarChar, CityCode);

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

        #endregion


    }
}
