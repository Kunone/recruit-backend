# API Service
Simple API service to support get and save credit card in a secure way. It is a fully runnable application and all 3 endpoints are working as expected, with the encrypted data stored in a database.

## Features implemented
- JWT Token implemented to protect API
- AES encryption applied to protect Credit card information
- Regular Expression applied to validate comming request payload
- Dapper used to help query database
- AutoMapper used to convert between ViewModel and Model
- I used native SQL to create database/table as I am not a big fan in DB Migration, which may lead to some unexpected issues.

## To do - 2 hours is not enough :(
- More unit tests and add integration test
- Implemented JWT is just a POC, better to use a existing SaaS like Auth0 in the production env.
- To make the service running like microservice in Docker so to easiy add another test container to do integration test. [:( no time to make it happen]