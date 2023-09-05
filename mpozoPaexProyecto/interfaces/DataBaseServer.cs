using System;
using System.Collections.Generic;
using System.Text;

// Libreias
using SQLite;

namespace mpozoPaexProyecto.interfaces
{
    public interface DataBaseServer
    {
        SQLiteAsyncConnection GetConnection();

    }
}
