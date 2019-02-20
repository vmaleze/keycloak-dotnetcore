#!/usr/bin/env bash

docker run -d --name=keycloak \
    -e KEYCLOAK_USER=admin \
    -e KEYCLOAK_PASSWORD=admin \
    -e KEYCLOAK_IMPORT=/import/realm-export.json \
    -v $(pwd)/realm-export.json:/import/realm-export.json \
    -p 8080:8080 \
    jboss/keycloak
    
sleep 5
docker exec keycloak keycloak/bin/add-user-keycloak.sh -r keycloak-demo -u user -p test1234 --roles yes_we_can
docker restart keycloak