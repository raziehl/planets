# StarExplorer

An application that models the expedition process so that we can
keep track of the planets that were visited, and the status of each of these planets.

Each planet in the solar system is visited by a team of explorers composed of one
human captain and multiple robots that board a shuttle and navigate the solar system
for finding planets that can sustain life. When reaching a planet, the robots can
determine whether it is suitable for human life or not. The human captain can use the
application in order to communicate the status of the expedition to the other exploring
teams, so that they do not visit the same planet again.

## Prerequisites

node v14.20
npm v6.14.17
dotnet 7.0.102
dotnet-ef 7.0.2

## Start Crews API

```bash
cd crews-api/
source .env
dotnet run
```

## Start Planets API

```bash
cd planets-api/
source .env
dotnet run
```


## Start Gateway API

```bash
cd space-client
npm ci
npm run start
```


## Start Space Client

```bash
cd space-client/
source .env
dotnet run
```

## Test curls

```bash
curl -X POST localhost:3001/login -d '{ "email": "example@email.com", "password": "examplepassword" }' -H 'Content-Type: application/json' -v

curl localhost:3001/auth_check -H "Authorization: Bearer {token}" -v
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
