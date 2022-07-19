var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();


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

return;

using (PizzaContext db = new PizzaContext())
{
    //1
    /*
    *Creo le varie pizze
    */
    Pizza bufalina = new Pizza();
    bufalina.Name = "Bufalina";
    bufalina.Description = "Pomodoro, Mozzarella di Bufala Campana DOP, Prosciutto Crudo di San Daniele";
    bufalina.Img = "/img/pizza-buffala-prosciutto.jpg";
    bufalina.Price = 10;

    Pizza triveneto = new Pizza();
    triveneto.Name = "Triveneto";
    triveneto.Description = "Pomodoro, Mozzarella, Pancetta, Radicchio di Treviso";
    triveneto.Img = "/img/pizza-con-pancetta.jpg";
    triveneto.Price = 9.50;

    Pizza diavola = new Pizza();
    diavola.Name = "Diavola";
    diavola.Description = "Pomodoro, Mozzarella, Salamino Piccante";
    diavola.Img = "/img/pizza-Diavola.jpg";
    diavola.Price = 8.50;

    Pizza estate = new Pizza();
    estate.Name = "estate";
    estate.Description = "Pomodoro, Mozzarella, Ruccola, Pomodorini, Grana";
    estate.Img = "/img/pizza-estate.jpg";
    estate.Price = 12;

    Pizza mortadellaPistacchioStracciatella = new Pizza();
    mortadellaPistacchioStracciatella.Name = "Mortadella, Pistacchio, Stracciatella";
    mortadellaPistacchioStracciatella.Description = "Pomodoro, Mozzarella, Mortadella, Pistacchio di Bronte, Stracciatella";
    mortadellaPistacchioStracciatella.Img = "/img/pizza-tonno-cipolla.jpg";
    mortadellaPistacchioStracciatella.Price = 14;

    Pizza tonnoCipolla = new Pizza();
    tonnoCipolla.Name = "Tonno e Cipolla";
    tonnoCipolla.Description = "Pomodoro, Mozzarella, Tonno, Cipolla";
    tonnoCipolla.Img = "/img/pizza-buffala-prosciutto.jpg";
    tonnoCipolla.Price = 7;
    /*
    *Aggiungo pizze al DB
    */
    db.Add(bufalina);
    db.Add(triveneto);
    db.Add(diavola);
    db.Add(estate);
    db.Add(mortadellaPistacchioStracciatella);
    db.Add(tonnoCipolla);

    /*
    *Salvo i prodotti
    */
    db.SaveChanges();


    /*
   *Stampo lista prodotti
   */
   
    List<Pizza> pizzas = db.Pizzas.OrderBy(pizza => pizza.Price).ToList<Pizza>();

    foreach (Pizza pizza in pizzas)
    {
        Console.WriteLine("");
        Console.WriteLine(pizza.Name);
        Console.WriteLine(pizza.Description);
        Console.WriteLine($"{pizza.Price} euro");
        Console.WriteLine("");
    }

}

