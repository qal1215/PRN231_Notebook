-- Database: Lab3_PRN231
CREATE DATABASE "Lab3_PRN231"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

-- Create the Category table
CREATE TABLE IF NOT EXISTS Category (
    CategoryId SERIAL PRIMARY KEY,
    CategoryName VARCHAR(40) NOT NULL
);
	
-- Create the Product table
CREATE TABLE IF NOT EXISTS Product (
    ProductId SERIAL PRIMARY KEY,
    ProductName VARCHAR(40) NOT NULL,
    UnitsInStock INT NOT NULL,
    UnitPrice DECIMAL(18, 2) NOT NULL,
    CategoryId INT NOT NULL,
    CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId)
        REFERENCES Category (CategoryId)
        ON UPDATE CASCADE
        ON DELETE CASCADE
);