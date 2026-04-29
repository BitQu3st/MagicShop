-- Attenzione: decommentare solo in caso di reset del database
 -- DROP DATABASE IF EXISTS magicshop;

CREATE DATABASE IF NOT EXISTS MagicShop;

USE MagicShop;

CREATE TABLE IF NOT EXISTS items(
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(255) not null,
    prezzo_base INT NOT NULL default 100,
    rarita VARCHAR(50) NOT NULL default 'comune',
    UNIQUE(nome,rarita)
);

CREATE TABLE IF NOT EXISTS users(
    id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) not null,
    password_hash VARCHAR(255) not null,
    gold int NOT NULL default 500,
    UNIQUE(username)
);

CREATE TABLE IF NOT EXISTS npc(
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(255) not null,
    gold int NOT NULL default 100,
    UNIQUE(nome)
);

CREATE TABLE IF NOT EXISTS user_inventory(
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    item_id INT  NOT NULL ,
    FOREIGN KEY (item_id) REFERENCES items(id) ON DELETE CASCADE,
    quantita INT default 1 NOT NULL ,
    UNIQUE(user_id,item_id)

);

CREATE TABLE IF NOT EXISTS npc_inventory(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    npc_id INT NOT NULL,
    FOREIGN KEY (npc_id) REFERENCES npc(id) ON DELETE CASCADE,
    item_id INT NOT NULL,
    FOREIGN KEY (item_id) REFERENCES items(id) ON DELETE CASCADE,
    quantita INT default 1 NOT NULL,
    UNIQUE(npc_id,item_id)
);


