FROM node:12

WORKDIR /.

COPY . .
RUN npm cache clean --force
RUN npm install

EXPOSE 3000

# CMD npm start
CMD [ "node", "index.js" ]

# docker build -t quidditch-client .
# docker run -p 3000:3000 --name quidditch-client quidditch-client
