using Newtonsoft.Json.Linq;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
});

var app = builder.Build();

// Configure the HTTP request pipeline.B
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

/*app.Use(async (context, next) =>
{
    var JwtToken = context.Session.GetString("JwtToken");
    if (!string.IsNullOrEmpty(JwtToken))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + JwtToken);

        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(JwtToken) as JwtSecurityToken;

        if (jsonToken != null)
        {
            // Ambil waktu kedaluwarsa dari token
            var expirationTime = jsonToken.ValidTo;

            // Set waktu kedaluwarsa dalam sesi
            context.Session.SetString("TokenExpirationTime", expirationTime.ToString("O"));
        }
    }
    await next();
});*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
