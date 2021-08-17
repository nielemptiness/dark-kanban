#!/bin/bash

set -e

# -------------------------------------------------------------------------------------------\
#Check docker network
if [[ "$(docker network ls 2>&1 | grep -w client-console-network | awk '{ print $2 }')" != "client-console-network" ]]; then
	docker network create client-console-network
fi

# -------------------------------------------------------------------------------------------\
docker-compose up -d

docker ps -a