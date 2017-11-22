# Weather-HIstory-API
Simple web API written to learn basics.

Application contains two components. One of them simulates client website the other web API.
Application gets current weather data for Gliwice from https://openweathermap.org/api Web API and posts it to API created in the project, which saves the data to database. Client website can then get all of previously saved weather data.
<br/>

As a default application uses in memory database. To use real database adjust connection string in appsetting.json and make following changes to Startup.cs file:<br/>
Uncomment line below '// Real database' and comment one below '// In memory database'
```C#
public void ConfigureServices(IServiceCollection services)
        {
            // Real database
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:WeatherHistoryAPI"]));

            // In memory database
            //services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("WeatherAPIDB"));

            services.AddMvc();
        }
```
