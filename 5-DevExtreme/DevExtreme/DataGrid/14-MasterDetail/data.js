var productData = [
    { ID: 1, Name: "Product 1", Category: "Electronics", ProductDetails: [
        { Rating: 4.5, Price: 500, Date: "2023-01-01", StockQuantity: 100, Discount: 10, Company: "Company A" },
        { Rating: 4.2, Price: 550, Date: "2023-02-01", StockQuantity: 90, Discount: 12, Company: "Company B" },
        { Rating: 4.7, Price: 600, Date: "2023-03-01", StockQuantity: 80, Discount: 15, Company: "Company C" },
        { Rating: 3.9, Price: 450, Date: "2023-04-01", StockQuantity: 110, Discount: 10, Company: "Company D" },
        { Rating: 4.0, Price: 500, Date: "2023-05-01", StockQuantity: 120, Discount: 18, Company: "Company A" }
    ]},
    { ID: 2, Name: "Product 2", Category: "Furniture", ProductDetails: [
        { Rating: 4.0, Price: 1200, Date: "2023-02-15", StockQuantity: 50, Discount: 15, Company: "Company B" },
        { Rating: 3.8, Price: 1300, Date: "2023-03-01", StockQuantity: 45, Discount: 10, Company: "Company C" },
        { Rating: 4.2, Price: 1400, Date: "2023-04-01", StockQuantity: 30, Discount: 18, Company: "Company A" },
        { Rating: 4.5, Price: 1500, Date: "2023-05-01", StockQuantity: 20, Discount: 12, Company: "Company D" },
        { Rating: 4.3, Price: 1450, Date: "2023-06-01", StockQuantity: 35, Discount: 10, Company: "Company B" }
    ]},
    { ID: 3, Name: "Product 3", Category: "Electronics", ProductDetails: [
        { Rating: 3.8, Price: 200, Date: "2023-03-10", StockQuantity: 150, Discount: 5, Company: "Company C" },
        { Rating: 3.9, Price: 220, Date: "2023-04-01", StockQuantity: 140, Discount: 7, Company: "Company D" },
        { Rating: 4.0, Price: 250, Date: "2023-05-01", StockQuantity: 130, Discount: 8, Company: "Company A" },
        { Rating: 4.1, Price: 270, Date: "2023-06-01", StockQuantity: 120, Discount: 10, Company: "Company B" },
        { Rating: 4.2, Price: 300, Date: "2023-07-01", StockQuantity: 110, Discount: 12, Company: "Company C" }
    ]},
    { ID: 4, Name: "Product 4", Category: "Furniture", ProductDetails: [
        { Rating: 4.2, Price: 800, Date: "2023-01-25", StockQuantity: 30, Discount: 8, Company: "Company D" },
        { Rating: 4.3, Price: 850, Date: "2023-02-15", StockQuantity: 25, Discount: 10, Company: "Company A" },
        { Rating: 4.0, Price: 900, Date: "2023-03-10", StockQuantity: 40, Discount: 12, Company: "Company B" },
        { Rating: 4.4, Price: 950, Date: "2023-04-05", StockQuantity: 50, Discount: 8, Company: "Company C" },
        { Rating: 4.1, Price: 800, Date: "2023-05-01", StockQuantity: 45, Discount: 10, Company: "Company D" }
    ]},
    { ID: 5, Name: "Product 5", Category: "Clothing", ProductDetails: [
        { Rating: 4.7, Price: 50, Date: "2023-04-05", StockQuantity: 200, Discount: 20, Company: "Company A" },
        { Rating: 4.6, Price: 60, Date: "2023-05-01", StockQuantity: 190, Discount: 15, Company: "Company B" },
        { Rating: 4.5, Price: 55, Date: "2023-06-01", StockQuantity: 180, Discount: 18, Company: "Company C" },
        { Rating: 4.8, Price: 65, Date: "2023-07-01", StockQuantity: 170, Discount: 20, Company: "Company D" },
        { Rating: 4.4, Price: 50, Date: "2023-08-01", StockQuantity: 160, Discount: 10, Company: "Company A" }
    ]},
    { ID: 6, Name: "Product 6", Category: "Electronics", ProductDetails: [
        { Rating: 3.9, Price: 350, Date: "2023-03-15", StockQuantity: 120, Discount: 12, Company: "Company B" },
        { Rating: 4.0, Price: 400, Date: "2023-04-01", StockQuantity: 110, Discount: 10, Company: "Company C" },
        { Rating: 3.8, Price: 380, Date: "2023-05-01", StockQuantity: 100, Discount: 8, Company: "Company D" },
        { Rating: 4.2, Price: 450, Date: "2023-06-01", StockQuantity: 90, Discount: 12, Company: "Company A" },
        { Rating: 4.1, Price: 500, Date: "2023-07-01", StockQuantity: 80, Discount: 15, Company: "Company B" }
    ]},
    { ID: 7, Name: "Product 7", Category: "Clothing", ProductDetails: [
        { Rating: 4.6, Price: 70, Date: "2023-02-25", StockQuantity: 80, Discount: 10, Company: "Company C" },
        { Rating: 4.4, Price: 75, Date: "2023-03-15", StockQuantity: 90, Discount: 12, Company: "Company D" },
        { Rating: 4.3, Price: 60, Date: "2023-04-05", StockQuantity: 100, Discount: 15, Company: "Company A" },
        { Rating: 4.5, Price: 80, Date: "2023-05-01", StockQuantity: 110, Discount: 10, Company: "Company B" },
        { Rating: 4.7, Price: 85, Date: "2023-06-01", StockQuantity: 120, Discount: 18, Company: "Company C" }
    ]},
    { ID: 8, Name: "Product 8", Category: "Furniture", ProductDetails: [
        { Rating: 4.8, Price: 1500, Date: "2023-05-01", StockQuantity: 10, Discount: 5, Company: "Company D" },
        { Rating: 4.6, Price: 1600, Date: "2023-06-01", StockQuantity: 15, Discount: 8, Company: "Company A" },
        { Rating: 4.7, Price: 1550, Date: "2023-07-01", StockQuantity: 12, Discount: 10, Company: "Company B" },
        { Rating: 4.9, Price: 1700, Date: "2023-08-01", StockQuantity: 8, Discount: 7, Company: "Company C" },
        { Rating: 4.5, Price: 1500, Date: "2023-09-01", StockQuantity: 10, Discount: 5, Company: "Company D" }
    ]},
    { ID: 9, Name: "Product 9", Category: "Electronics", ProductDetails: [
        { Rating: 4.1, Price: 700, Date: "2023-01-30", StockQuantity: 90, Discount: 10, Company: "Company A" },
        { Rating: 3.8, Price: 650, Date: "2023-02-20", StockQuantity: 80, Discount: 12, Company: "Company B" },
        { Rating: 4.2, Price: 720, Date: "2023-03-10", StockQuantity: 85, Discount: 15, Company: "Company C" },
        { Rating: 4.0, Price: 680, Date: "2023-04-01", StockQuantity: 70, Discount: 10, Company: "Company D" },
        { Rating: 4.5, Price: 750, Date: "2023-05-01", StockQuantity: 75, Discount: 12, Company: "Company A" }
    ]},
    { ID: 10, Name: "Product 10", Category: "Electronics", ProductDetails: [
        { Rating: 3.5, Price: 450, Date: "2023-04-10", StockQuantity: 200, Discount: 20, Company: "Company B" },
        { Rating: 4.0, Price: 500, Date: "2023-05-01", StockQuantity: 180, Discount: 18, Company: "Company C" },
        { Rating: 3.8, Price: 480, Date: "2023-06-01", StockQuantity: 190, Discount: 15, Company: "Company D" },
        { Rating: 4.2, Price: 520, Date: "2023-07-01", StockQuantity: 160, Discount: 12, Company: "Company A" },
        { Rating: 4.1, Price: 550, Date: "2023-08-01", StockQuantity: 170, Discount: 10, Company: "Company B" }
    ]},
    { ID: 11, Name: "Product 11", Category: "Furniture", ProductDetails: [
        { Rating: 4.0, Price: 1200, Date: "2023-02-01", StockQuantity: 50, Discount: 15, Company: "Company C" },
        { Rating: 4.5, Price: 1300, Date: "2023-03-01", StockQuantity: 45, Discount: 12, Company: "Company D" },
        { Rating: 4.2, Price: 1400, Date: "2023-04-01", StockQuantity: 60, Discount: 10, Company: "Company A" },
        { Rating: 4.6, Price: 1500, Date: "2023-05-01", StockQuantity: 40, Discount: 15, Company: "Company B" },
        { Rating: 4.4, Price: 1450, Date: "2023-06-01", StockQuantity: 50, Discount: 18, Company: "Company C" }
    ]},
    { ID: 12, Name: "Product 12", Category: "Electronics", ProductDetails: [
        { Rating: 4.3, Price: 500, Date: "2023-01-15", StockQuantity: 100, Discount: 10, Company: "Company A" },
        { Rating: 4.5, Price: 550, Date: "2023-02-10", StockQuantity: 90, Discount: 12, Company: "Company B" },
        { Rating: 4.0, Price: 600, Date: "2023-03-01", StockQuantity: 80, Discount: 15, Company: "Company C" },
        { Rating: 4.2, Price: 450, Date: "2023-04-01", StockQuantity: 70, Discount: 10, Company: "Company D" },
        { Rating: 4.7, Price: 650, Date: "2023-05-01", StockQuantity: 85, Discount: 18, Company: "Company A" }
    ]},
    { ID: 13, Name: "Product 13", Category: "Clothing", ProductDetails: [
        { Rating: 4.1, Price: 60, Date: "2023-02-01", StockQuantity: 200, Discount: 12, Company: "Company B" },
        { Rating: 4.4, Price: 70, Date: "2023-03-01", StockQuantity: 190, Discount: 10, Company: "Company C" },
        { Rating: 4.2, Price: 65, Date: "2023-04-01", StockQuantity: 180, Discount: 8, Company: "Company A" },
        { Rating: 4.3, Price: 75, Date: "2023-05-01", StockQuantity: 170, Discount: 12, Company: "Company D" },
        { Rating: 4.5, Price: 80, Date: "2023-06-01", StockQuantity: 160, Discount: 18, Company: "Company B" }
    ]},
    { ID: 14, Name: "Product 14", Category: "Furniture", ProductDetails: [
        { Rating: 4.5, Price: 1300, Date: "2023-03-01", StockQuantity: 30, Discount: 15, Company: "Company A" },
        { Rating: 4.3, Price: 1400, Date: "2023-04-01", StockQuantity: 25, Discount: 12, Company: "Company C" },
        { Rating: 4.6, Price: 1500, Date: "2023-05-01", StockQuantity: 20, Discount: 18, Company: "Company D" },
        { Rating: 4.2, Price: 1200, Date: "2023-06-01", StockQuantity: 35, Discount: 10, Company: "Company B" },
        { Rating: 4.4, Price: 1250, Date: "2023-07-01", StockQuantity: 40, Discount: 12, Company: "Company A" }
    ]},
    { ID: 15, Name: "Product 15", Category: "Electronics", ProductDetails: [
        { Rating: 4.0, Price: 700, Date: "2023-01-25", StockQuantity: 150, Discount: 10, Company: "Company C" },
        { Rating: 4.1, Price: 750, Date: "2023-02-15", StockQuantity: 140, Discount: 12, Company: "Company A" },
        { Rating: 4.3, Price: 800, Date: "2023-03-05", StockQuantity: 130, Discount: 15, Company: "Company D" },
        { Rating: 4.2, Price: 780, Date: "2023-04-01", StockQuantity: 120, Discount: 10, Company: "Company B" },
        { Rating: 4.5, Price: 820, Date: "2023-05-01", StockQuantity: 110, Discount: 18, Company: "Company C" }
    ]},
    { ID: 16, Name: "Product 16", Category: "Clothing", ProductDetails: [
        { Rating: 4.5, Price: 90, Date: "2023-04-10", StockQuantity: 150, Discount: 15, Company: "Company A" },
        { Rating: 4.6, Price: 95, Date: "2023-05-01", StockQuantity: 140, Discount: 10, Company: "Company B" },
        { Rating: 4.7, Price: 100, Date: "2023-06-01", StockQuantity: 130, Discount: 20, Company: "Company C" },
        { Rating: 4.3, Price: 85, Date: "2023-07-01", StockQuantity: 120, Discount: 12, Company: "Company D" },
        { Rating: 4.4, Price: 90, Date: "2023-08-01", StockQuantity: 110, Discount: 10, Company: "Company A" }
    ]},
    { ID: 17, Name: "Product 17", Category: "Furniture", ProductDetails: [
        { Rating: 4.1, Price: 950, Date: "2023-01-15", StockQuantity: 100, Discount: 8, Company: "Company D" },
        { Rating: 4.2, Price: 1000, Date: "2023-02-05", StockQuantity: 95, Discount: 10, Company: "Company A" },
        { Rating: 4.3, Price: 1050, Date: "2023-03-01", StockQuantity: 90, Discount: 12, Company: "Company B" },
        { Rating: 4.4, Price: 1100, Date: "2023-04-01", StockQuantity: 85, Discount: 15, Company: "Company C" },
        { Rating: 4.5, Price: 1150, Date: "2023-05-01", StockQuantity: 80, Discount: 10, Company: "Company D" }
    ]},
    { ID: 18, Name: "Product 18", Category: "Electronics", ProductDetails: [
        { Rating: 4.2, Price: 350, Date: "2023-02-10", StockQuantity: 60, Discount: 5, Company: "Company A" },
        { Rating: 4.4, Price: 400, Date: "2023-03-01", StockQuantity: 50, Discount: 7, Company: "Company C" },
        { Rating: 4.1, Price: 420, Date: "2023-04-01", StockQuantity: 45, Discount: 10, Company: "Company B" },
        { Rating: 4.3, Price: 480, Date: "2023-05-01", StockQuantity: 40, Discount: 12, Company: "Company D" },
        { Rating: 4.5, Price: 500, Date: "2023-06-01", StockQuantity: 30, Discount: 15, Company: "Company A" }
    ]},
    { ID: 19, Name: "Product 19", Category: "Furniture", ProductDetails: [
        { Rating: 4.0, Price: 2000, Date: "2023-03-01", StockQuantity: 15, Discount: 12, Company: "Company B" },
        { Rating: 4.2, Price: 2100, Date: "2023-04-01", StockQuantity: 12, Discount: 15, Company: "Company C" },
        { Rating: 4.5, Price: 2200, Date: "2023-05-01", StockQuantity: 10, Discount: 18, Company: "Company A" },
        { Rating: 4.3, Price: 2300, Date: "2023-06-01", StockQuantity: 8, Discount: 10, Company: "Company D" },
        { Rating: 4.4, Price: 2400, Date: "2023-07-01", StockQuantity: 7, Discount: 12, Company: "Company B" }
    ]},
    { ID: 20, Name: "Product 20", Category: "Electronics", ProductDetails: [
        { Rating: 3.9, Price: 800, Date: "2023-01-15", StockQuantity: 90, Discount: 10, Company: "Company D" },
        { Rating: 4.0, Price: 850, Date: "2023-02-01", StockQuantity: 85, Discount: 12, Company: "Company C" },
        { Rating: 4.1, Price: 900, Date: "2023-03-01", StockQuantity: 80, Discount: 15, Company: "Company A" },
        { Rating: 4.3, Price: 950, Date: "2023-04-01", StockQuantity: 70, Discount: 10, Company: "Company B" },
        { Rating: 4.5, Price: 1000, Date: "2023-05-01", StockQuantity: 60, Discount: 18, Company: "Company D" }
    ]},
    { ID: 21, Name: "Product 21", Category: "Clothing", ProductDetails: [
        { Rating: 4.3, Price: 120, Date: "2023-06-01", StockQuantity: 100, Discount: 15, Company: "Company C" },
        { Rating: 4.4, Price: 130, Date: "2023-07-01", StockQuantity: 95, Discount: 12, Company: "Company A" },
        { Rating: 4.2, Price: 140, Date: "2023-08-01", StockQuantity: 90, Discount: 10, Company: "Company B" },
        { Rating: 4.5, Price: 150, Date: "2023-09-01", StockQuantity: 85, Discount: 18, Company: "Company D" },
        { Rating: 4.6, Price: 160, Date: "2023-10-01", StockQuantity: 80, Discount: 15, Company: "Company C" }
    ]},
    { ID: 22, Name: "Product 22", Category: "Electronics", ProductDetails: [
        { Rating: 4.2, Price: 450, Date: "2023-02-25", StockQuantity: 110, Discount: 10, Company: "Company D" },
        { Rating: 4.3, Price: 470, Date: "2023-03-15", StockQuantity: 100, Discount: 12, Company: "Company B" },
        { Rating: 4.0, Price: 490, Date: "2023-04-01", StockQuantity: 90, Discount: 15, Company: "Company C" },
        { Rating: 4.5, Price: 510, Date: "2023-05-01", StockQuantity: 80, Discount: 18, Company: "Company A" },
        { Rating: 4.4, Price: 530, Date: "2023-06-01", StockQuantity: 70, Discount: 12, Company: "Company D" }
    ]},
    { ID: 23, Name: "Product 23", Category: "Furniture", ProductDetails: [
        { Rating: 4.1, Price: 1200, Date: "2023-01-10", StockQuantity: 25, Discount: 15, Company: "Company B" },
        { Rating: 4.4, Price: 1250, Date: "2023-02-20", StockQuantity: 30, Discount: 18, Company: "Company A" },
        { Rating: 4.5, Price: 1300, Date: "2023-03-10", StockQuantity: 35, Discount: 20, Company: "Company D" },
        { Rating: 4.2, Price: 1350, Date: "2023-04-15", StockQuantity: 40, Discount: 12, Company: "Company C" },
        { Rating: 4.3, Price: 1400, Date: "2023-05-01", StockQuantity: 45, Discount: 10, Company: "Company B" }
    ]},
    { ID: 24, Name: "Product 24", Category: "Clothing", ProductDetails: [
        { Rating: 4.3, Price: 85, Date: "2023-01-05", StockQuantity: 150, Discount: 10, Company: "Company A" },
        { Rating: 4.0, Price: 90, Date: "2023-02-10", StockQuantity: 140, Discount: 12, Company: "Company B" },
        { Rating: 4.4, Price: 95, Date: "2023-03-15", StockQuantity: 130, Discount: 15, Company: "Company D" },
        { Rating: 4.2, Price: 100, Date: "2023-04-01", StockQuantity: 120, Discount: 10, Company: "Company C" },
        { Rating: 4.5, Price: 110, Date: "2023-05-01", StockQuantity: 110, Discount: 18, Company: "Company A" }
    ]},
    { ID: 25, Name: "Product 25", Category: "Electronics", ProductDetails: [
        { Rating: 4.3, Price: 550, Date: "2023-01-18", StockQuantity: 60, Discount: 10, Company: "Company C" },
        { Rating: 4.5, Price: 600, Date: "2023-02-01", StockQuantity: 50, Discount: 12, Company: "Company A" },
        { Rating: 4.2, Price: 650, Date: "2023-03-01", StockQuantity: 40, Discount: 15, Company: "Company D" },
        { Rating: 4.4, Price: 700, Date: "2023-04-01", StockQuantity: 30, Discount: 18, Company: "Company B" },
        { Rating: 4.1, Price: 750, Date: "2023-05-01", StockQuantity: 20, Discount: 10, Company: "Company C" }
    ]},
    { ID: 26, Name: "Product 26", Category: "Furniture", ProductDetails: [
        { Rating: 4.2, Price: 700, Date: "2023-02-15", StockQuantity: 40, Discount: 10, Company: "Company D" },
        { Rating: 4.5, Price: 750, Date: "2023-03-01", StockQuantity: 35, Discount: 12, Company: "Company A" },
        { Rating: 4.3, Price: 800, Date: "2023-04-05", StockQuantity: 30, Discount: 15, Company: "Company B" },
        { Rating: 4.0, Price: 850, Date: "2023-05-01", StockQuantity: 25, Discount: 10, Company: "Company D" },
        { Rating: 4.4, Price: 900, Date: "2023-06-01", StockQuantity: 20, Discount: 18, Company: "Company A" }
    ]},
    { ID: 27, Name: "Product 27", Category: "Clothing", ProductDetails: [
        { Rating: 4.3, Price: 65, Date: "2023-03-10", StockQuantity: 180, Discount: 12, Company: "Company A" },
        { Rating: 4.0, Price: 70, Date: "2023-04-01", StockQuantity: 170, Discount: 15, Company: "Company B" },
        { Rating: 4.4, Price: 75, Date: "2023-05-01", StockQuantity: 160, Discount: 10, Company: "Company D" },
        { Rating: 4.5, Price: 80, Date: "2023-06-01", StockQuantity: 150, Discount: 18, Company: "Company C" },
        { Rating: 4.2, Price: 85, Date: "2023-07-01", StockQuantity: 140, Discount: 12, Company: "Company A" }
    ]},
    { ID: 28, Name: "Product 28", Category: "Electronics", ProductDetails: [
        { Rating: 4.1, Price: 300, Date: "2023-01-05", StockQuantity: 150, Discount: 10, Company: "Company D" },
        { Rating: 4.0, Price: 350, Date: "2023-02-01", StockQuantity: 140, Discount: 12, Company: "Company A" },
        { Rating: 4.2, Price: 400, Date: "2023-03-01", StockQuantity: 130, Discount: 15, Company: "Company B" },
        { Rating: 4.4, Price: 450, Date: "2023-04-01", StockQuantity: 120, Discount: 18, Company: "Company C" },
        { Rating: 4.3, Price: 500, Date: "2023-05-01", StockQuantity: 110, Discount: 10, Company: "Company D" }
    ]},
    { ID: 29, Name: "Product 29", Category: "Furniture", ProductDetails: [
        { Rating: 4.3, Price: 1300, Date: "2023-02-20", StockQuantity: 30, Discount: 12, Company: "Company A" },
        { Rating: 4.5, Price: 1400, Date: "2023-03-05", StockQuantity: 25, Discount: 15, Company: "Company D" },
        { Rating: 4.4, Price: 1500, Date: "2023-04-15", StockQuantity: 20, Discount: 18, Company: "Company B" },
        { Rating: 4.1, Price: 1600, Date: "2023-05-01", StockQuantity: 15, Discount: 10, Company: "Company C" },
        { Rating: 4.2, Price: 1700, Date: "2023-06-01", StockQuantity: 10, Discount: 12, Company: "Company A" }
    ]},
    { ID: 30, Name: "Product 30", Category: "Clothing", ProductDetails: [
        { Rating: 4.0, Price: 120, Date: "2023-01-10", StockQuantity: 200, Discount: 15, Company: "Company B" },
        { Rating: 4.1, Price: 130, Date: "2023-02-01", StockQuantity: 190, Discount: 12, Company: "Company D" },
        { Rating: 4.3, Price: 140, Date: "2023-03-01", StockQuantity: 180, Discount: 10, Company: "Company A" },
        { Rating: 4.5, Price: 150, Date: "2023-04-01", StockQuantity: 170, Discount: 18, Company: "Company C" },
        { Rating: 4.2, Price: 160, Date: "2023-05-01", StockQuantity: 160, Discount: 12, Company: "Company B" }
    ]},
    { ID: 31, Name: "Product 31", Category: "Electronics", ProductDetails: [
        { Rating: 4.3, Price: 350, Date: "2023-01-18", StockQuantity: 100, Discount: 10, Company: "Company A" },
        { Rating: 4.5, Price: 400, Date: "2023-02-10", StockQuantity: 90, Discount: 12, Company: "Company D" },
        { Rating: 4.2, Price: 450, Date: "2023-03-01", StockQuantity: 80, Discount: 15, Company: "Company C" },
        { Rating: 4.4, Price: 500, Date: "2023-04-01", StockQuantity: 70, Discount: 18, Company: "Company B" },
        { Rating: 4.1, Price: 550, Date: "2023-05-01", StockQuantity: 60, Discount: 10, Company: "Company A" }
    ]},
    { ID: 32, Name: "Product 32", Category: "Furniture", ProductDetails: [
        { Rating: 4.2, Price: 800, Date: "2023-02-01", StockQuantity: 35, Discount: 15, Company: "Company B" },
        { Rating: 4.0, Price: 850, Date: "2023-03-01", StockQuantity: 30, Discount: 10, Company: "Company D" },
        { Rating: 4.3, Price: 900, Date: "2023-04-01", StockQuantity: 25, Discount: 12, Company: "Company A" },
        { Rating: 4.4, Price: 950, Date: "2023-05-01", StockQuantity: 20, Discount: 18, Company: "Company C" },
        { Rating: 4.1, Price: 1000, Date: "2023-06-01", StockQuantity: 15, Discount: 10, Company: "Company B" }
    ]},
    { ID: 33, Name: "Product 33", Category: "Clothing", ProductDetails: [
        { Rating: 4.2, Price: 55, Date: "2023-01-15", StockQuantity: 150, Discount: 10, Company: "Company D" },
        { Rating: 4.4, Price: 60, Date: "2023-02-01", StockQuantity: 140, Discount: 12, Company: "Company C" },
        { Rating: 4.1, Price: 65, Date: "2023-03-01", StockQuantity: 130, Discount: 15, Company: "Company A" },
        { Rating: 4.3, Price: 70, Date: "2023-04-01", StockQuantity: 120, Discount: 18, Company: "Company B" },
        { Rating: 4.5, Price: 75, Date: "2023-05-01", StockQuantity: 110, Discount: 12, Company: "Company D" }
    ]},
    { ID: 34, Name: "Product 34", Category: "Electronics", ProductDetails: [
        { Rating: 4.3, Price: 500, Date: "2023-01-20", StockQuantity: 100, Discount: 10, Company: "Company A" },
        { Rating: 4.2, Price: 550, Date: "2023-02-01", StockQuantity: 90, Discount: 12, Company: "Company B" },
        { Rating: 4.4, Price: 600, Date: "2023-03-01", StockQuantity: 80, Discount: 15, Company: "Company D" },
        { Rating: 4.1, Price: 650, Date: "2023-04-01", StockQuantity: 70, Discount: 10, Company: "Company C" },
        { Rating: 4.5, Price: 700, Date: "2023-05-01", StockQuantity: 60, Discount: 18, Company: "Company A" }
    ]},
    { ID: 35, Name: "Product 35", Category: "Furniture", ProductDetails: [
        { Rating: 4.3, Price: 1400, Date: "2023-03-01", StockQuantity: 25, Discount: 10, Company: "Company B" },
        { Rating: 4.4, Price: 1500, Date: "2023-04-01", StockQuantity: 20, Discount: 12, Company: "Company A" },
        { Rating: 4.5, Price: 1600, Date: "2023-05-01", StockQuantity: 15, Discount: 18, Company: "Company C" },
        { Rating: 4.0, Price: 1700, Date: "2023-06-01", StockQuantity: 10, Discount: 10, Company: "Company D" },
        { Rating: 4.2, Price: 1800, Date: "2023-07-01", StockQuantity: 5, Discount: 12, Company: "Company B" }
    ]},
    { ID: 36, Name: "Product 36", Category: "Clothing", ProductDetails: [
        { Rating: 4.4, Price: 50, Date: "2023-03-15", StockQuantity: 200, Discount: 10, Company: "Company D" },
        { Rating: 4.2, Price: 55, Date: "2023-04-01", StockQuantity: 190, Discount: 12, Company: "Company A" },
        { Rating: 4.1, Price: 60, Date: "2023-05-01", StockQuantity: 180, Discount: 15, Company: "Company C" },
        { Rating: 4.5, Price: 65, Date: "2023-06-01", StockQuantity: 170, Discount: 18, Company: "Company B" },
        { Rating: 4.3, Price: 70, Date: "2023-07-01", StockQuantity: 160, Discount: 12, Company: "Company D" }
    ]},
    { ID: 37, Name: "Product 37", Category: "Electronics", ProductDetails: [
        { Rating: 4.1, Price: 300, Date: "2023-02-25", StockQuantity: 150, Discount: 10, Company: "Company C" },
        { Rating: 4.2, Price: 350, Date: "2023-03-10", StockQuantity: 140, Discount: 12, Company: "Company A" },
        { Rating: 4.4, Price: 400, Date: "2023-04-05", StockQuantity: 130, Discount: 15, Company: "Company B" },
        { Rating: 4.5, Price: 450, Date: "2023-05-01", StockQuantity: 120, Discount: 18, Company: "Company D" },
        { Rating: 4.3, Price: 500, Date: "2023-06-01", StockQuantity: 110, Discount: 12, Company: "Company A" }
    ]},
    { ID: 38, Name: "Product 38", Category: "Furniture", ProductDetails: [
        { Rating: 4.4, Price: 950, Date: "2023-01-10", StockQuantity: 50, Discount: 10, Company: "Company A" },
        { Rating: 4.5, Price: 1000, Date: "2023-02-01", StockQuantity: 40, Discount: 12, Company: "Company D" },
        { Rating: 4.2, Price: 1050, Date: "2023-03-01", StockQuantity: 30, Discount: 15, Company: "Company B" },
        { Rating: 4.1, Price: 1100, Date: "2023-04-01", StockQuantity: 20, Discount: 10, Company: "Company C" },
        { Rating: 4.3, Price: 1150, Date: "2023-05-01", StockQuantity: 10, Discount: 12, Company: "Company A" }
    ]},
    { ID: 39, Name: "Product 39", Category: "Clothing", ProductDetails: [
        { Rating: 4.3, Price: 70, Date: "2023-02-01", StockQuantity: 200, Discount: 10, Company: "Company B" },
        { Rating: 4.2, Price: 75, Date: "2023-03-01", StockQuantity: 190, Discount: 12, Company: "Company D" },
        { Rating: 4.5, Price: 80, Date: "2023-04-01", StockQuantity: 180, Discount: 15, Company: "Company A" },
        { Rating: 4.4, Price: 85, Date: "2023-05-01", StockQuantity: 170, Discount: 18, Company: "Company C" },
        { Rating: 4.1, Price: 90, Date: "2023-06-01", StockQuantity: 160, Discount: 12, Company: "Company B" }
    ]},
    { ID: 40, Name: "Product 40", Category: "Electronics", ProductDetails: [
        { Rating: 4.3, Price: 450, Date: "2023-01-10", StockQuantity: 100, Discount: 10, Company: "Company C" },
        { Rating: 4.4, Price: 500, Date: "2023-02-01", StockQuantity: 90, Discount: 12, Company: "Company A" },
        { Rating: 4.2, Price: 550, Date: "2023-03-01", StockQuantity: 80, Discount: 15, Company: "Company B" },
        { Rating: 4.5, Price: 600, Date: "2023-04-01", StockQuantity: 70, Discount: 18, Company: "Company D" },
        { Rating: 4.1, Price: 650, Date: "2023-05-01", StockQuantity: 60, Discount: 10, Company: "Company C" }
    ]}
];
