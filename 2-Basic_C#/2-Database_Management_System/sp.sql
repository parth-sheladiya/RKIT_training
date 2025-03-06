CREATE DATABASE cursorDemo;
USE cursorDemo;
DROP DATABASE cursorDemo;
CREATE TABLE products (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100),
    price DECIMAL(10,2)
)AUTO_INCREMENT=500;

INSERT INTO products (id ,name, price) VALUES
(null,'Laptop', 50000.00),
(null,'Mobile', 20000.00),
(null,'Tablet', 15000.00),
(null,null, 3000.00),
(null,'Smartwatch', 5000.00);

-- imp if null 
SELECT id,price,IFNULL(name, "parth") FROM products;

-- do not need end bcz only one sql query
DELIMITER $$
CREATE PROCEDURE GetAllProducts()
SELECT * FROM products;  
$$ DELIMITER ;
CALL GetAllProducts;
DROP PROCEDURE GetAllProducts;





DELIMITER $$
CREATE PROCEDURE GetAllProductData()
BEGIN 
 --  overwrite issue 
SELECT * FROM products WHERE price = 3060;
SELECT * FROM products;  
SELECT * FROM products WHERE price =15750;
END $$
 $$ DELIMITER ;
-- is fast motion to show table
CALL  GetAllProductData();

DROP PROCEDURE GetAllProductData;


DELIMITER $$
CREATE PROCEDURE UpdateProductPrices()
BEGIN 
-- declare var
    DECLARE done INT DEFAULT false;
    DECLARE p_id INT;
    DECLARE p_name VARCHAR(100);
    DECLARE p_price DECIMAL(10,2);
    DECLARE new_price DECIMAL(10,2);    
    -- Cursor declare karo
    DECLARE UpdateProductPrices CURSOR FOR SELECT id, name, price FROM products;
    
     -- row not found then set flat 1
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
    
    -- Cursor open 
    OPEN UpdateProductPrices;
    
     -- itrate loop
    read_loop: LOOP
    
    FETCH UpdateProductPrices INTO p_id, p_name, p_price;

        IF done = 1 THEN LEAVE read_loop;
        END IF;
        
       
        IF p_price > 40000 THEN
            SET new_price = p_price * 1.10; 
        ELSEIF p_price BETWEEN 10000 AND 40000 THEN
            SET new_price = p_price * 1.05;
        ELSE
            SET new_price = p_price * 1.02;
        END IF;
        
       -- price update
        UPDATE products SET price = new_price WHERE id = p_id;
		END LOOP;
        
         -- close cursor
    CLOSE UpdateProductPrices;
	END $$

	DELIMITER ;
        
CALL UpdateProductPrices();

select * from products;
-- drop cursor
DROP PROCEDURE UpdateProductPrices;
        