using Api.Faculdade.H1._2024.Dominio.Interfaces.IRepositorio;
using Api.Faculdade.H1._2024.Dominio.Interfaces.IServico;
using Api.Faculdade.H1._2024.Infra.Repositorio;
using Api.Faculdade.H1._2024.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Adicionar controladores
builder.Services.AddControllers();

// Registrar repositórios
builder.Services.AddScoped<IRepositorioAluno, RepositorioAluno>();
builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplina>();
builder.Services.AddScoped<IRepositorioNotaAluno, RepositorioNotaAluno>();

// Registrar serviços
builder.Services.AddScoped<IServicoAluno, ServicoAluno>();
builder.Services.AddScoped<IServicoDisciplina, ServicoDisciplina>();
builder.Services.AddScoped<IServicoNotaAluno, ServicoNotaAluno>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
