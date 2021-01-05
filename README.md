# How to run it
As this API has database dependency, please run it with pre-defined docker compose.

## Start service
```
git clone https://github.com/Kunone/recruit-backend.git
cd recruit-backend
docker-compose up --build
curl http://localhost:8080/api/healthcheck
```
Run above scripts to download code and run API service with SQL. Database and tables are already pre-defined and mounted to the SQL container.

## Test APIs
You can test API from `rest api call`

1. Open `/rest-test/test.http` file
2. Request: `get token`
3. Update `@token` with new token
4. Request: `save card`
5. Request: `get all cards` to see if saved card in the response
6. Request: `get one card` by adding one ID from above response to check this specific card

# Original README
># Backend
>Create an API to receive the data captured in the frontend.
>
>We recommend using C#, .Net Core, and WebAPI to build this API.
>
>## Specification
>- Inputs:
>    - Name (any alphanumeric character - maximum 50)
>    - Credit card needs to be numeric and be in the valid credit cards storage
>    - CVC is any number
>    - Expiry date is any valid date
>- One operation to store the input data
>    - Validate the information received from the frontend
>- One operation to query all data that has been stored
>- One operation to query one of the input data stored
>- Storage (optional)
>    - Create the storage for the valid credit card
>    - Create the storage for the input fields
>- Use REST standards
>
>## Commits
>Please commit frequently to communicate your throughts while working on this assignment
>
>## What is valued
>- Clean code
>- Design patterns
>- Unit tests
>- Integration tests
>- Performance
>- Security
>- Dependency injection
>- Http verbs, and resources naming
>- API documentation for consumers
>
>## Duration
>Use about 2 hours on this assignment. You are expected to complete most of what is defined in the specification section also >considering the things we value.
>
>## Tech
>- API following the REST standards