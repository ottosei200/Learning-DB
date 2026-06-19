-- 【修正後】 mysql_native_password から caching_sha2_password に変更
CREATE USER 'vscode_user'@'%' IDENTIFIED WITH caching_sha2_password BY 'password123';

-- （ここは変更なし）
GRANT ALL PRIVILEGES ON *.* TO 'vscode_user'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;