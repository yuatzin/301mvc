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
    public partial class productos : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MVC301.Models.productos prod1 = new MVC301.Models.productos();

            prod1.claveP = int.Parse(TextBox1.Text);
            prod1.descripcion = TextBox2.Text;
            prod1.precio = float.Parse(TextBox3.Text);
            prod1.existencias = int.Parse(TextBox4.Text);
            prod1.IdP = int.Parse(TextBox5.Text);
            db.productos.Add(prod1);
            db.SaveChanges();
            Label6.Text = "Se agrego un nuevo producto";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                int claveP = int.Parse(TextBox1.Text);
                MVC301.Models.productos prod1 = db.productos.Find(claveP);

                if (prod1 != null)
                {
                    TextBox2.Text = prod1.descripcion;
                    TextBox3.Text = prod1.precio.ToString();
                    TextBox4.Text = prod1.existencias.ToString();
                    TextBox5.Text = prod1.IdP.ToString();
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
                int clave = int.Parse(TextBox1.Text);
                MVC301.Models.productos prod1 = db.productos.Find(clave);

                if (prod1 != null)
                {
                    db.productos.Remove(prod1);
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
            MVC301.Models.productos prod1 = db.productos.Find(int.Parse(TextBox1.Text));
            prod1.claveP = int.Parse(TextBox1.Text);
            prod1.descripcion = TextBox2.Text;
            prod1.precio = float.Parse(TextBox3.Text);
            prod1.existencias = int.Parse(TextBox4.Text);
            prod1.IdP = int.Parse(TextBox5.Text);
            db.Entry(prod1).State = EntityState.Modified;
            db.SaveChanges();
            Label6.Text = "Se ha modificado con exito";
        }
    }
    }
