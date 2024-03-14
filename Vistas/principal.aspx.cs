using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string query = "SELECT * FROM productos_gamer";

        Conexion conexion = new Conexion();
        DataTable productos = conexion.EjecutarConsulta(query);


     
            // Suponiendo que ya tienes tu DataTable productos lleno con los datos de la base de datos
            StringBuilder htmlBuilder = new StringBuilder();

            foreach (DataRow producto in productos.Rows)
            {
                htmlBuilder.Append("<div class=\"col-sm-6 col-lg-4\">");
                htmlBuilder.Append("<div class=\"box\">");
                htmlBuilder.Append("<div class=\"img-box\">");
                htmlBuilder.AppendFormat("<img src=\"{0}\" alt=\"\">", producto["imagen"]);
                htmlBuilder.Append("<a href=\"\" class=\"add_cart_btn\">");
                htmlBuilder.Append("<span>");
                htmlBuilder.Append("Agregar Carrito");
                htmlBuilder.Append("</span>");
                htmlBuilder.Append("</a>");
                htmlBuilder.Append("</div>");
                htmlBuilder.Append("<div class=\"detail-box\">");
                htmlBuilder.AppendFormat("<h5>{0}</h5>", producto["nombre"]);
                htmlBuilder.Append("<div class=\"product_info\">");
                htmlBuilder.AppendFormat("<h5><span>$</span> {0}</h5>", producto["precio"]);
                htmlBuilder.Append("<div class=\"star_container\">");
                htmlBuilder.Append("<i class=\"fa fa-star\" aria-hidden=\"true\"></i>");
                htmlBuilder.Append("<i class=\"fa fa-star\" aria-hidden=\"true\"></i>");
                htmlBuilder.Append("<i class=\"fa fa-star\" aria-hidden=\"true\"></i>");
                htmlBuilder.Append("<i class=\"fa fa-star\" aria-hidden=\"true\"></i>");
                htmlBuilder.Append("<i class=\"fa fa-star\" aria-hidden=\"true\"></i>");
                htmlBuilder.Append("</div>");
                htmlBuilder.Append("</div>");
                htmlBuilder.Append("</div>");
                htmlBuilder.Append("</div>");
                htmlBuilder.Append("</div>");

            }

            // Asigna el HTML generado al control Literal
            litProductos.Text = htmlBuilder.ToString();
        }
    }
}