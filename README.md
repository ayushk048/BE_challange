#   BE Challenge

![cloudDiagram drawio](https://user-images.githubusercontent.com/75988502/190862856-6d49fd42-414d-4b95-9196-8a3ccdeecbfc.png)

This Program is part of the  Backend Coding Exercise

Created 3 APIs:
1. Get All Users
2. Get the User By Email address
3. Create User

### User DataBase Schema

```
{ 
    “Id”: “11ff2969-f251-46df-bfb2-cf5ec768d976”,
    “firstName”: “Matthew”, 
    “middleName”: “Decker”, 
    “lastName”: ”Lund”, 
    “phoneNumber”: “555-555-5555”, 
    “emailAddress”: “matt@awesomedomain.com” 
} 
```

## APIs List
### Get all Users
```
GET /api/users
```
**Response 200**
```
[
    { 
        “userId”: “54c4e684-0a6a-449d-b445-61ddd12ffd3d”, 
        “name”: “Matthew Decker Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    },
    { 
        “userId”: “54c4e684-0a6a-449d-b445-61ddd12ffd3d”, 
        “name”: “Matthew Decker Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    }, 
]
```

### Get User By Email Address
```
GET /api/users?email="ayush@xyt.com"
```
**Response 200**
```
    { 
        “userId”: “54c4e684-0a6a-449d-b445-61ddd12ffd3d”, 
        “name”: “Matthew Decker Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    }

```

### Create User
```
POST /api/users
```
**Request body**
```
    { 
        “firstName”: “Matthew”, 
        “middleName”: “Decker”, 
        “lastName”: ”Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    }
```
**Response 201**
```
{
  "userId": "df03d450-d8d1-4be4-b0bf-1336d5344bbf",
  "fullName": "Matthew Decker Lund",
  "phoneNumber": "555-555-5555",
  "emailAddress": "matt@awesomedomain.com"
}
```

for additional Responses: https://localhost:7076/swagger/index.html

## Health check endpoint
https://localhost:7076/health

## Docker

Run the following command on terminal to run Docker container
```
> docker build -t image .
```
```
> docker run -d -p 8080:80 --name   image
```

## Integration Tests:
![image](https://user-images.githubusercontent.com/75988502/190861310-10fd2a8a-6fb6-4927-a803-20f37b816f65.png)

