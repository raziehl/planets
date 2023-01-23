# StarExplorer

An application that models the expedition process so that we can
keep track of the planets that were visited, and the status of each of these planets.

Each planet in the solar system is visited by a team of explorers composed of one
human captain and multiple robots that board a shuttle and navigate the solar system
for finding planets that can sustain life. When reaching a planet, the robots can
determine whether it is suitable for human life or not. The human captain can use the
application in order to communicate the status of the expedition to the other exploring
teams, so that they do not visit the same planet again.

### Prerequisites

node v18.10
npm v8.19.2
dotnet 7.0.102
dotnet-ef 7.0.2

### Test curls

```
curl -X POST localhost:3001/login -d '{ "email": "example@email.com", "password": "examplepassword" }' -H 'Content-Type: application/json' -v

curl localhost:3001/auth_check -H "Authorization: Bearer {token}" -v
```