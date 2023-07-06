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
    public partial class proveedores : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();

        


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MVC301.Models.proveedores prov1 = new MVC301.Models.proveedores();
            prov1.IdP =int.Parse( TextBox1.Text);
            prov1.NombreP = TextBox2.Text;
            db.proveedores.Add(prov1);
            db.SaveChanges();
            Label3.Text = "Se ha agregado exitosamente";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            MVC301.Models.proveedores prov1 = db.proveedores.Find(int.Parse(TextBox1.Text));
            prov1.IdP = int.Parse(TextBox1.Text);
            prov1.NombreP = TextBox2.Text;
            db.proveedores.Remove(prov1);
            db.SaveChanges();
            Label3.Text = "Se ha eliminado con exito";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MVC301.Models.proveedores prov1 = db.proveedores.Find(int.Parse(TextBox1.Text));
            prov1.IdP = int.Parse(TextBox1.Text);
            prov1.NombreP = TextBox2.Text;
            db.Entry(prov1).State = EntityState.Modified;
            db.SaveChanges();
            Label3.Text = "Se ha modificado con exito";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
                try
                {
                    int IdP = int.Parse(TextBox1.Text);
                MVC301.Models.proveedores prov1 = db.proveedores.Find(IdP);

                    if (prov1 != null)
                    {
                        TextBox2.Text = prov1.NombreP;
                        Label3.Text = "Se mostraron los datos";
                    }
                    else
                    {
                        Label3.Text = "No se encontró el proveedor con el ID especificado";
                    }
                }
                catch (Exception ex)
                {
                    Label3.Text = "Ocurrió un error: " + ex.Message;
                }
            }

        }
    }

