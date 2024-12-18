# Employee Manager API

## Project Overview

The **Employee Manager API** is a web application built with ASP.NET Core that provides functionality for managing employee data in a simple JSON file. This API allows users to perform various operations, such as adding, updating, deleting, and searching employees. Additionally, it supports filtering employees based on specific criteria like language proficiency and scores.

## Features

- **Read Employees Data**: Load employee data from a JSON file.
- **Add Employee**: Add a new employee to the data.
- **Delete Employee**: Remove an employee by their ID.
- **Update Employee**: Update the designation of an employee by their ID.
- **Search Employee by Designation**: Retrieve employees with a specific designation.
- **Search by Language Proficiency**: Retrieve employees who know a specified language with a score above a given threshold.
- **Get Employees with High Java Proficiency**: List employees who know Java with a score greater than 50.

## Technologies Used

- **ASP.NET Core**: Web framework for building RESTful APIs.
- **C#**: Programming language used for developing the application.
- **JSON**: Format used to store employee data.
- **Swagger/OpenAPI**: For API documentation.



### Setup Instructions

1. **Clone the Repository**:

    ```bash
    git clone https://github.com/yourusername/Employee-Manager-API.git
    cd Employee-Manager-API
    ```

2. **Install Dependencies**:

    Run the following command to restore the necessary packages:

    ```bash
    dotnet restore
    ```

3. **Run the Application**:

    Start the application using the following command:

    ```bash
    dotnet run
    ```

4. **API Documentation**:

    Once the application is running, you can view the API documentation via Swagger by navigating to:

    ```bash
    http://localhost:5000/swagger
    ```

### API Endpoints

- **GET /api/employee**: Get a list of all employees.
- **GET /api/employee/{id}**: Get an employee by ID.
- **POST /api/employee**: Add a new employee.
- **DELETE /api/employee/{id}**: Delete an employee by ID.
- **PUT /api/employee/{id}**: Update the Data of an employee by ID.
- **GET /api/employee/designation/{designation}**: Get employees by designation.
- **GET /api/employee/language-experts**: Get employees who know a specified language with a score higher than a user-defined value.

### Example Requests

1. **Get Employee by ID**:

    ```bash
    GET /api/employee/1000
    ```

2. **Add a New Employee**:

    ```bash
    POST /api/employee
    {
      "FirstName": "Jane",
      "LastName": "Doe",
      "EmployeeID": 3000,
      "Designation": "Developer",
      "KnownLanguages": [
        { "LanguageName": "Java", "ScoreOutof100": 85 },
        { "LanguageName": "C#", "ScoreOutof100": 70 }
      ]
    }
    ```

3. **Update Employee Data**:

    ```bash
    {
      "FirstName": "Jane",
      "LastName": "Doe",
      "Designation": "Developer",
      "KnownLanguages": [
        { "LanguageName": "Java", "ScoreOutof100": 85 },
        { "LanguageName": "C#", "ScoreOutof100": 70 }
      ]
    }
    ```

4. **Search Employees by Language and a score higher than given score**:

    ```bash
    GET /api/employee/language-experts?language=Java&score=60
    ```

### Testing the API

You can use tools like **Postman** or **cURL** to test the API endpoints.

## Contributing

Feel free to fork this project and create a pull request. If you find any bugs or have suggestions for improvements, please open an issue in the GitHub repository.
