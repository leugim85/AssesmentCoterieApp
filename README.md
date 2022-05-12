# AssesmentCoterieApp
# APP Guides Lines 

### Run The App


### How to:

- This application was developed using Sqlite as database, taking into account this, it will be enough to clone the repository and when you want to use it, you only need to start the debugging of the application, the main project is "CoterieAPP.Api", make sure that this is the one that is running.

- With the application running, you will find 5 endpoints that were developed to guarantee all the functionalities of the program:

### Bussiness:

#### POST
Here you can add a new bussines, and the payload required is like:

```json
{
    "name": "Some new business",
    "businessFactor": 1 
}
```

#### GET
Here you can get all bussines registered, the response that will get is like:

```json
[
  {
    "id": "65a186ef-961c-4707-871a-c3d145f6c4e1",
    "name": "Plumber",
    "businessFactor": 0.5
  },
  {
    "id": "ba58a2c9-e8ab-41f5-bb96-f34a9ea3ac4a",
    "name": "Architect",
    "businessFactor": 1
  },
  {
    "id": "7111f089-e49c-4970-b3a4-e849a85d9505",
    "name": "Programmer",
    "businessFactor": 1.25
  }
[
```

### Quotes:

#### POST
Here you can add a new quote and will get the result of this quote, the payload required is similar to:

```json
{
  "business": "Plumber",
  "revenue": 500000,
  "states": [
    "Florida",
    "TX",
    "OH"
  ]
}
```
The response tht yo will get will be:
```json
{
  "transactionId": "a46cc1b0-3c4f-42ba-a421-40831460f547",
  "business": "Plumber",
  "revenue": 500000,
  "isSuccesful": true,
  "premiums": [
    {
      "premium": 1200,
      "state": "FL"
    },
    {
      "premium": 943,
      "state": "TX"
    },
    {
      "premium": 1000,
      "state": "OH"
    }
  ]
}
```


### States:

#### POST
Here you can add a new state, and the payload required is like:

```json
{
  "name": "Some new state name",
  "abbreviation": "The state's abbreviation",
  "factorState": 0  // some new double value
}
```

#### GET
Here you can get all states registered, the response that will get is similar to:

```json
[
   {
    "id": "7da149ad-7ed6-4299-bdca-648053e76244",
    "name": "Texas",
    "abbreviation": "TX",
    "factorState": 0.943
  },
  {
    "id": "49ef0f22-4243-4874-bc60-fd450fb172cf",
    "name": "Florida",
    "abbreviation": "FL",
    "factorState": 1.2
  },
  {
    "id": "c7e0671b-abaf-437f-ac03-62c24d6ab0ce",
    "name": "Ohio",
    "abbreviation": "OH",
    "factorState": 1
  }
[
```

### Test The App

To run the tests developed to evaluate the behavior of the application, just enter the Test Explorer and run all the tests.
