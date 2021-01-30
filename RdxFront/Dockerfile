FROM node:10-slim

USER root

RUN apt-get update || : && apt-get install python -y

RUN npm install -g @quasar/cli && \
    npm install -g @vue/cli && \
    npm install -g @vue/cli-init 

RUN mkdir /home/node/app

# VOLUME [ "/home/node/app" ]
WORKDIR /home/node/app

COPY package*.json ./
# error p
RUN npm install

COPY . .

EXPOSE 8080

CMD [ "quasar", "dev" ]