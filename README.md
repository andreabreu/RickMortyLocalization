# Rick Localization
##### The system should maintain Rick and Morty's records in all dimensions, giving access to one or more dimensions.


![ricklocaliation(3)](https://user-images.githubusercontent.com/12116884/115040065-6d92db00-9ea7-11eb-9fd8-c900999c5efb.gif)

![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)

Project developed with the features: 
- :white_check_mark: .Net Core 3.1;
- :white_check_mark: Entity Framework Core;
- :white_check_mark: Code First;
- :white_check_mark: Auto Mapper;
- :construction: UT (In construction)
- :x: Angular material;
- :white_check_mark: Angular 10;




## :large_blue_circle: Installation
#### Angular Application

RickLocalization requires [Node.js](https://nodejs.org/) 10+ to run.

Install the dependencies and devDependencies:
```prompt
cd RickLocalizationApp
npm i
```

#### .Net Core WebAPI Application

```sh
cd RickLocalizationAPI
dotnet restore
```

Edit key `MyContext`  stored in `RickLocalizationAPI\RickLocalizationAPI\appsettings.json` setting the MS SQL connection string. 

```json
{
  "ConnectionStrings": {
    "MyContext": "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=TestDB;"
  },
}
```



## :large_blue_circle: Running
##### Angular Application

```sh
cd RickLocalizationApp
ng serve
```

##### .Net Core WebAPI Application
```sh
cd RickLocalizationAPI/RickLocalizationAPI
dotnet run
```


Verify the deployment by navigating to your server address in
your preferred browser.

```sh
127.0.0.1:4200
```


## Contact

- (c) 2021 by André Abreu - <andre.abreu@live.com>
