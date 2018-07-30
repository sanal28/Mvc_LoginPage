using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSheet_V._1._0.CommonLibrary;

namespace SmartSheet_V._1._0.Controllers
{
    public class RegistrationController : Controller
    {
        string consString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        // GET: Registration
        [SessionAuthorize]
        public ActionResult Employeeregistration()
        {
            return View();
        }

        public JsonResult GetTeamName()
        {

            try
            {
                string jResult = string.Empty;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("VTwo.UspDropDownBind"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@ID_Module", 2);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        con.Close();
                        if (dataTable.Rows.Count > 0)
                        {
                            // return (dataTable);
                            jResult = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
                            if (jResult != string.Empty)
                                return Json(jResult, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Dispose();
            }
            return Json(new { flag = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserName()
        {

            try
            {
                string jResult = string.Empty;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("VTwo.UspDropDownBind"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@ID_Module", 3);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        con.Close();
                        if (dataTable.Rows.Count > 0)
                        {
                            // return (dataTable);
                            jResult = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
                            if (jResult != string.Empty)
                                return Json(jResult, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {

                        }

                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Dispose();
            }
            return Json(new { flag = false }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult EmployeeReg( string Firstname, string MiddleName, string LastName, string ExcelName,
            string passWord, string emailId)
        {
            try
            {
                bool EmployeeCreationflag;

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("VTwo.USPTblCustomerDetailsUpdate"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;  
                        cmd.Parameters.AddWithValue("@ID_CustomerDetails", 0);
                        cmd.Parameters.AddWithValue("@CustFirstName", Firstname);
                        cmd.Parameters.AddWithValue("@CustMiddleName", MiddleName);
                        cmd.Parameters.AddWithValue("@CustLastName", LastName);
                        cmd.Parameters.AddWithValue("@CustExcelName", ExcelName);
                        cmd.Parameters.AddWithValue("@ISDeleted", 0);
                        cmd.Parameters.AddWithValue("@ID_TblUsers", 0);
                        cmd.Parameters.AddWithValue("@TUUserEmail", emailId);
                        cmd.Parameters.AddWithValue("@TUUserPassword", passWord);
                        cmd.Parameters.AddWithValue("@TUClosedOn", DBNull.Value);
                        cmd.Parameters.AddWithValue("@EnteredBy", Convert.ToInt32(Session["EmployeeID"]));
                        cmd.Parameters.AddWithValue("@Action", 1);
                        con.Open();
                        EmployeeCreationflag = Convert.ToBoolean(cmd.ExecuteNonQuery());
                        con.Close();
                        if (EmployeeCreationflag == true)
                        {
                            CommonFunctions functionMail = new CommonFunctions();
                            functionMail.SendEmail(emailId, "", "", "Smart Sheet Employee registration ", "Smart Sheet registration successful and your " +
                                "UserName :" + emailId + " <br/> Password :" + passWord);
                        }
                        return Json(new { flag = 1 }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {

                return Json(new { flag = -2 }, JsonRequestBehavior.AllowGet);
            }

            finally
            {
                Dispose();
            }
        }
        public JsonResult UpdateEmployeeReg(int EmployeeId, string Firstname, string MiddleName, 
            string LastName, string ExcelName)
        {
            try
            {


                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("VTwo.USPTblCustomerDetailsUpdate"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@ID_CustomerDetails", EmployeeId);
                        cmd.Parameters.AddWithValue("@CustFirstName", Firstname);
                        cmd.Parameters.AddWithValue("@CustMiddleName", MiddleName);
                        cmd.Parameters.AddWithValue("@CustLastName", LastName);
                        cmd.Parameters.AddWithValue("@CustExcelName", ExcelName);
                        cmd.Parameters.AddWithValue("@ISDeleted", 0);
                        cmd.Parameters.AddWithValue("@ID_TblUsers", 0);
                        cmd.Parameters.AddWithValue("@TUUserEmail", "");
                        cmd.Parameters.AddWithValue("@TUUserPassword", "");
                        cmd.Parameters.AddWithValue("@TUClosedOn", DBNull.Value);
                        cmd.Parameters.AddWithValue("@EnteredBy", Convert.ToInt32(Session["EmployeeID"]));
                        cmd.Parameters.AddWithValue("@Action", 2);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        return Json(new { flag = 1 }, JsonRequestBehavior.AllowGet);


                    }
                }
            }
            catch (Exception ex)
            {

                return Json(new { flag = -2 }, JsonRequestBehavior.AllowGet);
            }

            finally
            {
                Dispose();
            }
            //return Json(new { flag = -1 }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteEmployeeReg(int EmployeeId)
        {
            try
            {


                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("VTwo.USPTblCustomerDetailsUpdate"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@ID_CustomerDetails", EmployeeId);
                        cmd.Parameters.AddWithValue("@CustFirstName", "");
                        cmd.Parameters.AddWithValue("@CustMiddleName", "");
                        cmd.Parameters.AddWithValue("@CustLastName", "");
                        cmd.Parameters.AddWithValue("@CustExcelName", "");
                        cmd.Parameters.AddWithValue("@ISDeleted", 1);
                        cmd.Parameters.AddWithValue("@ID_TblUsers", 0);
                        cmd.Parameters.AddWithValue("@TUUserEmail", "");
                        cmd.Parameters.AddWithValue("@TUUserPassword", "");
                        cmd.Parameters.AddWithValue("@TUClosedOn", DBNull.Value);
                        cmd.Parameters.AddWithValue("@EnteredBy", Convert.ToInt32(Session["EmployeeID"]));
                        cmd.Parameters.AddWithValue("@Action", 3);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        return Json(new { flag = 1 }, JsonRequestBehavior.AllowGet);


                    }
                }
            }
            catch (Exception ex)
            {

                return Json(new { flag = -2 }, JsonRequestBehavior.AllowGet);
            }

            finally
            {
                Dispose();
            }
            //return Json(new { flag = -1 }, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult EmpDetailsFirstLoad()
        {

            try
            {
                string jResult = string.Empty;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("VTwo.USPTblCustomerDetailsSelect"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        con.Close();
                        if (dataTable.Rows.Count > 0)
                        {
                            // return (dataTable);
                            jResult = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
                            if (jResult != string.Empty)
                                return Json(jResult, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return Json(new { flag = false }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dispose();
            }
            return Json(CommonLibrary.Constants.JsonError, JsonRequestBehavior.AllowGet);
        }
       
    }
}
