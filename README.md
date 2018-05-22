##SportAgency - Simple ASP.NET MVC Project

This is a simple web application for reading few text files provided through web page and inserting into relevant table and list a required resultset into the webpage.

#PREREQUISITIES
- Visual Studio with MVC support
- Microsoft SQL Server

#CODE SETUP
- Clone/Download the project from github url https://github.com/AshwiniSaran/SportAgency
- Open the solution file(SportAgency.sln) through visual studio.
- Change the path of the sports.txt(its included in the repository under textfilestoload folder) under <appsetting> at the below line in web.config file
   <add key="Path" value="..\textfilestoload\Sports.txt"/>
 
- And also before execution create the database scheme from SportAgency_DB.sql. Open the file in Microsoft SQL Server(through SSMS or command prompt) and execute the SportAgency_DB.sql file.
- Then change the connectionstring of the your database server at the below line in web.config file
  <connectionStrings>
    <add name ="con" connectionString="Data Source=YourDataSource;Initial Catalog=SPORTAGENCY_DB;Integrated Security=True;Pooling=False"/>
  </connectionStrings>

#EXECUTION
- Then can execute the project by pressing F5 or Debug->Start Debugging
- The webpage will be opened in the web browser with http://localhost:portnumber
- There LoadSport button to be clicked in order to load the sports.txt file data to the database
- And after that give the path for Athletes.txt and Agents.txt(both file available under textfilestoload folder) file path in the textbox and click Load Athletes and Agents button.
- Now click the show button to see the resultset brought up upon from the tables created.



This is a simple asp.net mvc project which being developed in accordance for personal develpment experience.
