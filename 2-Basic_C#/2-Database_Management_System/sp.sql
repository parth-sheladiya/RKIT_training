CREATE DATABASE CURSORDEMO;

CREATE TABLE products (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100),
    price DECIMAL(10,2)
);

INSERT INTO products (name, price) VALUES
('Laptop', 50000.00),
('Mobile', 20000.00),
('Tablet', 15000.00),
('Headphone', 3000.00),
('Smartwatch', 5000.00);

SELECT * FROM products;

-- do not need begin end bcz only one sql query
DELIMITER $$

CREATE PROCEDURE GetAllProducts()

SELECT * FROM products;  

$$ DELIMITER ;

DROP PROCEDURE GetAllProducts;

DELIMITER $$

CREATE PROCEDURE GetAllProductData()
BEGIN 
SELECT * FROM products;  
SELECT * FROM products WHERE price = 3060;
SELECT * FROM products WHERE price =15750;

END $$

 $$ DELIMITER ;
-- is fast motion to show table
CALL  GetAllProductData();

DROP PROCEDURE GetAllProductData;

DELIMITER $$

CREATE PROCEDURE UpdateProductPrices()

BEGIN 

-- Variables declare karo
    DECLARE done INT DEFAULT 0;
    DECLARE p_id INT;
    DECLARE p_name VARCHAR(100);
    DECLARE p_price DECIMAL(10,2);
    DECLARE new_price DECIMAL(10,2);
    
    -- Cursor declare karo
    DECLARE UpdateProductPrices CURSOR FOR SELECT id, name, price FROM products;
    
     -- Jab cursor me koi row na mile toh loop exit ho
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
    
    -- Cursor open karo
    OPEN UpdateProductPrices;
    
     -- Loop chalao har product ke liye
    read_loop: LOOP
    
    FETCH UpdateProductPrices INTO p_id, p_name, p_price;

        IF done = 1 THEN LEAVE read_loop;
        END IF;
        
        -- Price increase logic apply karo
        IF p_price > 40000 THEN
            SET new_price = p_price * 1.10;  -- 10% increase
        ELSEIF p_price BETWEEN 10000 AND 40000 THEN
            SET new_price = p_price * 1.05;  -- 5% increase
        ELSE
            SET new_price = p_price * 1.02;  -- 2% increase
        END IF;
        
        -- Price update karo
        UPDATE products SET price = new_price WHERE id = p_id;
		END LOOP;
        
         -- Cursor close karo
    CLOSE UpdateProductPrices;
	END $$

	DELIMITER ;
        
CALL UpdateProductPrices();

select * from products;
-- drop cursor
DROP PROCEDURE UpdateProductPrices;
        