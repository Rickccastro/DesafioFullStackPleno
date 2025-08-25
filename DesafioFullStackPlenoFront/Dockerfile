# 1. Build
FROM node:20 AS build
WORKDIR /app

# Copia package.json e instala dependências
COPY package*.json ./
RUN npm install

# Copia o código e builda a aplicação
COPY . .
RUN npm run build --prod

# 2. Runtime (Nginx)
FROM nginx:alpine
# Substitua "desafio-fullstack-pleno-front" pelo nome da pasta gerada no dist
COPY --from=build /app/dist/desafio-fullstack-pleno-front /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
