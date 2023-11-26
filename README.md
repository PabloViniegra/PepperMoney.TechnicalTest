# Books API

This project provides an API for managing a collection of books.

## Project Structure

The project is structured around the ASP.NET Core framework using C#. The key components include:
- **Controllers:** Handles incoming HTTP requests, interacts with the repository, and returns responses.
- **Repository:** Interacts with the database using Entity Framework Core to perform CRUD operations on books.
- **Models:** Represents entities such as books and DTOs for API communication.
- **Dependency Injection:** Utilizes interfaces and DI to decouple components for testability and maintainability.

## Design Patterns

The project follows some common design patterns:
- **Repository Pattern:** Separates data access logic by using an interface (`IBooksRepository`) implemented by `BooksRepository`.
- **Exception Handling:** Utilizes custom exceptions like `BookAlreadyExistsException` for specific error scenarios.
- **DTOs (Data Transfer Objects):** Uses DTOs to transfer data between client and server to avoid exposing the internal data model.

## How to Use

### Prerequisites
- Docker installed on your machine.

### Steps to Download and Run
1. **Pull the Docker image:**
   ```bash
   docker pull pabloviniegra/books_api:v1
   
2. **Run the Docker container:**
   ```bash
   docker run --name books_api -p 32770:80 -d pabloviniegra/books_api:v1

### Testing the API
Once the container is running, you can test the GET request:
- Open your browser or API client and go to: `http://localhost:32770/api/v1/books`
