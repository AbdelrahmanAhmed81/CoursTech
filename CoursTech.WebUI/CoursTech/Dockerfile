### Stage 1: Build the Angular app ###
FROM node:22.12.0 AS build
WORKDIR /app
COPY package.json ./
RUN npm install
COPY . .
RUN npm run build --prod

FROM nginx:alpine
COPY --from=build /app/dist/course-tech /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
