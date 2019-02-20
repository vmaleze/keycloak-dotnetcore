# Keycloak Demo with dotnetcore

## Intro
This project is a simple implementation of the standard Microsoft Jwt Authentication Scheme using 
[keycloak](https://www.keycloak.org/).

## Setup
1. Start keycloak => 
`docker run -e KEYCLOAK_USER=<USERNAME> -e KEYCLOAK_PASSWORD=<PASSWORD> -p 8080:8080 jboss/keycloak`

2. Configure audience in Keycloak
    * Add realm or configure existing
    * Add client my-app or use existing
    * Goto to the newly added "Client Scopes" menu
      * Add Client scope 'good-service'
      * Within the settings of the 'good-service' goto Mappers tab
      * Create Protocol Mapper 'my-app-audience'
          * Name: my-app-audience
          * Choose Mapper type: Audience
          * Included Client Audience: my-app
          * Add to access token: on
    * Configure client my-app in the "Clients" menu
      * Client Scopes tab in my-app settings
      * Add available client scopes "good-service" to assigned default client scopes
  
3. Create a user with the role "yes_we_can"

## Usage
* Run the project `cd KeycloakDemo && dotnet run`
* Via postman or any other REST client, you should be able to get the token and call the secured API.
Use the authorisation_code or password grant scheme.<br>
Ex with password scheme : 
```bash
curl \
  -d "client_id=my-app" \
  -d "username=<user>" \
  -d "password=<password>" \
  -d "grant_type=password" \
  "http://localhost:8080/auth/realms/master/protocol/openid-connect/token"

```
* You should then be able to call the APIs :
    * [Secured](http://localhost:5000/secured) => Should return the username of your authenticated user
    * [Role](http://localhost:5000/secured/role) => Yes you can :)
    * [Dumb](http://localhost:5000/secured/dumb) => Error HTTP 403
