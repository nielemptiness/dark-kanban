#!/bin/bash

set -e

# -------------------------------------------------------------------------------------------\
#Check docker network
if [[ "$(docker network ls 2>&1 | grep -w dark-kanban-network | awk '{ print $2 }')" != "dark-kanban-network" ]]; then
	docker network create dark-kanban-network
fi

# -------------------------------------------------------------------------------------------\
docker-compose up -d

docker ps -a