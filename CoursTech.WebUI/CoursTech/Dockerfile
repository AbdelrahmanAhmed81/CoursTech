### Stage 1: Build the Angular app ###
# Use Node.js 14.15.2 as the build environment
FROM node:22.12.0 AS build

# Set the working directory
WORKDIR /app

# Copy package files and install dependencies
COPY package.json package-lock.json ./
RUN npm install

# Copy the entire application source
COPY . .

# Build the Angular app
RUN npm run build --prod

### Stage 2: Serve the Angular app ###
# Use a lightweight web server
FROM nginx:alpine

# Copy the built Angular files to Nginx's web directory
COPY --from=build /app/dist/course-tech /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
