-- ユーザーを作成（新しいバージョンで使われている、caching_sha2_passwordという方式）
CREATE USER 'vscode_user' @'%' IDENTIFIED
WITH
    caching_sha2_password BY 'password123';

-- 作成したユーザーにすべての権限を付与
GRANT ALL PRIVILEGES ON *.* TO 'vscode_user' @'%' WITH GRANT OPTION;

-- 設定を反映
FLUSH PRIVILEGES;