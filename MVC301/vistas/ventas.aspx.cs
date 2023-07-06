using MVC301.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC301.vistas
{
    public partial class ventas : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MVC301.Models.ventas vent1 = new MVC301.Models.ventas();

            vent1.IdVenta = int.Parse(TextBox1.Text);
            vent1.FechaVenta =  DateTime.Parse(TextBox2.Text);
            vent1.ClaveP = int.Parse(TextBox3.Text);
            vent1.IdP = int.Parse(TextBox4.Text);
            
            db.ventas.Add(vent1);
            db.SaveChanges();
            Label6.Text = "Se agrego un nuevo producto";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                int IdVenta = int.Parse(TextBox1.Text);
                MVC301.Models.ventas vent1 = db.ventas.Find(IdVenta);

                if (vent1 != null)
                {
                    TextBox2.Text = vent1.FechaVenta.ToString();
                    TextBox3.Text = vent1.ClaveP.ToString();
                    TextBox4.Text = vent1.IdP.ToString();
                    
                    Label6.Text = "Se mostraron los datos";
                }
                else
                {
                    Label6.Text = "No se encontró el proveedor con el ID especificado";
                }
            }
            catch (Exception ex)
            {
                Label6.Text = "Ocurrió un error: " + ex.Message;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int IdVenta = int.Parse(TextBox1.Text);
                MVC301.Models.ventas vent1 = db.ventas.Find(IdVenta);

                if (vent1 != null)
                {
                    db.ventas.Remove(vent1);
                    db.SaveChanges();
                    Label6.Text = "Se ha eliminado con éxito";
                }
                else
                {
                    Label6.Text = "No se encontró el producto con la clave especificada";
                }
            }
            catch (Exception ex)
            {
                Label6.Text = "Error al eliminar: " + ex.Message;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MVC301.Models.ventas vent1 = db.ventas.Find(int.Parse(TextBox1.Text));
            vent1.IdVenta = int.Parse(TextBox1.Text);
            vent1.FechaVenta = DateTime.Parse(TextBox2.Text);
            vent1.ClaveP= int.Parse(TextBox3.Text);
            vent1.IdP = int.Parse(TextBox4.Text);
            
            db.Entry(vent1).State = EntityState.Modified;
            db.SaveChanges();
            Label6.Text = "Se ha modificado con exito";
        }
    }
}