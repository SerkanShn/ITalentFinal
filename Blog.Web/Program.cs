using Blog.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<IPostService, PostService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(options =>
{
    options.BaseAddress = new Uri(builder.Configuration["WebApi:BaseUrl"]);
});

builder.Services.AddHttpClient<IPostService, PostService>(options =>
{
    options.BaseAddress = new Uri(builder.Configuration["WebApi:BaseUrl"]);
});

builder.Services.AddHttpClient<IUserService, UserService>(options =>
{
    options.BaseAddress = new Uri(builder.Configuration["WebApi:BaseUrl"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
