using Jardines.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jardines
{
    public partial class Jardinweb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
           
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            JardinDao jardinDao = new JardinDao();
            Jardin jardin = new Jardin();
           
            jardin.Nombre = TextNombre.Text;
            jardin.Direccion = TextDireccion.Text;
            jardin.Estado = ddlestado.Text;
            if (jardinDao.validarNombre(jardin.Nombre))
            {
                jardinDao.registrar(jardin);
                CargarDatos(); 

                PanelRegistro.Visible = false;
                PanelConsulta.Visible = true;
            }
            else
            {
                lblMensaje.Text = "El nombre del jardin ya existe";
            }
        }

        public void CargarDatos()
        {
            JardinDao jardinDao = new JardinDao();
            gdvjardines.DataSource = jardinDao.consultarTodos();
            gdvjardines.DataBind();
        }
        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            PanelRegistro.Visible = true;
            PanelConsulta.Visible = false;
            btnRegistrar.Visible = true;
            btnEditar.Visible = false;
            TextIdJardin.Visible = false;
            TextNombre.Text = String.Empty;
            TextDireccion.Text = String.Empty;
            lblMensaje.Text = "";
        }

        protected void gdvjardines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow fila =(GridViewRow) ((Control)e.CommandSource).NamingContainer;
            int indice = fila.RowIndex;

            if(e.CommandName=="Eliminar")
            {
                JardinDao jardindao = new JardinDao();
                jardindao.eliminar(int.Parse(gdvjardines.Rows[indice].Cells[0].Text));
                CargarDatos();
            }
        else if (e.CommandName== "Editar")
            {
                PanelRegistro.Visible=true;
                PanelConsulta.Visible=false; 
                btnRegistrar.Visible=false;
                btnEditar.Visible=true;
                lblMensaje.Text = "";

                TextIdJardin.Text = gdvjardines.Rows[indice].Cells[0].Text;

                TextNombre.Text = gdvjardines.Rows[indice].Cells[1].Text;

                TextDireccion.Text = gdvjardines.Rows[indice].Cells[2].Text;

                ddlestado.Text = gdvjardines.Rows[indice].Cells[3].Text;
            }
        }

        protected void btnEditarClick(object sender, EventArgs e)
        {
            JardinDao jardinDao = new JardinDao();
            Jardin jardin = new Jardin();
            jardin.Identificador = int.Parse(TextIdJardin.Text);
            jardin.Nombre = TextNombre.Text;
            jardin.Direccion = TextDireccion.Text;
            jardin.Estado = ddlestado.Text;

            jardinDao.editar(jardin);
            CargarDatos();

            PanelRegistro.Visible = false;
            PanelConsulta.Visible = true;
        }
    }
}