const [major, minor] = process.version.slice(1).split(".").map(Number);
if (major < 18 || (major === 18 && minor < 19)) {
  console.error(
    `Node.js ${process.version} is too old. Angular 19 requires Node.js >= 18.19.`
  );
  console.error("Install Node.js 20 LTS from https://nodejs.org or run: nvm use");
  process.exit(1);
}
