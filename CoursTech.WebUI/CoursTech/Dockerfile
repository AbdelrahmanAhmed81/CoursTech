# Build Angular app
FROM node:20-alpine AS build
WORKDIR /app

COPY package.json package-lock.json* ./
RUN npm ci

COPY . .

ARG BUILD_ENV=production
RUN npm run build -- --configuration=$BUILD_ENV

# Serve static files
FROM nginx:1.27-alpine AS final
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist/course-tech /usr/share/nginx/html
EXPOSE 80
