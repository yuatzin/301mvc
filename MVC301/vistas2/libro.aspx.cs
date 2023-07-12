using MVC301.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC301.vistas2
{
    public partial class libro : System.Web.UI.Page
    {
        Database2Entities db = new Database2Entities();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDownList1();
                CargarDropDownList2();
            }
        }

        protected void CargarDropDownList1()
        {
            DropDownList1.DataSource = db.autor.ToList();
            DropDownList1.DataTextField = "nombreA";
            DropDownList1.DataValueField = "claveA";
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("Seleccione un autor", "-1"));
        }

        protected void CargarDropDownList2()
        {
            DropDownList2.DataSource = db.editorial.ToList();
            DropDownList2.DataTextField = "nombree";
            DropDownList2.DataValueField = "claveE";
            DropDownList2.DataBind();

            DropDownList2.Items.Insert(0, new ListItem("Seleccione un editorial", "-1"));
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                int claveL = int.Parse(TextBox1.Text);
                MVC301.Models.libros existingLibro = db.libros.SingleOrDefault(l => l.claveL == claveL);

                if (existingLibro != null)
                {
                    Label6.Text = "Ya existe un libro con la clave especificada";
                }
                else
                {
                    MVC301.Models.libros newLibro = new MVC301.Models.libros();
                    newLibro.claveL = int.Parse(TextBox1.Text);
                    newLibro.titulo = TextBox2.Text;
                    newLibro.claveA = int.Parse(DropDownList1.SelectedValue);
                    newLibro.claveE = int.Parse(DropDownList2.SelectedValue);

                    db.libros.Add(newLibro);
                    db.SaveChanges();

                    Label6.Text = "Se agregó un nuevo libro correctamente";
                }
            }
            catch (Exception ex)
            {
                Label6.Text = "Ocurrió un error: " + ex.Message;
            }





        }

        protected void Button5_Click(object sender, EventArgs e)
        {


            try
            {
                int claveL = int.Parse(TextBox1.Text);
                MVC301.Models.libros lib1 = db.libros.Single(l => l.claveL == claveL);

                if (lib1 != null)
                {
                    TextBox2.Text = lib1.titulo.ToString();

                    DropDownList1.SelectedValue = lib1.claveA.ToString();
                    DropDownList2.SelectedValue = lib1.claveE.ToString();

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
            DropDownList2.DataSource = db.editorial.ToList();
            DropDownList2.DataTextField = "nombree";
            DropDownList2.DataValueField = "claveE";
            DropDownList2.DataBind();
            try
            {
                int claveL = int.Parse(TextBox1.Text);
                MVC301.Models.libros lib1 = db.libros.Find(claveL);

                if (lib1 != null)
                {
                    db.libros.Remove(lib1);
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


            try
            {
                int claveL = int.Parse(TextBox1.Text);
                MVC301.Models.libros lib1 = db.libros.Single(l => l.claveL == claveL);

                lib1.titulo = TextBox2.Text;
                lib1.claveA = int.Parse(DropDownList1.SelectedValue);
                lib1.claveE = int.Parse(DropDownList2.SelectedValue);

                db.Entry(lib1).State = EntityState.Modified;
                db.SaveChanges();

                Label6.Text = "Se ha modificado con éxito";
            }
            catch (Exception ex)
            {
                Label6.Text = "Ocurrió un error: " + ex.Message;
            }

        }

      
    }
}