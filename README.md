# CustomerCarePortal

Before running the project

  (optional) Change the name of the database in the appsettings.json
  
  Run Command of Update-Database in PM(Package Manager) Shell/Console
  Go To 
    Areas/Identity/Pages/Roles/Details.cshtml.cs
    Areas/Identity/Pages/Roles/Index.cshtml.cs
   
  Comment out the following code in both of the pages
    [Authorize(Roles = "Administrator")]
  
  Run the project and register a new user you want to be Admin
  Now GoTo Localhost{port}:/Identity/Roles
  
  Add three roles with the names ( make sure spellings match)
    1. Administrator
    2. TeamManager
    3. Agent
    
  Click on the Administrator and click the '+' Button with the registered user and it will become Administrator

Now Uncomment the code 
   [Authorize(Roles = "Administrator")]
   
    In the pages 
      Areas/Identity/Pages/Roles/Details.cshtml.cs
      Areas/Identity/Pages/Roles/Index.cshtml.cs

Congradulations! You made it.


To Understand the working of the project

This Project is about Customer Care Portal

Customer will come and provide it's email and complain description in a form and a ticket will be generated against provided details with an tracking id

Tracking page is used to track the ticket, Once ticket is searched with valid tracking id, customer can see the comment box and also comment/ give remarks on progress

There are departments containing teams containing agents.
An agent is a registered user and can be created by Administrator only
A team contain Manager among the agents in the team, same goes for department manager.

Admin will assign a ticket to one of the teams going to ticket and clicking on view all tickets. Note: Admin can assign team only once this change could be done only once.
Admin can also comment on ticket.
TeamManager will assign the ticket to the agent in his/her team. Note: TeamManager can't work on ticket while he is already a TeamManager
TeamManager will aslo attach an workflow with the ticket. Also TeamManager has abililty to comment on ticket.

Workflow can be created by Administrator only and it contains states and transisitons and an initialState.
The states are like status of the ticket. The current status of a ticket is just a state from the attached workflow with it.

Consider Workflow as an graph with One starting Node(State) and directed Edge(Transition) to other Nodes(States).

This project is not good enough yet, It could have gone so much better.
