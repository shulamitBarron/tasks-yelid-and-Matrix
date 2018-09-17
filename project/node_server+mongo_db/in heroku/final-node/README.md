# Full stack online0book-store
* Node (express) backend
* Mongo db (hosted by atlas mongoDB)
* Angular frontend

# See live demo:
https://mongo-anna-karp.herokuapp.com/bookStore

## Curl text for node server
### Post request (register)
##### request
```bash
curl -v -X POST -H "Content-type: application/json" -d "{\"firstName\":\"test\", \"lastName\":\"test2\", \"userName\":\"test3\", \"password\":\"a4e624d686e03ed2767c0abd85c14426b0b1157d2ce81d27bb4fe4f6f01d688a\", \"country\":\"Israel\" }"  http://localhost:8000/api/client
```
##### output
```bash
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 8000 (#0)
> POST /api/client HTTP/1.1
> Host: localhost:8000
> User-Agent: curl/7.55.1
> Accept: */*
> Content-type: application/json
> Content-Length: 160
>
* upload completely sent off: 160 out of 160 bytes
< HTTP/1.1 201 Created
< X-Powered-By: Express
< xx-auth: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjViOWUyMWJhZTE5MTc1MWM1YzBhNjg4YiIsImlhdCI6MTUzNzA4OTk3OH0.kR6KYUT0_YFr716BxEdps9ylM-bhNy8Ra2722RRp0rE
< Content-Type: application/json; charset=utf-8
< Content-Length: 212
< ETag: W/"d4-/fVcS9yucw2JZf6Bu76C4Nv7mjU"
< Date: Sun, 16 Sep 2018 09:26:18 GMT
< Connection: keep-alive
<
{"bookOrders":[],"_id":"5b9e21bae191751c5c0a688b","firstName":"test","lastName":"test2","userName":"test3","password":"a4e624d686e03ed2767c0abd85c14426b0b1157d2ce81d27bb4fe4f6f01d688a","country":"Israel","__v":0}
```


### Get request (login)
##### request
```bash
curl -v -X GET -H "xx-auth: a4e624d686e03ed2767c0abd85c14426b0b1157d2ce81d27bb4fe4f6f01d688atest3"  http://localhost:8000/api/client
```

##### output
```bash
*   Trying ::1...
* TCP_NODELAY set
* Connected to localhost (::1) port 8000 (#0)
> GET /api/client HTTP/1.1
> Host: localhost:8000
> User-Agent: curl/7.55.1
> Accept: */*
> xx-auth: a4e624d686e03ed2767c0abd85c14426b0b1157d2ce81d27bb4fe4f6f01d688atest3
>
< HTTP/1.1 200 OK
< X-Powered-By: Express
< xx-auth: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjViOWUyMWJhZTE5MTc1MWM1YzBhNjg4YiIsImlhdCI6MTUzNzA5MDQ0N30.xFaaQHMsN_W8aww3f9d6_zfXKJEkWi0r6hB9DIObna8
< Content-Type: text/html; charset=utf-8
< Content-Length: 26
< ETag: W/"1a-lntZxpO/NYZB2ktprU25dMf3tHs"
< Date: Sun, 16 Sep 2018 09:34:07 GMT
< Connection: keep-alive
<
{"status":"login success"}* Connection 
```



# Country Router:
### Get request (gets all countries)
##### request
```bash
curl -v -X GET http://localhost:8000/api/country
```

# Book Router:
### Get request (gets all countries)
##### request
curl -v -X GET http://localhost:8000/api/book

### Get request (get book by name)
##### request
curl -v -X GET http://localhost:8000/api/book/name/test

### Get request  (get book by id)
##### request
curl -v -X GET http://localhost:8000/api/book/id/5b9f533b68dfd41abc2aadd6


