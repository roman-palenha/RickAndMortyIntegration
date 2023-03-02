CREATE TABLE Person (
	id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
	phone_number VARCHAR(20) NOT NULL,
    email VARCHAR(50) NOT NULL
);

CREATE TABLE Passengers (
    id INT PRIMARY KEY,
	person_id INT NOT NULL,
    nationality VARCHAR(50) NOT NULL,
	FOREIGN KEY (person_id) REFERENCES Person(id)
);

CREATE TABLE Airports (
    id INT PRIMARY KEY,
    airport_name VARCHAR(50) NOT NULL,
    country VARCHAR(50) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
);

CREATE TABLE Flights (
    id INT PRIMARY KEY,
    flight_number VARCHAR(10) NOT NULL,
    departure_airport_id INT NOT NULL,
    arrival_airport_id INT NOT NULL,
    departure_time DATETIME NOT NULL,
    arrival_time DATETIME NOT NULL,
    aircraft_type VARCHAR(50) NOT NULL,
    ticket_price DECIMAL(10, 2) NOT NULL,
	FOREIGN KEY (departure_airport_id) REFERENCES Airports(id),
	FOREIGN KEY (arrival_airport_id) REFERENCES Airports(id)
);

CREATE TABLE Tickets (
    id INT PRIMARY KEY,
    passenger_id INT NOT NULL,
    flight_id INT NOT NULL,
    departure_time DATETIME NOT NULL,
    seat_number INT NOT NULL,
    FOREIGN KEY (passenger_id) REFERENCES Passengers(id),
    FOREIGN KEY (flight_id) REFERENCES Flights(id)
);

CREATE TABLE Payments (
    id INT PRIMARY KEY,
    ticket_id INT NOT NULL,
    payment_date DATETIME NOT NULL,
    payment_method VARCHAR(50) NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (ticket_id) REFERENCES Tickets(id)
);

CREATE TABLE Employees (
    id INT PRIMARY KEY,
	person_id INT NOT NULL,
	airport_id INT NOT NULL,
    position VARCHAR(50) NOT NULL,
	FOREIGN KEY (person_id) REFERENCES Person(id),
	FOREIGN KEY (airport_id) REFERENCES Airports(id)
);
