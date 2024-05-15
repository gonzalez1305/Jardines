using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jardines.modelo
{
    public class JardinDao
    {

        ORMDataContext BD = new ORMDataContext("Data Source=WINDOW11-CAROLG\\SQLEXPRESS;Initial Catalog=RegistroICBF;Integrated Security=True;");
        public void registrar(Jardin jardin)
        {

            BD.Jardin.InsertOnSubmit(jardin);
            BD.SubmitChanges(); //Guardar los cambios

        }

        public Object consultarTodos()
        {
            return from J in BD.Jardin
                   select J;
        }

        public void eliminar(int Identificador)
        {
            Jardin jardinEliminar= consultarJardinId(Identificador );

            BD.Jardin.DeleteOnSubmit(jardinEliminar);
            BD.SubmitChanges();
        }
        public void editar(Jardin jardin)
        {
            Jardin jardinEditar = consultarJardinId(jardin.Identificador);
            jardinEditar.Nombre = jardin.Nombre;
            jardinEditar.Direccion = jardin.Direccion;
            jardinEditar.Estado = jardin.Estado;
            BD.SubmitChanges();
        }

        public Jardin consultarJardinId(int identificador)
        {
            return (from J in BD.Jardin
                    where J.Identificador == identificador
                    select J).FirstOrDefault();
        }
        public bool validarNombre(string Nombre)
        {
            Jardin NombreJardin = (from J in BD.Jardin
                          where J.Nombre == Nombre
                          select J).FirstOrDefault();
            if (NombreJardin != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
}

}