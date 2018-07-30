
using Newtonsoft.Json;
using SmartSheet_V._1._0.CommonLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSheet_V._1._0.Controllers
{
    public class LoginController : Controller
    {
        string consString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginData(string UserName, string UserPassword)
        {
            int employeeId;
            string Email;
            bool userType = false;
            try
            {
              
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("USPTblUserValidLogin"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@Password ", UserPassword);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        con.Close();
                        if (dataTable.Rows.Count > 0)
                        {
                            employeeId = Convert.ToInt32(dataTable.Rows[0]["ID"]);
                            Email = Convert.ToString(dataTable.Rows[0]["UserName"]);
                            
                            Session["EmployeeID"] = employeeId;
                            Session["EmployeeEmail"] = Email;
                            userType = Convert.ToBoolean(dataTable.Rows[0]["EmpISAdmin"]);
                            Session["IsAdmin"] = Convert.ToInt32(userType);
                            return Json(new { id = employeeId, type = userType }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {

                        }

                    }
                }
                
            }
            catch (Exception ex)
            {
               
                return Json(new { id = -1 }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dispose();
            }
            return Json(new { flag = -1 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {

            Session.RemoveAll();
            Session["EmployeeID"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult Forget()
        {
            return View();
        }
        public JsonResult ForgotPasswordSend(string emailId)
        {
      
            bool mailFlag = false;
          
            try
            {
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("[UspEmpForgotPassword]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@UserName", emailId);
                        con.Open();  
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        if (dataTable.Rows.Count > 0)
                        {
                            string password = Convert.ToString(dataTable.Rows[0]["TUUserPassword"]);
                            CommonFunctions functionMail = new CommonFunctions();
                            string LoginLink = (ConfigurationManager.AppSettings["LoginLink"]);
                           
                            mailFlag = functionMail.SendEmail(/*"emailId"*/"sanal@nuvento.com", "", "", "Password for Login","Your password for login is "+ password + ", <br/> Click the below link for login <br/>  " +
                                      LoginLink);
                            return Json(new { flag = mailFlag }, JsonRequestBehavior.AllowGet);
                        }

                            
                        con.Close();
                        return Json(new { flag = 1 }, JsonRequestBehavior.AllowGet);


                    }
                }
                
            }
            catch (Exception ex)
            {
               
                return Json(new { flag = 0 }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                Dispose();
            }
        }

        [HttpPost]
        public ActionResult changePassword(string OldPassword, string NewPassword, int Operation)
        {
            //Dictionary<string, string> outData = new Dictionary<string, string>();
            CommonFunctions functionMail = new CommonFunctions();
            string jResult = string.Empty;
            string updatepass = string.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("VTwo.UspChangePassword"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@OldPassword", OldPassword);
                        cmd.Parameters.AddWithValue("@NewPassword ", NewPassword);
                        cmd.Parameters.AddWithValue("@FK_EmpId ", Convert.ToInt32(Session["EmployeeID"]));
                        cmd.Parameters.AddWithValue("@Operation ", Operation);
                        con.Open();
                        //cmd.ExecuteNonQuery();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        con.Close();
                        if (dataTable.Rows.Count > 0)
                        {
                            if (dataTable.Columns.Contains("ToAddress"))
                            {
                                string msgBody = "Hi,<br/><br/> The password for your SmartSheet account has been successfully changed." +
                                     " If you did not request this change, please contact support immediately.";
                                if (functionMail.SendEmail(Convert.ToString(dataTable.Rows[0]["ToAddress"]), "", "", "Password Change", msgBody))
                                {
                                    updatepass = JsonConvert.SerializeObject("{\"UserUpdated\" : 1}", Formatting.Indented);
                                    if (updatepass != string.Empty)
                                        return Json(updatepass, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {

                                }

                            }
                            else
                                jResult= JsonConvert.SerializeObject(dataTable, Formatting.Indented);
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
                
                return Json("{\"Result\":\"" + ex.Message + "\"}");
            }
            finally
            {
               
            }
            return Json(CommonLibrary.Constants.JsonError);
        }
    }
}
