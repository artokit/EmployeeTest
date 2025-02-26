UPDATE departments
SET name = @name, phone = @phone
WHERE id = @id
    RETURNING 
    id AS "Id", 
    name AS "Name", 
    phone AS "Phone";
