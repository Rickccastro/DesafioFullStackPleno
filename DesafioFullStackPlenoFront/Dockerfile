# 1. Build
FROM node:20 AS build
WORKDIR /app

# Copia package.json e instala dependências
COPY package*.json ./
RUN npm install

# Copia o código e builda a aplicação
COPY . .
RUN npm run build -- --project DesafioFullStackPlenoFront --configuration development

# 2. Runtime (Nginx)
FROM nginx:alpine
# Copia build final do Angular para o Nginx
COPY --from=build /app/dist/desafio-full-stack-pleno-front /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
