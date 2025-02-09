SET IDENTITY_INSERT Manufacturers ON;
INSERT INTO Manufacturers (Id, Name, Country) VALUES
(1, 'Apple', 'USA'),
(2, 'Samsung', 'South Korea'),
(3, 'Lenovo', 'China'),
(4, 'Dell', 'USA'),
(5, 'HP', 'USA'),
(6, 'Asus', 'Taiwan'),
(7, 'Acer', 'Taiwan'),
(8, 'Microsoft', 'USA'),
(9, 'Xiaomi', 'China'),
(10, 'Sony', 'Japan'),
(11, 'LG', 'South Korea'),
(12, 'Razer', 'Singapore'),
(13, 'Huawei', 'China'),
(14, 'MSI', 'Taiwan'),
(15, 'Google', 'USA');
SET IDENTITY_INSERT Manufacturers OFF;

SET IDENTITY_INSERT Categories ON;
INSERT INTO Categories (Id, Name) VALUES
(1, 'Smartphones'),
(2, 'Laptops'),
(3, 'Tablets'),
(4, 'Desktops'),
(5, 'Monitors'),
(6, 'Keyboards'),
(7, 'Mice'),
(8, 'Printers'),
(9, 'Smartwatches'),
(10, 'Headphones'),
(11, 'Speakers'),
(12, 'Storage Devices'),
(13, 'Networking Equipment'),
(14, 'Cameras'),
(15, 'Gaming Consoles');
SET IDENTITY_INSERT Categories OFF;

SET IDENTITY_INSERT Products ON;
INSERT INTO Products (Id, Name, Price, Specifications, ManufacturerId, CategoryId) VALUES
(1, 'iPhone 14 Pro', 1099.99, '256GB, A16 Bionic Chip, 6.1-inch display', 1, 1),
(2, 'Galaxy S23 Ultra', 1199.99, '512GB, Snapdragon 8 Gen 2, 6.8-inch display', 2, 1),
(3, 'MacBook Pro 16"', 2499.00, 'M2 Pro, 16GB RAM, 1TB SSD', 1, 2),
(4, 'Dell XPS 13', 1399.00, 'Intel i7, 16GB RAM, 512GB SSD', 4, 2),
(5, 'Lenovo ThinkPad X1', 1799.00, 'Intel i7, 32GB RAM, 1TB SSD', 3, 2),
(6, 'iPad Air', 799.00, 'M1 chip, 64GB, 10.9-inch display', 1, 3),
(7, 'Galaxy Tab S8', 899.00, '11-inch display, 128GB, S Pen', 2, 3),
(8, 'HP Envy Desktop', 899.99, 'Intel i5, 16GB RAM, 1TB HDD', 5, 4),
(9, 'LG UltraFine 5K', 1299.99, '27-inch 5K display, Thunderbolt 3', 11, 5),
(10, 'MSI Optix MAG272C', 299.99, '27" curved, 165Hz, 1ms response time', 14, 5),
(11, 'Razer Huntsman Mini', 119.99, '60% gaming keyboard, Razer Optical Switches', 12, 6),
(12, 'Logitech MX Master 3', 99.99, 'Ergonomic, Wireless, USB-C', 7, 7),
(13, 'Canon PIXMA G6020', 249.99, 'All-in-One, Wireless Ink Tank Printer', 10, 8),
(14, 'Apple Watch Series 9', 399.99, 'GPS, 45mm, Blood Oxygen Sensor', 1, 9),
(15, 'Sony WH-1000XM5', 349.99, 'Wireless Noise Cancelling Headphones', 10, 10),
(16, 'Google Nest Audio', 99.99, 'Smart Speaker with Google Assistant', 15, 11),
(17, 'Samsung T7 SSD 1TB', 129.99, 'USB 3.2, Portable SSD', 2, 12),
(18, 'TP-Link Archer AX55', 149.99, 'AX3000 Dual-Band Wi-Fi 6 Router', 2, 13),
(19, 'Canon EOS R6', 2499.99, 'Full-frame Mirrorless Camera, 20MP', 10, 14),
(20, 'PlayStation 5', 499.99, '825GB SSD, DualSense Controller', 10, 15),
(21, 'Surface Laptop 5', 1499.00, 'Intel i7, 16GB RAM, 512GB SSD', 8, 2),
(22, 'Asus ROG Zephyrus G14', 1799.00, 'Ryzen 9, RTX 4060, 16GB RAM, 1TB SSD', 6, 2),
(23, 'Acer Swift 3', 799.00, 'Intel i5, 8GB RAM, 512GB SSD', 7, 2),
(24, 'Huawei MateBook X Pro', 1599.00, 'Intel i7, 16GB RAM, 1TB SSD', 13, 2),
(25, 'Galaxy Watch 5', 299.00, 'Health tracking, 44mm, GPS', 2, 9),
(26, 'Google Pixel Watch', 349.00, 'Wear OS, Fitbit integration', 15, 9),
(27, 'Xiaomi Mi Smart Band 7', 59.99, 'Fitness tracker with AMOLED display', 9, 9),
(28, 'HyperX Alloy FPS Pro', 89.99, 'Tenkeyless mechanical keyboard, red switches', 12, 6),
(29, 'Logitech G Pro X', 129.99, 'Gaming headset with Blue VO!CE mic', 7, 10),
(30, 'Sony Alpha a6400', 999.99, '24.2MP mirrorless camera, 4K video', 10, 14),
(31, 'Nintendo Switch OLED', 349.99, 'Handheld console, 7-inch OLED', 10, 15),
(32, 'Xbox Series X', 499.99, NULL, 8, 15),
(33, 'Seagate Portable HDD 2TB', 59.99, 'USB 3.0, Compatible with PC and Mac', 14, 12),
(34, 'Dell UltraSharp U2723QE', 649.99, '27-inch 4K IPS, USB-C hub', 4, 5),
(35, 'HP LaserJet Pro M404dn', 249.99, 'Monochrome laser printer, network ready', 5, 8),
(36, 'Acer Predator XB273U', 449.99, '27" WQHD, 170Hz, G-Sync', 7, 5),
(37, 'Asus RT-AX88U', 299.99, 'WiFi 6 router, 6000Mbps, 8 LAN ports', 6, 13),
(38, 'Razer Basilisk V3', 69.99, 'Customizable ergonomic gaming mouse', 12, 7),
(39, 'Google Pixel 7 Pro', 899.99, '128GB, Tensor G2, Triple Camera', 15, 1),
(40, 'LG Gram 17', 1699.99, 'Intel i7, 16GB RAM, 1TB SSD, 17" WQXGA', 11, 2),
(41, 'HP Spectre x360', 1599.99, 'Intel i7, 16GB RAM, 1TB SSD, Touchscreen', 5, 2),
(42, 'Lenovo Yoga Slim 7', 1199.99, 'Ryzen 7, 16GB RAM, 512GB SSD', 3, 2),
(43, 'iMac 24"', 1799.99, 'M1, 8GB RAM, 512GB SSD', 1, 4),
(44, 'Surface Studio 2+', 4299.00, 'Intel i7, 32GB RAM, 1TB SSD', 8, 4),
(45, 'Samsung M8 Smart Monitor', 699.00, '32", UHD, Smart TV functions', 2, 5),
(46, 'LG 34WN80C-B', 649.99, '34" UltraWide QHD IPS Curved Monitor', 11, 5),
(47, 'Razer BlackWidow V4 Pro', 229.99, 'Mechanical RGB Gaming Keyboard', 12, 6),
(48, 'Asus ROG Spatha X', 149.99, 'Wireless gaming mouse, 19,000 DPI', 6, 7),
(49, 'Canon imageCLASS LBP6030w', 129.99, 'Wireless laser printer, compact', 10, 8),
(50, 'Fitbit Versa 4', 229.95, 'Health & fitness smartwatch', 9, 9),
(51, 'Beats Studio Pro', 349.99, 'Wireless Noise Cancelling Headphones', 1, 10),
(52, 'Sony SRS-XB43', 199.99, 'Portable Bluetooth speaker with extra bass', 10, 11),
(53, 'SanDisk Extreme Portable SSD 2TB', 179.99, 'USB-C, NVMe, rugged design', 14, 12),
(54, 'Netgear Nighthawk AX12', 399.99, '12-Stream WiFi 6 Router', 2, 13),
(55, 'Fujifilm X-T30 II', 899.99, 'Mirrorless camera, 26.1MP, 4K video', 10, 14),
(56, 'Valve Steam Deck', 399.00, 'Handheld PC Gaming Console, 64GB eMMC', 15, 15),
(57, 'Asus TUF Gaming F15', 1099.00, 'Intel i7, RTX 3050, 16GB RAM', 6, 2),
(58, 'Xiaomi Redmi Note 12 Pro', 329.99, '128GB, 5G, 108MP Camera', 9, 1),
(59, 'Huawei MatePad 11', 479.99, 'Snapdragon 865, 120Hz display', 13, 3),
(60, 'Dell Inspiron 15', 649.99, 'Intel i5, 8GB RAM, 512GB SSD', 4, 2);
SET IDENTITY_INSERT Products OFF;

SET IDENTITY_INSERT Stores ON;
INSERT INTO Stores (Id, Name, IsOnline) VALUES
(1, 'Tech World', 0),
(2, 'Digital Galaxy', 1),
(3, 'ElectroMart', 0),
(4, 'ByteBazaar', 1),
(5, 'GigaTech Hub', 0),
(6, 'NovaTech Online', 1),
(7, 'Circuit City', 0),
(8, 'The Gadget Shop', 0),
(9, 'TechExpress', 1),
(10, 'MegaDevices', 0),
(11, 'SmartTech Pro', 1),
(12, 'ClickNBuy Electronics', 1),
(13, 'Apple PowerCore', 0),
(14, 'Samsung ElectroZone', 1),
(15, 'NextGen Lenovo', 0),
(16, 'OnlineTech Dell-Depot', 1),
(17, 'HP Retail', 0),
(18, 'Asus District', 0),
(19, 'Xiaomi Central', 1),
(20, 'Sony Gear', 1);
SET IDENTITY_INSERT Stores OFF;

INSERT INTO StoresProducts (StoreId, ProductId) VALUES
-- Store 1 (smartphones, tablets, smartwatches)
(1, 1), (1, 2), (1, 39), (1,58), (1, 6), (1, 7), (1, 59), (1, 14), (1, 25), (1, 26), (1, 27), (1, 50),
-- Store 2 (laptops)
(2, 3), (2, 4), (2, 5), (2,21), (2, 22), (2, 23), (2, 24), (2, 40), (2,41), (2, 42), (2, 57), (2, 60),
-- Store 3 (tablets, desktops, keyboards, mice)
(3, 6), (3, 7), (3, 59), (3, 8), (3, 43), (3, 44), (3, 11), (3, 28), (3, 47), (3, 12), (3, 38), (3, 48),
-- Store 4 (desktops, monitors, keyboards)
(4, 8), (4, 43), (4, 44), (4, 9), (4, 10), (4, 34), (4, 36), (4, 45), (4, 46), (4, 11), (4, 28), (4, 47),
-- Store 5 (monitors)
(5, 9), (5, 10), (5, 34), (5, 36), (5, 45), (5, 46),
-- Store 6 (keyboards, mice)
(6, 11), (6, 28), (6, 47), (6, 12), (6, 38), (6, 48),
-- Store 7 (mice, networking equipment)
(7, 12), (7, 38), (7, 48), (7, 18), (7, 37), (7, 54),
-- Store 8 (smartwatches, smartphones)
(8, 14), (8, 25), (8, 26), (8, 27), (8, 50), (8, 1), (8, 2), (8, 39), (8, 58),
-- Store 9 (gaming consoles)
(9, 20), (9, 31), (9, 32), (9, 56),
-- Store 10 (cameras, storage devices)
(10, 19), (10, 30), (10, 55), (10, 17), (10, 33), (10, 53),
-- Store 11 (networking equipment, headphones, speakers)
(11, 18), (11, 37), (11, 54), (11, 15), (11, 29), (11, 51), (11, 16), (11, 52),
-- Store 12 (gaming consoles, speakers, headphones)
(12, 20), (12, 31), (12, 32), (12, 56), (12, 16), (12, 52), (12, 15), (12, 29), (12, 51),
-- Store 13 (Apple)
(13, 1), (13, 3), (13, 14), (13, 43), (13, 51),
-- Store 14 (Samsung)
(14, 2), (14, 7), (14, 25), (14, 17), (14, 18), (14, 45), (14, 54),
-- Store 15 (Lenovo)
(15, 5), (15, 42),
-- Store 16 (Dell)
(16, 4), (16, 34), (16, 60),
-- Store 17 (HP)
(17, 8), (17, 35), (17, 41),
-- Store 18 (Asus)
(18, 22), (18, 37), (18, 48), (18, 57),
-- Store 19 (Xiaomi)
(19, 27), (19, 58), (19, 50),
-- Store 20 (Sony)
(20, 15), (20, 30), (20, 52), (20, 19), (20, 49), (20, 13), (20, 55), (20, 31), (20, 20);

SET IDENTITY_INSERT Customers ON;
INSERT INTO Customers (Id, Name, PhoneNumber, Email) VALUES
(1, 'Luca Bianchi', '089-1234567', 'l.bianchi@email.it'),
(2, 'Emma Müller', '030-9876543', 'emma.mueller@email.de'),
(3, 'Mateusz Kowalski', '22-2345678', 'mateusz.k@email.pl'),
(4, 'Sofia Rossi', '06-5432109', NULL),
(5, 'Javier Gómez', '91-4567890', 'j.gomez@email.es'),
(6, 'Elena Popa', '021-3322110', NULL),
(7, 'Nikos Papadopoulos', '210-5566778', 'nikos.pap@email.gr'),
(8, 'Anna Nowak', '42-7890123', 'a.nowak@email.pl'),
(9, 'Georgi Dimitrov', '02-1010101', NULL),
(10, 'Marie Dubois', '01-2233445', 'm.dubois@email.fr'),
(11, 'Andrei Ionescu', '031-4455667', 'andrei.io@email.ro'),
(12, 'Katarzyna Zielinska', '58-9988776', 'k.zielinska@email.pl'),
(13, 'Carlos Fernández', '93-3344556', NULL),
(14, 'Thomas Meier', '040-5566778', 'th.meier@email.de'),
(15, 'Ivana Petrova', '02-6677889', 'ivana.p@email.bg'),
(16, 'Hugo Lefevre', '04-1234987', NULL),
(17, 'Stefan Horváth', '06-9876123', 's.horvath@email.hu'),
(18, 'Lena Schmidt', '089-3344556', 'lena.schmidt@email.de'),
(19, 'Isabelle Laurent', '05-1122334', NULL),
(20, 'Daan van Dijk', '020-1234567', 'daan.vd@email.nl');
SET IDENTITY_INSERT Customers OFF;

SET IDENTITY_INSERT Orders ON;
INSERT INTO Orders (Id, OrderDate, CustomerId, ProductId, StoreId) VALUES
(1, '2024-11-05', 1, 24, 3),
(2, '2024-12-22', 1, 20, 9),
(3, '2025-01-12', 2, 15, 12),
(4, '2025-02-03', 2, 35, 17),
(5, '2025-02-15', 3, 20, 9),
(6, '2025-02-28', 4, 32, 9),
(7, '2025-03-01', 4, 4, 16),
(8, '2025-03-05', 4, 20, 12),
(9, '2025-03-08', 9, 56, 9),
(10, '2025-03-10', 9, 46, 4),
(11, '2025-03-12', 9, 18, 7),
(12, '2025-03-13', 12, 15, 20),
(13, '2025-03-15', 12, 49, 20),
(14, '2025-03-16', 14, 18, 11),
(15, '2025-03-17', 15, 8, 4),
(16, '2025-03-18', 15, 36, 4),
(17, '2025-03-19', 15, 47, 4),
(18, '2025-03-20', 18, 57, 18),
(19, '2025-03-21', 19, 15, 20),
(20, '2025-03-22', 20, 8, 17),
(21, '2025-03-23', 20, 11, 3),
(22, '2025-03-24', 20, 45, 14),
(23, '2025-03-25', 2, 46, 5),
(24, '2025-03-25', 4, 53, 10),
(25, '2025-03-26', 4, 35, 17),
(26, '2025-03-26', 6, 14, 1),
(27, '2025-03-27', 7, 55, 20),
(28, '2025-03-28', 7, 22, 18),
(29, '2025-03-28', 1, 37, 11),
(30, '2025-03-29', 1, 21, 2),
(31, '2025-03-29', 1, 28, 3),
(32, '2025-03-30', 2, 10, 5),
(33, '2025-03-30', 3, 12, 7),
(34, '2025-03-30', 5, 4, 16),
(35, '2025-03-31', 5, 58, 8),
(36, '2025-03-31', 11, 20, 9),
(37, '2025-04-01', 11, 16, 12),
(38, '2025-04-01', 13, 1, 1),
(39, '2025-04-01', 13, 2, 14),
(40, '2025-04-02', 13, 11, 6),
(41, '2025-04-02', 14, 19, 10),
(42, '2025-04-03', 12, 8, 17),
(43, '2025-04-03', 13, 27, 19),
(44, '2025-04-04', 14, 15, 20),
(45, '2025-04-04', 5, 8, 4),
(46, '2025-04-04', 9, 1, 13),
(47, '2025-04-05', 15, 11, 6),
(48, '2025-04-05', 14, 50, 8),
(49, '2025-04-05', 14, 22, 2),
(50, '2025-04-06', 3, 33, 10),
(51, '2025-04-06', 13, 52, 11),
(52, '2025-04-07', 12, 37, 18),
(53, '2025-04-07', 13, 31, 9),
(54, '2025-04-07', 14, 36, 5),
(55, '2025-04-08', 19, 18, 7),
(56, '2025-04-08', 19, 42, 15),
(57, '2025-04-08', 19, 1, 1),
(58, '2025-04-09', 20, 13, 20),
(59, '2025-04-09', 19, 10, 4),
(60, '2025-04-10', 20, 59, 3);
SET IDENTITY_INSERT Orders OFF;
