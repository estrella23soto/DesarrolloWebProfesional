using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;

public partial class Vistas_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateAndDisplayCaptcha();
        }

    }

    protected void GenerateAndDisplayCaptcha()
    {
        Session["CaptchaText"] = "";
        LCaptcha c = new LCaptcha();
        Tuple<System.Drawing.Image, string> captcha = c.GenerateCaptcha();
        string captchaText = captcha.Item2;

        // Almacena el texto del captcha en una variable de sesión para que al momento de refrescar 
        Session["CaptchaText"] = captchaText;

        // Guarda la imagen del captcha en un MemoryStream y establece la URL de la imagen en el control Image
        using (MemoryStream ms = new MemoryStream())
        {
            captcha.Item1.Save(ms, ImageFormat.Png);
            imgCaptcha.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
        }

        // Libera los recursos de la imagen
        captcha.Item1.Dispose();
    }


    protected void btncaptcha_Click(object sender, EventArgs e)
    {
        string userInput = txtCaptcha.Text.Trim(); 

        string captchaText = Session["CaptchaText"] as string;

        if (userInput.Equals(captchaText, StringComparison.OrdinalIgnoreCase)) 
        {
            // Captcha correcto, mostrar el botón y mensaje
            //lbtnacceso.Visible = true;
            txtCaptcha.Visible = false;
            Conexion con = new Conexion();
            string usuario = txtuser.Text;
            string pass = txtpassword.Text;
            string consulta = "select idusuario from usuarios where email='" + usuario + "' and password='" + pass + "'";
            var res = con.EjecutarConsulta(consulta);
            int valorColumna = 0;

            if (res.Rows.Count > 0 && res.Rows[0]["idusuario"] != DBNull.Value)
            {
                valorColumna = Convert.ToInt32(res.Rows[0]["idusuario"]);
                Session["idusuario"] = valorColumna;
                Response.Redirect("principal.aspx");
            }
            else
            {
                lblRespuesta.Text = "Las Credenciales son invalidas";
            }
        }
        else
        {
         
            lblRespuesta.Text = "Captcha incorrecto. Inténtalo de nuevo.";
            lbtnacceso.Visible = false; 
        }

    }

    protected void lbtnacceso_Click(object sender, EventArgs e)
    {
        Conexion con = new Conexion();
        string usuario = txtuser.Text;
         string pass = txtpassword.Text;
        string consulta = "select [idusuario] from usuarios where email='"+usuario +"' and password='"+ pass +"'";
       var res =  con.EjecutarConsulta(consulta);
        int valorColumna = 0; 

        if (res.Rows.Count > 0 && res.Rows[0]["columna"] != DBNull.Value)
        {
            valorColumna = Convert.ToInt32(res.Rows[0]["columna"]);
            Response.Redirect("OtraPagina.aspx");
        }
        else
        {
            lblRespuesta.Text = "Las Credenciales son invalidas";
        }
        
    }
}