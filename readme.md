## Comandos usados

## cambiar la cadena de conexion en appsettings.json
    "PostgreSQLConnection":"Host=<host_render>.oregon-postgres.render.com;Database=<bd_render>;Username=<user_render>;Password=<Password Render>;Port=5432;SSL Mode=Require;Trust Server Certificate=true"

## cambiar en la clase Program.cs
'''var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));'''


## Crear el proyecto
dotnet new mvc --auth Individual -o <movieappauth>

## Instalar el dotnet ef
dotnet tool install --global dotnet-ef

## instalar postgresSQL
https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/8.0.2

## crear la migracion "Cambiar la ruta"
dotnet ef migrations add <CambiarAqui> --context movieappauth.Data.ApplicationDbContext -o "C:\Users\fduarte\OneDrive - Inteligo Group\Code\netcore\usmp\20241\movieappauth\Data\Migrations" 

## crear objetos en la base datos
dotnet ef database update

## Para modificar el login y registrar

### modificar el login registra

https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/8.0.3

https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/8.0.2

## use este comando
dotnet aspnet-codegenerator identity -dc appcomics.Data.ApplicationDbContext --files "Account.Register;Account.Login"

## o use este de aqui (no ambos)
dotnet aspnet-codegenerator identity -dc appcomics.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout;Account.ForgotPassword;Account.ResetPassword"


## crear la migracion "Contato"
dotnet ef migrations add ContactoMigracion --context movieappauth.Data.ApplicationDbContext -o "C:\Users\fduarte\OneDrive - Inteligo Group\Code\netcore\usmp\20241\movieappauth\Data\Migrations" 

dotnet ef database update

## crear la migracion "Producto"
dotnet ef migrations add ProductoMigracion --context movieappauth.Data.ApplicationDbContext -o "C:\Users\fduarte\OneDrive - Inteligo Group\Code\netcore\usmp\20241\movieappauth\Data\Migrations" 

dotnet ef database update

## crear la migracion "Proforma"
dotnet ef migrations add ProformaCarritoMigracion --context movieappauth.Data.ApplicationDbContext -o "C:\Users\fduarte\OneDrive - Inteligo Group\Code\netcore\usmp\20241\movieappauth\Data\Migrations" 

dotnet ef database update

## crear la migracion "Pago, Pedido, DetallePedido"
dotnet ef migrations add PagoPedidoMigracion --context movieappauth.Data.ApplicationDbContext -o "C:\Users\fduarte\OneDrive - Inteligo Group\Code\netcore\usmp\20241\movieappauth\Data\Migrations" 

dotnet ef database update

## auto generacion de la parte web de producto
dotnet aspnet-codegenerator controller -name ProductoController -m Producto -dc movieappauth.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries