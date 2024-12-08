# Theatre Booking System

A comprehensive .NET Core-based theatre booking system that enables efficient management of theatres, events, and seat bookings.

## 🎭 Features

### Theatre Management
- Create and manage theatres with dynamic seating layouts
- Support for multiple seat types (VIP, Premium, Normal)
- Professional seat numbering system (e.g., "A-01", "B-15")
- Automatic seat generation with configurable layouts

### Event Management
- Create and manage events with detailed information
- Support for event images (Base64 format)
- Date and time scheduling
- Location tracking with latitude and longitude
- Theatre assignment for events

### Seat Management
- Dynamic seat allocation
- Multiple seat types
- Seat availability tracking
- Seat booking functionality
- Seat search by theatre and seat numbers

### User Management
- User registration and management
- Seat booking history
- User-seat associations

## 🛠 Technical Stack

- **Framework**: .NET Core
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Architecture**: Multi-layer architecture
  - Data Access Layer
  - Service Layer
  - Controller Layer
  - DTOs for data transfer

## 📁 Project Structure

```plaintext
theatre-booking/
├── Controllers/
│   ├── EventController.cs
│   ├── SeatController.cs
│   ├── TheatreController.cs
│   └── UserController.cs
├── DataAccess/
│   ├── models/
│   ├── contracts/
│   └── repos/
├── Services/
│   ├── Contracts/
│   ├── Dto/
│   └── ServicesRepos/
└── Program.cs
```

## 📚 API Documentation

### Theatre Endpoints

| Method | Endpoint | Description | Request Body | Response |
|--------|----------|-------------|--------------|-----------|
| GET | `/api/Theatre` | Get all theatres | - | List of TheatreResponseDto |
| GET | `/api/Theatre/{id}` | Get theatre by ID | - | TheatreResponseDto |
| POST | `/api/Theatre` | Create new theatre | TheatreDto | Success message |
| PUT | `/api/Theatre/{id}` | Update theatre | TheatreDto | Success message |

### Event Endpoints

| Method | Endpoint | Description | Request Body | Response |
|--------|----------|-------------|--------------|-----------|
| GET | `/api/Event` | Get all events | - | List of EventDto |
| GET | `/api/Event/{id}` | Get event by ID | - | EventDto |
| POST | `/api/Event` | Create new event | EventDto | Success message |
| PUT | `/api/Event/{id}` | Update event | EventDto | Success message |
| PUT | `/api/Event/image/{id}` | Update event image | UpdateImageDto | Success message |

### Seat Endpoints

| Method | Endpoint | Description | Request Body | Response |
|--------|----------|-------------|--------------|-----------|
| GET | `/api/Seat/Seats` | Get all seats | - | List of Seat |
| GET | `/api/Seat/{id}` | Get seat by ID | - | Seat |
| GET | `/api/Seat/Theatre/{id}` | Get seats by theatre ID | - | List of Seat |
| POST | `/api/Seat/Search` | Search seats | GetSeatsByTheatreIdAndSeatsNumber | List of Seat |
| PUT | `/api/Seat/{id}` | Update seat | SeatDto | Success message |

### Request/Response Models Example

#### TheatreDto
```json
{
  "theatreName": "string",
  "capacity": "integer"
}
```
## 🚀 Getting Started

### Prerequisites
- .NET Core SDK (Latest Version)
- SQL Server
- Visual Studio 2022 or similar IDE

### 1-Clone the repository:
```bash
git clone https://github.com/hassanolaa/theatrebooking.git
```
### 2- Update the connection string in appsettings.json:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your-Connection-String"
  }
}
```

### 3- Run Entity Framework migrations:
```bash
dotnet ef database update
```

### 4- Build and run the application:
```bash
dotnet build
dotnet run
```

## 📝 License
This project is licensed under the MIT License - see the LICENSE file for details.

## 👥 Author
- Hassan Abdelkhalek [hassanolaa]

