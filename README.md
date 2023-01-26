# StarExplorer

An application that models the expedition process so that we can
keep track of the planets that were visited, and the status of each of these planets.

Each planet in the solar system is visited by a team of explorers composed of one
human captain and multiple robots that board a shuttle and navigate the solar system
for finding planets that can sustain life. When reaching a planet, the robots can
determine whether it is suitable for human life or not. The human captain can use the
application in order to communicate the status of the expedition to the other exploring
teams, so that they do not visit the same planet again.


#### Login Credentials
```
email: asd@def.com
pwd: defiance
```

## Prerequisites

node v14.20
npm v6.14.17
dotnet 7.0.102
dotnet-ef 7.0.2

## Start Crews API

http://localhost:3001
```bash
cd crews-api/
source .env
dotnet run
```

## Start Planets API

http://localhost:3002
```bash
cd planets-api/
source .env
dotnet run
```


## Start Gateway API

http://localhost:3000

```bash
cd gateway-api/
source .env
dotnet run
```

## Start Space Client

http://localhost:4200

```bash
cd space-client
npm ci
npm run start
```

## Test curls

```bash

curl -X POST localhost:3000/crews_gateway/login -d '{ "email": "example@email.com", "password": "examplepassword" }' -H 'Content-Type: application/json' -v

curl -X POST localhost:3000/crews_gateway/crew_members -d '{ "email": "examplepassword", "name": "Example Name", "password": "examplepassword" }' -H 'Content-Type: application/json' -v -H 'Authorization: Bearer {token}'

curl localhost:3000/crews_gateway/auth_check -H "Authorization: Bearer {token}" -v
```

## Descriptions

###  CrewsApi Description

The crews-api is responsible for handleing the CrewMembers which are the Users of the application and the Crews.

###  PlanetsApi Description

The crews-api is responsible for handleing all Planets & Expeditions operations. It tracks all the Expeditions associated with a Planet and it computes a final Status for the Planet from the last registered Expedition.

### GatewayApi Description

1. Acts as a Reverse Proxy Server to the other two services as to simplify the routing of API requests from the UI.
2. Handles all database migrations

### SpaceClient

The Angular frontend client of the system.


### Database

The database system chosen is SQLite for demonstration purposes.

### Project Structure

THe entire project is structured as a monorepo. The /common dir is meant to hold common assets, models, DTOs etc. that can be shared between microservices of the same language. Currently only the dotnet part of the project that has shareable models & DTOs. Compilation of these files is facilitated by symlinks from each service to /common (ex.: crews-api/common -> ../common).


### Backlog

- Specify Authentication Scheme on Planets API
- Further secure APIs
- Restrict Write operations to CrewMembers that have the Rank of Captain
- Pagination
- Handle JWT_TOKEN expiration