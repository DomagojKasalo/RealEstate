const express = require('express');
const app = express();
const path = require('path');

app.use('/images', express.static('C:/Users/Domagoj/Desktop/posao/Domagoj Kasalo/API/seminar/wwwroot/images'));

app.listen(3000, () => {
  console.log('Server is running on port 3000.');
});
