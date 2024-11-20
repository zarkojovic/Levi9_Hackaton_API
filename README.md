### `5 Dana u Oblacima` Hackathon Project

This project was developed during the **Levi9 Hackathon - 5 dana u oblacima** using **ASP.NET** with a focus on **Domain-Driven Design (DDD)** and **Clean Architecture**. The application allows managing players, teams, and matches while calculating player statistics (e.g., ELO ratings) and returning detailed player data.

---

## **Tech Stack and Architecture**

### **1. Tech Stack**
- **Language**: C#
- **Framework**: ASP.NET
- **Database**: In-Memory Database (for the task)
- **Libraries/Tools**:
  - **CQRS**: To separate Commands and Queries.
  - **FluentValidation**: For request validation.
  - **Global Exception Handler**: To handle application-wide exceptions gracefully.

### **2. Clean Architecture Layers**
The application is structured into five layers to ensure separation of concerns and maintainability:
- **Domain**: Core business logic, including entities, value objects, and interfaces.
- **Application**: Contains CQRS (Commands and Queries) for use-case implementations and validation logic.
- **Implementation**: Handles business services and processes interacting with the application and domain layers.
- **DataAccess**: Manages database interaction (in this case, an in-memory database).
- **API**: Provides REST endpoints for interacting with the application.

---

## **Features**

1. **Player Management**:
   - Add new players to the database.
   - Retrieve player details, including statistics and ratings.

2. **Team Management**:
   - Add and manage teams.
   - Associate players with teams.

3. **Match Management**:
   - Create matches between two teams.
   - Calculate player statistics (e.g., ELO rating) based on match outcomes.
   - Update player records, including wins, losses, and hours played.

4. **ELO Calculation**:
   - Implements the **ELO rating system** to dynamically adjust player rankings based on match outcomes.

5. **Statistical Analysis**:
   - Retrieve detailed statistics for individual players.

6. **Validation and Exception Handling**:
   - **FluentValidation**: Ensures all input data is valid before processing.
   - **Global Exception Handler**: Captures and handles exceptions in a user-friendly manner.

---

## **Task Description**

The hackathon required implementing an application capable of:
- Storing and managing **players**, **teams**, and **matches** in a database.
- Calculating and maintaining player statistics, including:
  - **ELO ratings**.
  - Wins, losses, and hours played.
- Providing detailed statistics for players upon request.

---

## **How It Works**

1. **Add Players**:
   - POST endpoint to add new players to the database.

2. **Create Teams**:
   - POST endpoint to create teams and assign players.

3. **Record Matches**:
   - POST endpoint to record match details between two teams.
   - Automatically updates player statistics, including ELO ratings.

4. **Retrieve Player Statistics**:
   - GET endpoint to retrieve details about a specific player.

---

## **Project Highlights**

- **Domain-Driven Design**:
  - Focused on encapsulating business rules and domain logic in a modular way.

- **CQRS Implementation**:
  - Commands handle write operations (e.g., adding players, creating matches).
  - Queries handle read operations (e.g., fetching player statistics).

- **Clean Architecture**:
  - Strict separation of concerns between layers to ensure scalability and maintainability.

- **In-Memory Database**:
  - Used for persistence during the hackathon to simplify testing and development.

---

## **Usage**

1. Clone the repository:
   ```bash
   git clone https://github.com/zarkojovic/Levi9_Hackaton_API.git
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Use API endpoints (e.g., via Postman) to manage players, teams, and matches.

---

## **Future Improvements**
- Replace the in-memory database with a persistent database like SQL Server or PostgreSQL.
- Add authentication and role-based access control.
- Implement automated tests for improved reliability.
- Extend statistics to include additional metrics (e.g., performance trends).

---

This project demonstrates the power of **Clean Architecture** and **CQRS** in building scalable, maintainable, and modular applications within a short timeframe. 🎉
