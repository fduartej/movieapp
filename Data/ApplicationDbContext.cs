﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace movieappauth.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {}
    public DbSet<movieappauth.Models.Contacto> DataContacto {get; set; }
    public DbSet<movieappauth.Models.Producto> DataProducto {get; set; }
    public DbSet<movieappauth.Models.Proforma> DataItemCarrito {get; set; }
}

