const WebSocket = require('ws');
const server = new WebSocket.Server({ port: 8888 });

console.log(`server start at port: 8888`);

server.on('connection', (socket) => {
    console.log('A new client connected.');
  
    socket.on('message', (message) => {
    
      
      mess =  JSON.parse(message);
      console.log(`Received type: ${mess.type} `);
      console.log(`Data: ${mess.data}`);

      if(mess.type == 'connect')
      {
        let repply = {
          type: 'connect',
          data: 'connect success!'
        }
  
        rep =  JSON.stringify(repply);
        socket.send(rep);
      } 
      else if( mess.type == 'play')
      {
        let repply = {
          type: 'play',
          data: 'Start Play Game!'
        }
  
        rep =  JSON.stringify(repply);
        socket.send(rep);

      }
      

    });
  
    socket.on('close', () => {
      console.log('Client disconnected.');
    });
  });
  