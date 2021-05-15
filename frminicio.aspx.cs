using p1Acrud.clases.archivos;
using p1Acrud.clases.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace p1Acrud
{
    public partial class frminicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargarArchivoExterno()
        {
            string fuente = @"C:\Users\carlo\OneDrive\Documentos\Universidad\Tercer Semestre\Programación I\ArchivoCSV\crudDB.csv";
            ClsArchivos ar = new ClsArchivos();
            //obtener todo el archivo, linea por linea dentro de un arreglo
            string[] ArregloNotas = ar.LeerArchivo(fuente);
            string sentencia_sql = "";
            int Numerolinea = 0;

            ClsConexion cn = new ClsConexion();

            foreach (string linea in ArregloNotas)
            {
                //obtener datos
                String[] datos = linea.Split(';');
                if (Numerolinea > 0)
                {
                    sentencia_sql = sentencia_sql + $"insert into tb_alumnos values({datos[0]},'{datos[1]}',{datos[2]},{datos[3]},{datos[4]},{datos[5]},'{datos[6]}');\n ";
                }
                Numerolinea++;
            }

            cn.EjecutaSQLDirecto(sentencia_sql);
        }

        protected void ButtonSubirInformacion_Click(object sender, EventArgs e)
        {
            cargarArchivoExterno();

        }
    }
}