INSERT INTO Customers ([Name], PhoneNumber, Email)
VALUES
('Marko Petrovic', '0888-123456', 'marko.petrovic@email.rs')

INSERT INTO Products ([Name], Price, ManufacturerId, CategoryId)
VALUES
('Asus ZenBook 14', 1199.99, 6, 2),
('Sony WF-1000XM5', 299.99, 10, 10)

INSERT INTO StoresProducts
VALUES
(2, 61),
(12, 62)

INSERT INTO Orders
VALUES
('2025-03-04', 21, 61, 2),
('2024-12-20', 21, 62, 12),
('2025-01-25', 18, 14, 1),
('2025-02-26', 7, 31, 20)