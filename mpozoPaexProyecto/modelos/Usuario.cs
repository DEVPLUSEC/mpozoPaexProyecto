using System;
using System.Collections.Generic;
using System.Text;

// Libreias
using SQLite;

namespace mpozoPaexProyecto.modelos
{
    public class Usuario
    {
        // id de usuario
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        // Nombres de usuario
        [MaxLength(50)]
        public string Nombres { get; set; }
        // Apellidos de usuario
        [MaxLength(50)]
        public string Apellidos { get; set; }
        // Edad de usuario
        [MaxLength(50)]
        public string Edad { get; set; }
        // Correo de usuario
        [MaxLength(50)]
        public string Correo { get; set; }
        // contrasena
        [MaxLength(50)]
        public string Contrasena { get; set; }

    }
}
