# an asp.net core project to demonstrate the Clean Architecture building.

## Layer/project Description:

### src
* Domain
* Application.RequestModel(Dto): dto objects, reuse this project between server and client projects
* Application
* Persistence: database related
* Infrastructure
* WebApi
* BlazorUI: wasm client project

### test
todo:

### Naming Rules:

### DTO objects:
	end with: Request, Response
	for example: CreateUserRequest, GetUserDetailResponse

### Command and Query
	end with: Command, Query
	for example: CreateUserCommand, GetUserDetailQuery, GetUserListQuery
	CreateUserCommandHandler: handler
	CreateUserCommandValidator: validation
	CreaterUserMapper: Mapster Register

### Event Handler
	to do:
	

