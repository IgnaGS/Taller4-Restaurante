﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Interfaces;
using Servicios.DB;
using Domain;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Servicios
{
    public class ServicioProveedor : IServicioProveedor
    {
        public IEnumerable<Proveedor> ObtenerProveedores()
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Proveedores
                    .ToList();
            }
        }

        public Proveedor ObtenerProveedor(int id)
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Proveedores
                    .Find(id);
            }
        }

        public void AddProveedor(string descripcion, string direccion, string mail, string telefono)
        {
            using (var db = new AppDbContext())
            {
                db.Proveedores
                    .AddOrUpdate(new Proveedor()
                    {
                        Descripcion = descripcion,
                        Direccion = direccion,
                        Mail = mail,
                        Telefono = telefono,
                        FechaAlta = DateTime.Now
                    });

                db.SaveChanges();
            }
        }

        public void UpdateProveedor(int id, string descripcion, string direccion, string mail, string telefono)     // , DateTime fechaAlta
        {
            using (var db = new AppDbContext())
            {
                var proveedor = db.Proveedores.Find(id);

                proveedor.Descripcion = descripcion;
                proveedor.Direccion = direccion;
                proveedor.Mail = mail;
                proveedor.Telefono = telefono;
                //proveedor.FechaAlta = fechaAlta;

                db.SaveChanges();
            }
        }
    }
}
