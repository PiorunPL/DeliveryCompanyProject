# Authentication
## Client
### Login
#### Route
	auth/client/login
#### Access
	Everyone
#### Request
```http
POST <<ROUTE>>
Content-Type: application/json

{
	"email": "jakubm55555@gmail.com",
	"password": "Jakub1232!"
}
```
#### Response
```http
HTTP/1.1 200 OK 
Connection: close 
Content-Type: application/json; charset=utf-8 
Date: Fri, 02 Dec 2022 02:08:01 GMT 
Server: Kestrel 
Transfer-Encoding: chunked 

{ 
	"id": "2ac855f2-42ff-43ba-8cbb-06427f9afa4b", 
	"firstName": "Jakub", 
	"lastName": "Maciejewski", 
	"email": "jakubm55555@gmail.com", 
	"token": <<TOKEN>>
}
```

### Registration
#### Route
	auth/client/register
#### Access
	Everyone
#### Request
```http
POST <<ROUTE>>
Content-Type: application/json

{
	"firstName": "Jakub",
	"lastName": "Maciejewski",
	"email": "jakubm55555@gmail.com",
	"password": "Jakub1232!"
}
```
#### Response
```http
HTTP/1.1 200 OK 
Connection: close 
Content-Type: application/json; charset=utf-8 
Date: Fri, 02 Dec 2022 02:05:09 GMT 
Server: Kestrel 
Transfer-Encoding: chunked 

{ 
	"id": "2ac855f2-42ff-43ba-8cbb-06427f9afa4b", 
	"firstName": "Jakub", 
	"lastName": "Maciejewski", 
	"email": "jakubm55555@gmail.com", 
	"token": <<TOKEN>>
}
```

## Courier
### Login
#### Route
	auth/courier/login
#### Access
	Everyone
#### Request
```http
POST <<ROUTE>>
Content-Type: application/json

{
	"email": "jakubm55555@gmail.com",
	"password": "Jakub1232!"
}
```
#### Response
```http
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Fri, 02 Dec 2022 02:20:33 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
	"id": "2ac855f2-42ff-43ba-8cbb-06427f9afa4b",
	"firstName": "Jakub",
	"lastName": "Maciejewski",
	"email": "jakubm55555@gmail.com",
	"dateBirth": "2001-04-28T00:00:00",
	"address": "Grójecka 39 Warszawa",
	"token": <<TOKEN>>
}
```
### Registration
#### Route
	auth/courier/register
#### Access
	Administrator only
#### Request
```http
POST <<ROUTE>>
Authorization: Bearer <<TOKEN>>
Content-Type: application/json

{
	"firstName": "Jakub",
	"lastName": "Maciejewski",
	"email": "jakubm55555@gmail.com",
	"password": "Jakub1232!",
	"dateBirth": "2001-04-28",
	"address": "Grójecka 39 Warszawa"
}
```
#### Response
```http
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Fri, 02 Dec 2022 02:19:29 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
	"id": "2ac855f2-42ff-43ba-8cbb-06427f9afa4b",
	"firstName": "Jakub",
	"lastName": "Maciejewski",
	"email": "jakubm55555@gmail.com",
	"dateBirth": "2001-04-28T00:00:00",
	"address": "Grójecka 39 Warszawa",
	"token": <<TOKEN>>
}

```
## Administrator
### Login
#### Route
	auth/administrator/login
#### Access
	Everyone
#### Request
```http
POST <<ROUTE>>
Content-Type: application/json

{
	"email": "default@default.com",
	"password": "DeFaUlT"
}
```
#### Response
```http
HTTP/1.1 200 OK 
Connection: close 
Content-Type: application/json; charset=utf-8 
Date: Fri, 02 Dec 2022 02:15:15 GMT 
Server: Kestrel 
Transfer-Encoding: chunked 

{ 
	"id": "2ac855f2-42ff-43ba-8cbb-06427f9afa4b", 
	"firstName": "Default", 
	"lastName": "Default", 
	"email": "default@default.com", 
	"dateBirth": "2022-12-02T02:15:16.2610022Z", 
	"address": "DefaultAddress", 
	"token": <<TOKEN>>
}
```

### Registration
#### Route
	 auth/administrator/register
#### Access 
	Administrator only
#### Request
```http
POST <<ROUTE>>
Authorization: Bearer <<TOKEN>>
Content-Type: application/json

{
	"firstName": "Jakub",
	"lastName": "Maciejewski",
	"email": "jakubm55555@gmail.com",
	"password": "Jakub1232!",
	"dateBirth": "2001-04-28",
	"address": "Grójecka 39 Warszawa"
}
```
#### Response
```http
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Fri, 02 Dec 2022 02:18:15 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
  "id": "2ac855f2-42ff-43ba-8cbb-06427f9afa4b",
  "firstName": "Jakub",
  "lastName": "Maciejewski",
  "email": "jakubm55555@gmail.com",
  "dateBirth": "2001-04-28T00:00:00",
  "address": "Grójecka 39 Warszawa",
  "token": <<TOKEN>>
}
```
