 
 #Creating Entity Models from Existing Database
  create the Entity Framework models based on our existing database that we have just created earlier.
  
  Go to Tools –> NuGet Package Manager –> Package Manager Console
   And then run the following command to create a model from the existing database:

 Scaffold-DbContext "MyConnectioString" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Data/Model -f -Context "AtmManagmentContext"

































