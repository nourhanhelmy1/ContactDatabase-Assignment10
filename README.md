# Contact Database Project

This project is a simple Contact Database web application that allows users to enter and manage contact information. It is built using ASP.NET Core Razor Pages and utilizes EdgeDB 3.2 to store and retrieve contact data.

## Features

- **Form**:
  - First Name: Text input for entering the first name of the contact (required).
  - Last Name: Text input for entering the last name of the contact (required).
  - Email: Text input for entering the email address of the contact (required).
  - Title: Drop-down menu for selecting the title of the contact (Mr, Mrs, etc) (required).
  - Description: Textarea for entering additional information about the contact.
  - Date of Birth: Date picker for selecting the date of birth of the contact.
  - Marriage Status: Checkbox for indicating whether the contact is married.

- **Contact List**:
  - Displays a list of all the entered contacts with the following information:
    - First Name
    - Last Name
    - Email
    - Title
    - Description
    - Date of Birth
    - Marriage Status

- **Search Filter**:
  - Provides a search bar to filter the contact list based on the first name, last name, or email.

## Getting Started

1. Clone the repository to your local machine.
2. Make sure you have .NET Core and EdgeDB installed on your system.
3. Open the solution in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
4. Configure the EdgeDB connection.

## How to Use

1. Open your web browser and navigate to http://localhost:5000 to access the Contact Database web application.
2. **Fill out the form** with the contact details and click on the "Add Contact" button to add a new contact to the database.
3. The contact will be displayed in the contact list below the form.
4. **Use the search bar** to filter the contact list based on the first name, last name, or email. The list will update dynamically as you type in the search bar.
5. You can **view and manage the entered contacts** in the contact list.

## Contributing

Contributions to this project are welcome. If you find any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.
