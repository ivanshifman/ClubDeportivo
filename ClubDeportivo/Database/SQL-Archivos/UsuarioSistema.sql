CREATE USER 'club_user'@'localhost' IDENTIFIED WITH mysql_native_password BY 'MiPass123';
GRANT ALL PRIVILEGES ON club_deportivo.* TO 'club_user'@'localhost';
FLUSH PRIVILEGES;