using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArchivoBinarioAlumnos
{
    class ClsAlumnosR
    {
        protected int numer_alumno;
        protected string nombre_alumno;
        protected string appelido_paterno;
        protected string apellido_materno;
        protected string numero_telefono;
        protected string correo_electronico;
        protected char genero;
        protected string carrera;

        public int Numero
        {
            get { return numer_alumno; }
        }
        public string Nombre
        {
            get { return nombre_alumno; }
        }
        public string ApellidoPaterno
        {
            get { return appelido_paterno; }
        }
        public string ApellidoMaterno
        {
            get { return apellido_materno; }
        }
        public string NumeroTel
        {
            get { return numero_telefono; }
        }
        public string Correo
        {
            get { return correo_electronico; }
        }
        public char Genero
        {
            get { return genero; }
        }
        public string Carrera
        {
            get { return carrera; }
        }
        public ClsAlumnosR(int numer_alumno = 0, string nombre_alumno = " ", string appelido_paterno = " ", string apellido_materno = " ", string numero_telefono = " ", string correo_electronico = " ", char genero = ' ', string carrera = " ")
        {
            this.numer_alumno = numer_alumno;
            this.nombre_alumno = nombre_alumno;
            this.appelido_paterno = appelido_paterno;
            this.apellido_materno = apellido_materno;
            this.numero_telefono = numero_telefono;
            this.correo_electronico = correo_electronico;
            this.genero = genero;
            this.carrera = carrera;
        }
        //Registro de los datos, para poder mostrar los datos antes debemos registrar los datos
        public void RegistratDatos()
        {
            string path = "Registro.bak";
            FileStream objArchivos;
            if (File.Exists(path))
            {
                objArchivos = new FileStream(path, FileMode.Append, FileAccess.Write);
            }
            else
            {
                objArchivos = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            }
            BinaryWriter objEscritura = new BinaryWriter(objArchivos);
            objEscritura.Write(numer_alumno);
            objEscritura.Write(nombre_alumno);
            objEscritura.Write(appelido_paterno);
            objEscritura.Write(apellido_materno);
            objEscritura.Write(numero_telefono);
            objEscritura.Write(correo_electronico);
            objEscritura.Write(genero);
            objEscritura.Write(carrera);
            objArchivos.Close();
            objEscritura.Close();
        }
        // leer alumnos
        public void leerElregistro()
        {
            string path = "Registro.bak";
            FileStream objArchivos = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader objLectura = new BinaryReader(objArchivos);
            numer_alumno = objLectura.ReadInt32();
            nombre_alumno = objLectura.ReadString();
            appelido_paterno = objLectura.ReadString();
            apellido_materno = objLectura.ReadString();
            numero_telefono = objLectura.ReadString();
            correo_electronico = objLectura.ReadString();
            genero = objLectura.ReadChar();
            carrera = objLectura.ReadString();
            objLectura.Close();
            objArchivos.Close();
        }
        //datos del alumnos 
        public List<string> LeerDatosDeAlumnos()
        {
            List<string> lista = new List<string>();
            string path = "Registro.bak";
            FileStream objarchivo = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader objlectura = new BinaryReader(objarchivo);
            while (objarchivo.Position < objarchivo.Length)
            {
                numer_alumno = objlectura.ReadInt32();
                nombre_alumno = objlectura.ReadString();
                appelido_paterno = objlectura.ReadString();
                apellido_materno = objlectura.ReadString();
                numero_telefono = objlectura.ReadString();
                correo_electronico = objlectura.ReadString();
                genero = objlectura.ReadChar();
                carrera = objlectura.ReadString();

            }
            lista.Add(ToString());
            objlectura.Close();
            objarchivo.Close();
            return lista;
        }
        public DataTable LeerDatosAlumnosData()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("#Alumno", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido Paterno", typeof(string));
            tabla.Columns.Add("Apellido Materno", typeof(string));
            tabla.Columns.Add("numer Tel", typeof(string));
            tabla.Columns.Add("Correo Electronico", typeof(string));
            tabla.Columns.Add("Genero", typeof(char));
            tabla.Columns.Add("Carrera", typeof(string));
            string path = "Registro.bak";
            FileStream objArchivos = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader objlectura = new BinaryReader(objArchivos);
            while (objArchivos.Position < objArchivos.Length)
            {
                numer_alumno = objlectura.ReadInt32();
                nombre_alumno = objlectura.ReadString();
                appelido_paterno = objlectura.ReadString();
                apellido_materno = objlectura.ReadString();
                numero_telefono = objlectura.ReadString();
                correo_electronico = objlectura.ReadString();
                genero = objlectura.ReadChar();
                carrera = objlectura.ReadString();
                tabla.Rows.Add(numer_alumno, nombre_alumno, appelido_paterno, apellido_materno, numero_telefono, correo_electronico, genero, carrera);
            }
            objArchivos.Close();
            objlectura.Close();
            return tabla;
        }
        public DataTable LeerDatosCarreras(string encontrado)
        {

            DataTable tabla = new DataTable();
            tabla.Columns.Add("#Alumno", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido Paterno", typeof(string));
            tabla.Columns.Add("Apellido Materno", typeof(string));
            tabla.Columns.Add("numer Tel", typeof(string));
            tabla.Columns.Add("Correo Electronico", typeof(string));
            tabla.Columns.Add("Genero", typeof(char));
            tabla.Columns.Add("Carrera", typeof(string));
            string path = "Registro.bak";
            FileStream objArchivos = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader objlectura = new BinaryReader(objArchivos);

            while (objArchivos.Position < objArchivos.Length)
            {

                numer_alumno = objlectura.ReadInt32();
                nombre_alumno = objlectura.ReadString();
                appelido_paterno = objlectura.ReadString();
                apellido_materno = objlectura.ReadString();
                numero_telefono = objlectura.ReadString();
                correo_electronico = objlectura.ReadString();
                genero = objlectura.ReadChar();
                carrera = objlectura.ReadString();
                tabla.Rows.Add(numer_alumno, nombre_alumno, appelido_paterno, apellido_materno, numero_telefono, correo_electronico, genero, carrera);
                StringBuilder filtro = new StringBuilder();
                for (int i = 0; i < tabla.Columns.Count; i++)
                {

                    if (carrera == encontrado)
                    {
                        filtro.Append($"{tabla.Rows[i]} LIKE '{carrera}%'");
                        tabla.Rows.Clear();
                        tabla.Rows.Add(numer_alumno, nombre_alumno, appelido_paterno, apellido_materno, numero_telefono, correo_electronico, genero, carrera);
                        break;
                    }
                    else
                    {
                        filtro.Append(" OR ");
                        filtro.Append($"{tabla.Rows[i]} LIKE '{carrera}%'");
                        break;
                    }
                }
            }
            objArchivos.Close();
            objlectura.Close();
            return tabla;
        }
        public bool BuscarAlumno(int numero)
        {
            bool encontrado = false;
            string path = "Registro.bak";
            FileStream objArchivo = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader objlectura = new BinaryReader(objArchivo);
            while (objArchivo.Position < objArchivo.Length)
            {
                numer_alumno = objlectura.ReadInt32();
                nombre_alumno = objlectura.ReadString();
                appelido_paterno = objlectura.ReadString();
                apellido_materno = objlectura.ReadString();
                numero_telefono = objlectura.ReadString();
                correo_electronico = objlectura.ReadString();
                genero = objlectura.ReadChar();
                carrera = objlectura.ReadString();
                if (numer_alumno == numero)
                {
                    encontrado = true;
                    break;
                }

            }
            objArchivo.Close();
            objlectura.Close();
            return encontrado;
        }
        public bool BuscarAlumnoApellido(string apellido)
        {
            bool encontrado = false;
            string path = "Registro.bak";
            FileStream objArchivo = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader objlectura = new BinaryReader(objArchivo);
            while (objArchivo.Position < objArchivo.Length)
            {
                numer_alumno = objlectura.ReadInt32();
                nombre_alumno = objlectura.ReadString();
                appelido_paterno = objlectura.ReadString();
                apellido_materno = objlectura.ReadString();
                numero_telefono = objlectura.ReadString();
                correo_electronico = objlectura.ReadString();
                genero = objlectura.ReadChar();
                carrera = objlectura.ReadString();
                if (appelido_paterno == apellido)
                {
                    encontrado = true;
                    break;
                }

            }
            objArchivo.Close();
            objlectura.Close();
            return encontrado;
        }
        public bool BuscarAlumnoCarrera(string carreras)
        {
            bool encontrado = false;
            string path = "Registro.bak";
            FileStream objArchivo = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader objlectura = new BinaryReader(objArchivo);
            while (objArchivo.Position < objArchivo.Length)
            {
                numer_alumno = objlectura.ReadInt32();
                nombre_alumno = objlectura.ReadString();
                appelido_paterno = objlectura.ReadString();
                apellido_materno = objlectura.ReadString();
                numero_telefono = objlectura.ReadString();
                correo_electronico = objlectura.ReadString();
                genero = objlectura.ReadChar();
                carrera = objlectura.ReadString();
                if (carrera == carreras)
                {
                    encontrado = true;
                    break;
                }

            }
            objArchivo.Close();
            objlectura.Close();
            return encontrado;
        }
        public override string ToString()
        {
            return string.Format($"Numero: {numer_alumno}\n Nombre: {nombre_alumno}\n Apellido Paterno: {appelido_paterno}\n Apellido Materno: {apellido_materno}\n Numero de telefono: {numero_telefono}\n Correo Electronico {correo_electronico}\n Genero: {genero}\n Carrera: {carrera}");
        }
    }
}
