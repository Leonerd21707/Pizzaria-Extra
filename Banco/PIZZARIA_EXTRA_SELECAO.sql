USE PIZZARIA_EXTRA;

SELECT * FROM USUARIOS;

SELECT * FROM PIZZARIAS;

SELECT * FROM PIZZARIAS INNER JOIN CATEGORIAS ON PIZZARIAS.ID_CATEGORIA = CATEGORIAS.ID_CATEGORIA;