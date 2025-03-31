
var express = require('express');
var path = require('path');

var app = express();

async function connectDB() {
  var databaseURL = "mongodb://localhost:27017/OMok_9";

  try {
    const database = await MongoClient.connect(databaseURL, {
      useNewUrlParser: true,
      useUnifiedTopology: true
    });
    console.log("DB 연결 완료: " + databaseURL);

    // 연결 종료 처리
    process.on("SIGINT", async () => {
      await database.close();
      console.log("DB 연결 종료");
      process.exit(0);
    });
  } catch (err) {
    console.error("DB 연결 실패: " + err);
    process.exit(1);
  }
}

connectDB().catch(err => {
  console.error("초기 DB 연결 실패: " + err);
  process.exit(1);
});



// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});


module.exports = app;

app.listen(3000)