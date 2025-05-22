const http = require('http');
const { handleStatus } = require('./controllers/statusController');

const server = http.createServer((req, res) => {
  if (req.method === 'POST' && req.url === '/api/status') {
    return handleStatus(req, res);
  }
  res.statusCode = 404;
  res.end();
});

const PORT = process.env.PORT || 3000;
server.listen(PORT, () => console.log(`Server running on port ${PORT}`));
