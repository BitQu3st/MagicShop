-- Seed Items basilare per testing
USE MagicShop;

-- Inserimento pozioni
INSERT INTO items(nome,prezzo_base,rarita)
VALUES
    ('Pozione Vita',10,'comune'),
    ('Pozione Mana', 15,'comune'),
    ('Pozione Vita',50,'magica'),
    ('Pozione Mana', 55,'magica'),
    ('Pozione Vita',100,'epica'),
    ('Pozione Mana', 105,'epica');

-- Inserimento Spade
INSERT INTO items(nome,prezzo_base,rarita)
VALUES
    ('Spada',100,'comune'),
    ('Spada Magica', 150,'magica'),
    ('Dominus',500,'epica');

-- Inserimento Elmo
INSERT INTO items(nome,prezzo_base,rarita)
VALUES
    ('Elmo',100,'comune'),
    ('Elmo Magico', 150,'magica'),
    ('Belltrix',500,'epica');

-- Inserimento ARMATURA
INSERT INTO items(nome,prezzo_base,rarita)
VALUES
    ('Armatura',100,'comune'),
    ('Armatura Magica', 150,'magica'),
    ('Brittania',500,'epica');

-- Inserimento STIVALI
INSERT INTO items(nome,prezzo_base,rarita)
VALUES
    ('Stivali',100,'comune'),
    ('Stivali Magici', 150,'magica'),
    ('Stivali del Dio Alato',500,'epica');
