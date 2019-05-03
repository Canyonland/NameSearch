# NameSearch
The client side of this application is created with Angular 6, the server side is a ASP.NET CORE 2.2 web api application. At the back end is a .NET Standard library project and a Sqlite database that's pre-seeded with a small set of data. 

The Angular site is configured to output to wwwroot folder when building with ng cli, so that both Angular web page and the api can be served from the same port.

Once it's downloaded, open the solution in Visual Studio, (I used VS 2019, I think 2017 should work as well), open Package Manager Console, navigate to ClientApp under NameSearchWeb folder, run the following two ng cli commands:
      PM> npm install
      PM> ng build
      
Finally, hit Ctr + F5 to build and launch https://localhost:44310/index.html

The Swagger help document can be accessed at https://localhost:44310/help

Thanks for reading.
