# SweetManager API
## Summary
Sweet Manager API Application, made with Microsoft C#, ASP.NET Core, Entity Framework Core and MySQL persistence. It also illustrates open-api documentation configuration and integration with Swagger UI.

## Features
- RESTful API
- OpenAPI Documentation
- Swagger UI
- Entity Framework Core
- Microsoft ASP.NET Framework
- Audit Creation and Update Date
- Custom Route Naming Conventions
- Custom Object-Relational Mapping Naming Conventions
- MySQL Database
- Domain-Driven Design

## Bounded Context
This proyect of SweetManager is divided in the following bounded contexts:
- Monitoring 
- Supplies
- Interaction
- Payment
- Identity Access Management (IAM)
- Dashboard and Analytics
- Messages

### Monitoring Context
The Monitoring Context is responsible for managing the rooms of the hotel. It includes the following features:
- Create a new Room.
- Update a Room.
- List all the rooms in real time.

### Supplies Context
The Supplies Context is responsible for managing the supplies of the hotel. It includes the following features:
- Create a new Supply
- Update the information of the Supply.
- List all the supplies in real time.

### Communication Context
The Communication Context is responsible for managing the notifications of the users. It includes the following features:
- List all the notifications in real time.

### Payment Context
The Payment Context is responsable for managing the subscriptions and payments of the users. It includes the following features:
- List all the subscriptions to the service.
- Validate information when the user subscribes.

### Identity and Access Management Context
The Identity and Access Management is responsable for managing the access of the users to the application. It includes the following features:
- Verify and Validate the information of the user.
- Create a user to the application.

### Dashboard and Analytics Context
The Dashboard and Analytics Context is responsable for managing the information in real time about the income and expenses. It includes the following features:
- List the income for every month at year.
- List the expenses for every month at year.

### Messages Context
The Messages Context is responsable for managing the messages between the users in the application. It includes the following features:
- Send message to the respective user in real time using socket.
