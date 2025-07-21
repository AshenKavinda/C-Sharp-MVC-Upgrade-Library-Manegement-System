# Library Management System

A comprehensive desktop application built with C# Windows Forms following the MVC (Model-View-Controller) architecture pattern for efficient library management operations.

## 🚀 Features

### 📚 Book Management
- Add, update, and delete books
- Track book copies and availability
- Book inventory management with pricing
- Real-time book status tracking

### 👥 Customer Management
- Customer registration and profile management
- Automatic customer ID generation
- Customer information tracking (Name, NIC, Phone, Email)
- Customer history and activity logs

### 🔄 Reservation System
- Book reservation functionality
- Reservation tracking and management
- Reservation history logs
- Automated reservation ID generation

### 💰 Payment Management
- Monthly payment tracking
- Payment history records
- Fee management system
- Multiple payment type support
- Payment receipt generation

### 📋 Reporting & History
- Comprehensive reservation history
- Customer activity reports
- Payment tracking reports
- Book circulation statistics

### ⚙️ Settings & Configuration
- System configuration management
- Database connection settings
- Customizable fee structures
- Theme and UI customization

## 🏗️ Architecture

This application follows the **MVC (Model-View-Controller)** pattern:

- **Models**: `Book.cs`, `Customer.cs`, `Reservation.cs`, `Payment.cs`, `Settings.cs`
- **Views**: Windows Forms (`FormBook`, `FormCustomerHandle`, `FormReservationHandle`, etc.)
- **Controllers**: `BookController.cs`, `CustomerController.cs`, `ReservationController.cs`, etc.

## 🛠️ Technology Stack

- **Framework**: .NET Framework 4.7.2
- **Language**: C#
- **UI**: Windows Forms
- **Database**: SQL Server
- **Architecture**: MVC Pattern
- **IDE**: Visual Studio

## 📋 Prerequisites

- Windows Operating System
- .NET Framework 4.7.2 or higher
- SQL Server (Local or Remote)
- Visual Studio 2017 or later (for development)

## 🗄️ Database Schema

The system uses the following main tables:

```sql
- Book (BID, Name, Price, NoCopy, NoActiveCopys)
- Customer (CID, FName, LName, NIC, PNo, Email)
- Reservation (RID, CID, BID, Date)
- Payment (PID, Date, Amount, CID)
- MonthlyPayment (PID, CID, Month)
- fees (PaymentType, fee)
```

## 🚀 Installation & Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/AshenKavinda/C-Sharp-MVC-Upgrade-Library-Manegement-System.git
   ```

2. **Database Setup**
   - Create a SQL Server database named `LibraryDB`
   - Execute the SQL script from `document/script.sql` to create tables
   - Update the connection string in `DataBaseManeger.cs`

3. **Configuration**
   - Open the solution file `Library.sln` in Visual Studio
   - Update the database connection string in `DataBaseManeger.cs`:
     ```csharp
     conn = new SqlConnection("Data Source=YOUR_SERVER;Initial Catalog=LibraryDB;Integrated Security=True");
     ```

4. **Build and Run**
   - Build the solution in Visual Studio
   - Run the application
   - The main menu will appear with access to all modules

## 💻 Usage

### Starting the Application
The application starts with a main menu (`FormMenu`) providing access to all modules:

- **Book Management**: Add, edit, and manage book inventory
- **Customer Management**: Register and manage customer information
- **Reservations**: Handle book reservations and returns
- **Payments**: Process and track customer payments
- **Reports**: View history and generate reports
- **Settings**: Configure system preferences

### Key Workflows

1. **Adding a New Book**
   - Navigate to Book Management
   - Enter book details (ID, Name, Price, Copies)
   - Save to inventory

2. **Customer Registration**
   - Access Customer Management
   - Fill in customer details
   - System auto-generates Customer ID

3. **Book Reservation**
   - Select customer and available book
   - Create reservation record
   - Track reservation status

4. **Payment Processing**
   - Record customer payments
   - Track monthly subscriptions
   - Generate payment history

## 📁 Project Structure

```
Library/
├── Models/
│   ├── Book.cs                 # Book entity and business logic
│   ├── Customer.cs             # Customer entity and operations
│   ├── Reservation.cs          # Reservation management
│   ├── Payment.cs              # Payment processing
│   └── Settings.cs             # System configuration
├── Views/
│   ├── FormMenu.cs             # Main application menu
│   ├── FormBook.cs             # Book management interface
│   ├── FormCustomerHandle.cs   # Customer management UI
│   ├── FormReservationHandle.cs # Reservation interface
│   ├── FormPayment.cs          # Payment processing UI
│   └── FormSettings.cs         # Settings configuration
├── Controllers/
│   ├── BookController.cs       # Book operations controller
│   ├── CustomerController.cs   # Customer operations controller
│   └── ReservationController.cs # Reservation controller
├── Database/
│   └── DataBaseManeger.cs      # Database connection management
└── Utilities/
    └── ThemeColor.cs           # UI theming utilities
```

## 🔧 Configuration

### Database Connection
Update the connection string in `DataBaseManeger.cs`:

```csharp
// For local SQL Server
conn = new SqlConnection("Data Source=PC-1;Initial Catalog=LibraryDB;Integrated Security=True");

// For remote SQL Server
conn = new SqlConnection("Data Source=server;User ID=username;Password=password;Initial Catalog=LibraryDB");
```

### Application Settings
Modify system settings through the Settings form or directly in the `Settings.cs` class.

## 🚀 Deployment

The project includes a setup project (`libSysSetUp`) for creating an installer:

1. Build the setup project
2. Distribute the generated MSI file
3. Install on target machines with proper SQL Server access

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**AshenKavinda**
- GitHub: [@AshenKavinda](https://github.com/AshenKavinda)

## 🙏 Acknowledgments

- Built with C# Windows Forms
- Implements MVC architecture pattern
- Uses SQL Server for data persistence
- Designed for educational and practical library management needs
 
