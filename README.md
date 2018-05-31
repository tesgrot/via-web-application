# VIA Pet Store Web Service

* web service application: cat “e-shop”
* registration and login ability
* Administrator can upload cats to sell and see all orders information (login e-mail: admin@admin.com password: 123456789)
* Logged in user sees available cats and can make order
* Database contains 4 pre-made cats

### Installing

* no dependencies-installing needed

To create migrations and update database:
```
$ dotnet ef migrations add migrationName

$ dotnet ef database update
```

To start the server:
```
$ dotnet run
```

## API

The API is structured as follows:

GET request to get the list of all non-sold cats stored in API
```
/api/cat
```

GET request to get all information about specific cat (with cat id as a parameter)
```
/api/cat/id
```

POST request to add new cat object
```
/api/cat
```

PUT request to update cat (with cat id as a parameter and a field/fields to update)
```
/api/cat/id
```

DELETE request to remove the cat (with cat id as a parameter)
```
/api/cat/id
```


## Built With

* ASP.NET
* Razor Pages
* SQLite

## Author

* Marek Simko & Tereza Madova
