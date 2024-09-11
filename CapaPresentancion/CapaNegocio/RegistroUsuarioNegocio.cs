using CapaDatos;
using CapaDatos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class RegistroUsuarioNegocio
    {
        private ClaseContexto db;
        public RegistroUsuarioNegocio(ClaseContexto db)
        {
            this.db = db;
        }

        public UsuarioModelo RegistroModelo(UsuarioViewModel modelo)
        {
            var existe = db.Usuarios.Any(x => x.Correo == modelo.Correo || x.NombreCompleto == modelo.NombreCompleto && x.Contrasena == modelo.Contrasena);
            var existe2 = db.Administrador.Any(x => x.Correo == modelo.Correo);
            var existe3 = db.Doctor.Any(x => x.Correo == modelo.Correo);

            if (existe == true|| existe2 == true || existe3 == true)
            {
                return null;
                
            }
           
            var DatosEntrada = new UsuarioModelo
            {
                NombreCompleto = modelo.NombreCompleto,
                FechaNacimiento = modelo.FechaNacimiento,
                Dirrecion = modelo.Dirrecion,
                Telefono = modelo.Telefono,
                Correo = modelo.Correo,
                Contrasena = modelo.Contrasena,
                IdRol = modelo.IdRol,
            };

            db.Add(DatosEntrada);
            db.SaveChanges();
            return DatosEntrada;
        }
    }
}
