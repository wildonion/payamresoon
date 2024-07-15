# payam consumer 

## setup:
```bash 
sudo docker login docker.sprun.ir
sudo chmod +x redeploy.sh && ./redeploy.sh
```

> go to server and run

```bash
sudo docker compose -f "docker-compose.yml" pull
sudo docker compose -f "docker-compose.yml" up -d
```

> ensure that you've already setup the `DOCKER_USERNAME`, `DOCKER_PASSWORD`, `SERVER_HOST`, `SERVER_PASSWORD`, `SERVER_USER` secret vars.