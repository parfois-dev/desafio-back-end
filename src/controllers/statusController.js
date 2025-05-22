const StatusRequest = require('../dtos/statusRequest');
const statusService = require('../services/statusService');

function handleStatus(req, res) {
  let body = '';
  req.on('data', chunk => body += chunk);
  req.on('end', () => {
    try {
      const data = JSON.parse(body);
      const request = new StatusRequest(data);
      const result = statusService.process(request);
      res.statusCode = 200;
      res.setHeader('Content-Type', 'application/json');
      res.end(JSON.stringify(result));
    } catch (err) {
      res.statusCode = 400;
      res.end(JSON.stringify({ error: 'Invalid request' }));
    }
  });
}

module.exports = { handleStatus };
