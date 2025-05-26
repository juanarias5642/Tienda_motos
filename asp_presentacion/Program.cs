using asp_presentacion;

var builder = WebApplication.CreateBuilder(args);

// 1) Registra todos los servicios
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// 2) Configura el pipeline HTTP
startup.Configure(app, app.Environment);

app.Run();