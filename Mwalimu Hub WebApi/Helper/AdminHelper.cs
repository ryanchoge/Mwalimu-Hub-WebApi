using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_API.Models;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using XSystem.Security.Cryptography;
using System.Data.SqlClient;

namespace Mwalimu_Hub_WebApi.Helper
{
    public class AdminHelper
    {
       
        
        //public static string CreateAdmin(Admin admin)
        //{
        //    DatabaseHelper databaseHelper = new DatabaseHelper();
        //    try {
        //        string mainId = admin.id.ToString() ;
        //        byte[] passwordHash = Encoding.UTF8.GetBytes(password);
        //        SHA512Managed sha = new SHA512Managed();
        //        byte[] hashedPassword = sha.ComputeHash(passwordHash);
        //        if (mainId == null)
        //        {
        //            mainId = "-1";
        //        }
        //        SqlParameter[] sqlParameters = { new SqlParameter("@id", mainId), new SqlParameter("@name", name), new SqlParameter("@Email", email), new SqlParameter("@password", hashedPassword), new SqlParameter("@userid", userid) };
        //        int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SpSaveAdmin", sqlParameters);

        //        if (rowsAffected == 1 && mainId == "-1")
        //        {
        //            return("Admin added successfully");
                    
        //        }
        //        else if (rowsAffected == 0 && mainId != "-1")
        //        {
        //            return("Admin updated successfully");;
        //            //LoadData();
        //            //mainId = null;
        //        }
        //        else
        //        {
        //           return("Admin Already Exists");
        //          // LoadData();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return($"An error occurred: {ex.Message}");
        //    }

            
        //}
        public static void EditAdmin(Admin admin)
        {

        }
        public static void DeleteAdmin(int id)
        {
            //try
            //{
            //    //DialogResult dialogResult = MessageBox.Show($"Are you sure you want to Delete {AdminName}", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        SqlParameter[] sqlParameters = { new SqlParameter("@Id", id) };
            //        int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SPDeleteAdmin", sqlParameters);
            //        if (rowsAffected == 1)
            //        {
            //            return("Deleted successfully");
            //            //LoadData();
            //        }
                
            //}
            //catch (Exception ex)
            //{
            //   return (E);
            //}
        }

    }
}
