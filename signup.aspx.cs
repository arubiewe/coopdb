using System;
using System.Configuration;
using System.Security;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Linq;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.SqlClient;
using System.Security.Authentication;


public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    public string encryption(String password)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] encrypt;
        UTF8Encoding encode = new UTF8Encoding();
        //encrypt the given password string into Encrypted data  
        encrypt = md5.ComputeHash(encode.GetBytes(password));
        StringBuilder encryptdata = new StringBuilder();
        //Create a new string by using the encrypted data  
        for (int i = 0; i < encrypt.Length; i++)
        {
            encryptdata.Append(encrypt[i].ToString());
        }
        return encryptdata.ToString();
    }  

    public void Message_click(object sender, EventArgs e)
    {
        string username = TextBox1.Text.ToString();
        String password = TextBox2.Text;
        //Get the encrypt the password by using the class  
        string pass = encryption(password);
        Label1.Text = pass;
        //Check whether the UseName and password are Empty  
        if (username.Length > 0 && password.Length > 0)
        {
            //creating the connection string              
            string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            MySqlConnection con = new MySqlConnection(connection);
            String passwords = encryption(password);
            con.Open();
            // Check whether the Username Found in the Existing DB  
            String search = "SELECT * FROM users WHERE (username = '" + username + "');";
            MySqlCommand cmds = new MySqlCommand (search, con);
            MySqlDataReader sqldrs = cmds.ExecuteReader();
            if (sqldrs.Read())
            {
                String passed = (string)sqldrs["Password"];
                Label1.Text = "Username Already Taken";
                
            }
                

            else
            {
                sqldrs.Close();
                try
                {
                    // if the Username not found create the new user accound  
                    string sql = "INSERT INTO users (username, password ) VALUES ('"  + username + "','" + passwords + "');";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    String Message = "saved Successfully";
                    Label1.Text = Message.ToString();
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Response.Redirect("Default2.aspx");
                }
                catch (Exception ex)
                {
                    //Label1.Text = ex.ToString();
                }
                con.Close();
            }
        }

        else
        {
            String Message = "Username or Password is empty";
            Label1.Text = Message.ToString();
        }
    }
  
    public void login_click(object sender, EventArgs e)  
{  
    String username = TextBox1.Text.ToString();  
    String password = TextBox2.Text;  
    string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();  
    MySqlConnection connection = new MySqlConnection(con);  
    connection.Open();  
//ncrypt the given password  
    string passwords = encryption(password);  
    String query = "SELECT username, password FROM users WHERE (username = '" + username + "') AND (password = '"+passwords+"');";

    MySqlCommand cmd = new MySqlCommand(query, connection);  
        MySqlDataReader sqldr = cmd.ExecuteReader();  
        if (sqldr.Read())  
        {  
                Response.Redirect("Default3.aspx");  
        }  
            else  
            {  
                Label1.Text = "User or password is incorrect not found";   
                 
            }  
          
    connection.Close();  
}  

}