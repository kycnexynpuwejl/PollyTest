using RequestService.Policies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient("Test").AddPolicyHandler(
    request => request.Method == HttpMethod.Get ? new ClientPolicy().ImmediateHttpRetry : new ClientPolicy().LinearHttpRetry);

builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
